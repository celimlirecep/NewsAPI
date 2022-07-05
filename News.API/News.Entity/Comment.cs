using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int InfoId { get; set; }
        public Info Info { get; set; }
    }
}
