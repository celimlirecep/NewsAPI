using News.DataAccess.Abstract;
using News.DataAccess.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MBContext _context;

        public UnitOfWork(MBContext context)
        {
            _context = context;
        }
        private EfCategoryRepository _categoryRepository;
        private EfInfoRepository _infoRepository;
        private EfCommentRepository _commentRepository;
        public ICategoryRepository Categories => _categoryRepository=_categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments =>_commentRepository=_commentRepository ?? new EfCommentRepository(_context);

        public IInfoRepository Infos => _infoRepository=_infoRepository ?? new EfInfoRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
