using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4.MyOrganizer.Models
{
    public class NewTodo
    {

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TodoItem> TodoItems { get; set; }
    }
}