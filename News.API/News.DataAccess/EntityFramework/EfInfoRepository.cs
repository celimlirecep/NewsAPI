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
    public class EfInfoRepository : GenericRepository<Info>,IInfoRepository
    {
        public EfInfoRepository(MBContext context) : base(context)
            {

            }
        private MBContext MBContext 
        {
            get { return _context as MBContext; }
        }

        public async Task<List<Info>> GetLastTenByCategory(int categoryId)
        {
            var infosbyCategory = await MBContext.Infos.OrderByDescending(x=>x.InfoId).Where(x => x.CategoryId == categoryId).Take(10).ToListAsync();
            return infosbyCategory;
        }

        public async Task<Info> GetByIdWithAllDetails(int id)
        {
            var info = await MBContext.Infos.Include(x => x.Category).Include(x => x.Comments).Where(x => x.InfoId == id).FirstOrDefaultAsync();
            return info;
        }

        public async Task<List<Info>> GetFourNewsWithCategory()
        {
            var infos = await MBContext.Infos.OrderByDescending(x=>x.InfoId).Take(4).ToListAsync();
            return infos;
        }

        public async Task<List<Info>> GetByCategory(int categoryId)
        {
            var infosbyCategory = await MBContext.Infos.Include(x => x.Category).OrderByDescending(x => x.InfoId).Where(x => x.CategoryId == categoryId).ToListAsync();
            return infosbyCategory;
        }
    }
}
