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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment { CommentId=1,UserName="Murat Kuşcan",InfoId=1,Content="İnanılmaz bir haber"},
                new Comment { CommentId=2,UserName="Berke Dursunoğlu",InfoId=1,Content="Umarım Erkenden bulunur.."},
                new Comment { CommentId=3,UserName="Onurcan Cengiz",InfoId=1,Content="Allah ailesine sabır versin.."},
                new Comment { CommentId=4,UserName="Ozan Çepni",InfoId=1,Content="Umarım kaçırılıp böbreklerini satmamışlardır.."}
                );
        }
    }
}
