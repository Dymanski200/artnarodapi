using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public CategoryViewModel(Category model) 
        {
            ID = model.ID;
            Name = model.Name;
            Url = model.Url;
        }
    }
}
