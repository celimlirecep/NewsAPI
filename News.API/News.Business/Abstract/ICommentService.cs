using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public Task<Comment> CreateAsync(Comment comment);
    }
}
