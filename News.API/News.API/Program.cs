using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using News.API.Extansions;
using News.API.JWT;
using News.Business.Abstract;
using News.Business.Concrete;
using News.DataAccess.Abstract;
using News.DataAccess.Concreate;
using News.DataAccess.EntityFramework;
using News.Entity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MBContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(configureOptions =>
{
    configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x => {

    //No metadata needed when sending http packet

    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        RequireExpirationTime = true
    };
});
builder.Services.AddCors(
             options =>
             {
                 options.AddPolicy(
                     name: "_MyAllowAll",
                     policy =>
                     {
                         policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                     });
             });

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddSingleton<IJWTAuthenticationService>(new JWTAuthenticationManager(builder.Configuration["JWTKey"]));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IInfoService, InfoManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors("_MyAllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.MigrateDatabase().Run();
