using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class AttachmentViewModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public AttachmentViewModel(Attachment model)
        {
            ID = model.ID;
            Type = model.Type;
            Url = model.Url;
        }
    }
}
