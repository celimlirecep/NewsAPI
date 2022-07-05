using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Concreate.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Ekonomi" },
                new Category { CategoryId = 2, CategoryName = "Siyaset" },
                new Category { CategoryId = 3, CategoryName = "Spor" },
                new Category { CategoryId = 4, CategoryName = "Ulusal" },
                new Category { CategoryId = 5, CategoryName = "Genel" }
                );
        }
    }
}
