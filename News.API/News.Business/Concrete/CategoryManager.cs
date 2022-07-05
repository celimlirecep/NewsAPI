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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Category t)
        {
            await _unitOfWork.Categories.Create(t);
            await _unitOfWork.SaveAsync();

        }

        public async Task Delete(Category t)
        {
            await _unitOfWork.Categories.Delete(t);
            await _unitOfWork.SaveAsync();

        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetById(id);
        }

        public async Task<Category> GetCategoryWithNews(int id)
        {
            return await _unitOfWork.Categories.GetCategoryWithNews(id);
        }

        public async Task<List<Category>> GetList()
        {
            return await _unitOfWork.Categories.GetAll();
        }

        public async Task Update(Category t)
        {
            await _unitOfWork.Categories.Update(t);
            await _unitOfWork.SaveAsync();

        }
    }
}
