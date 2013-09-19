using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC4.MyOrganizer.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool Completed { get; set; }
        public string Title { get; set; }
        
        //public static List<TodoItem> ThingsTodo = new List<TodoItem> { 
        //    new TodoItem{ Title = "Create MVC Sample app" , Completed = false},
        //    new TodoItem{ Title = "Publish MVC Sample app" , Completed = false}
        //};
    }
}