using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Abstract
{
    public interface IInfoRepository : IGenericRepository<Info>
    {
        Task<List<Info>> GetFourNewsWithCategory();
        Task<Info> GetByIdWithAllDetails(int id);
        Task<List<Info>> GetLastTenByCategory(int categoryId);
        Task<List<Info>> GetByCategory(int categoryId);
    }
}
