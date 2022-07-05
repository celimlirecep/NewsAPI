using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.DataAccess.Concreate.Config;
using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Concreate
{
    public class MBContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfoConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
