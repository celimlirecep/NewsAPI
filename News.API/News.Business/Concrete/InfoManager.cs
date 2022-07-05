using News.Business.Abstract;
using News.DataAccess.Abstract;
using News.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Concrete
{
    public class InfoManager : IInfoService
    {

        private readonly IUnitOfWork _unitOfWork;

        public InfoManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Info t)
        {
            await _unitOfWork.Infos.Create(t);
            await _unitOfWork.SaveAsync();
        }

    
        public async Task Delete(Info t)
        {
            await _unitOfWork.Infos.Delete(t);
            await _unitOfWork.SaveAsync();

        }

        public async Task<List<Info>> GetByCategory(int categoryId)
        {
            return await _unitOfWork.Infos.GetByCategory(categoryId);
        }

        public async Task<Info> GetById(int id)
        {
            return await _unitOfWork.Infos.GetById(id);

        }

        public async Task<Info> GetByIdWithAllDetails(int id)
        {
            return await _unitOfWork.Infos.GetByIdWithAllDetails(id);
        }

        public async Task<List<Info>> GetFourNewsWithCategory()
        {
            return await _unitOfWork.Infos.GetFourNewsWithCategory();
        }

        public async Task<List<Info>> GetLastTenByCategory(int categoryId)
        {
            return await _unitOfWork.Infos.GetLastTenByCategory(categoryId);
        }

        public async Task<List<Info>> GetList()
        {
            return await _unitOfWork.Infos.GetAll();
        }

        public async Task Update(Info t)
        {
            await _unitOfWork.Infos.Update(t);
            await _unitOfWork.SaveAsync();


        }
    }
}
