using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.API.JWT;
using News.API.Models;
using News.Entity;

namespace News.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IJWTAuthenticationService _jWT;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTAuthenticationService jWT)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jWT = jWT;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
          
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                var userToken = _jWT.Authenticate(user.Id.ToString());
                return Ok(userToken);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
        
            var appUser = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                TcNo="1234",
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return Ok("Giriş Başarılı");
            }
            return BadRequest();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var user = await _userManager.FindByIdAsync(userid);
         
            return Ok(user);

        }
    }
}
