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
    public class EfCommentRepository : GenericRepository<Comment>,ICommentRepository
    {
        public EfCommentRepository(MBContext context) : base(context)
        {

        }
        private MBContext MBContext
        {
            get { return _context as MBContext; }
        }
    }
}
