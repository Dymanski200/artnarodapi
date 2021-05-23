using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
