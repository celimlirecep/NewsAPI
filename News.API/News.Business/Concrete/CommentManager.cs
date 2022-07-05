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
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Comment t)
        {
            await _unitOfWork.Comments.Create(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _unitOfWork.Comments.Create(comment);
            await _unitOfWork.SaveAsync();
            return comment;
        }

        public async Task Delete(Comment t)
        {
            await _unitOfWork.Comments.Delete(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _unitOfWork.Comments.GetById(id);

        }

        public async Task<List<Comment>> GetList()
        {
            return await _unitOfWork.Comments.GetAll();
        }

        public async Task Update(Comment t)
        {
           await _unitOfWork.Comments.Update(t);
           await _unitOfWork.SaveAsync();
        }
    }
}
