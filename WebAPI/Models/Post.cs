using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
