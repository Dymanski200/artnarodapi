using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataModels
{
    public class PostDataModel
    {
        [Required(ErrorMessage = "Укажите заголовок")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
        public int CategoryID { get; set; }
        public List<AttachmentDataModel> Attachments { get; set; }
    }
}
