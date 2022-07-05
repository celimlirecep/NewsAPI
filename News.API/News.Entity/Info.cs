using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entity
{
    public class Info
    {
        public int InfoId { get; set; }
        public string NewsName { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
