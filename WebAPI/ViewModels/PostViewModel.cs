using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

        public List<AttachmentViewModel> Attachments { get; set; }

        public PostViewModel(Post model, User user) 
        {
            ID = model.ID;
            UserID = model.UserID;
            CategoryID = model.CategoryID;
            Name = model.Name;
            UserName = user.Name;
            Avatar = user.Avatar;
            Text = model.Text;
            Rating = model.Rating;
            Date = model.Date;
            Attachments = new List<AttachmentViewModel>();
            foreach (Attachment attachment in model.Attachments)
                Attachments.Add(new AttachmentViewModel(attachment));
        }
    }
}
