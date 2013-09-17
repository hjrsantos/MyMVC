using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.MyOrganizer.Models
{
    public class TodoItemDTO
    {
        //public int Id { get; set; }
        public string SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories = new List<SelectListItem> { 
            new SelectListItem{ Text = "Home", Value = "1"},
            new SelectListItem{ Text = "Work", Value = "2"}
        };
        //public bool Completed { get; set; }
        public string Title { get; set; }
    }
}