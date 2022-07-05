using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithNews(int id);
    }
}
