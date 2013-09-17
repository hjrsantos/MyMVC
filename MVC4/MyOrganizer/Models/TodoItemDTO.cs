using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.MyOrganizer.Utils;

namespace MVC4.MyOrganizer.Models
{
    public class TodoItemDTO
    {
        //dropdown binding
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }


        public int SelectedCompletedId { get; set; }
        public IEnumerable<SelectListItem> Completed = new List<SelectListItem>{
        
            new SelectListItem{ Text = "It is done", Value="1"},
            new SelectListItem{ Text = "I need more time", Value="0"}
        };


        public string Title { get; set; }

        public TodoItemDTO() {
            List<SelectListItem> listSelectItems = new List<SelectListItem>();
            foreach(Category oCategory in DBHandler.getAllCategories()){
               listSelectItems.Add(
                    new SelectListItem { Text= oCategory.Name, Value= oCategory.Id.ToString()}    
               );            
            }
            this.Categories = listSelectItems; 
        }
    }
}