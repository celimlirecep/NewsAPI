using Microsoft.EntityFrameworkCore;
using News.DataAccess.Abstract;
using News.DataAccess.Concreate;
using News.DataAccess.Repository;
using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public EfCategoryRepository(MBContext context) : base(context)
        {

        }
        private MBContext MBContext
        {
            get { return _context as MBContext; }
        }

        public async Task<Category> GetCategoryWithNews(int id)
        {
            return await MBContext.Categories.Include(x => x.News).Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        }
    }
}
