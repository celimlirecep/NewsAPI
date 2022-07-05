using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<Category> GetCategoryWithNews(int id);
    }
}
