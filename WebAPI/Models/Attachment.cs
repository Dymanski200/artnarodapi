using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Attachment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public Post Post { get; set; }
    }
}
