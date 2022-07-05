using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IInfoRepository Infos { get; }
        Task<int> SaveAsync();
    }
}
