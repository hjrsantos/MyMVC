using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.MyOrganizer.Models;

namespace MVC4.MyOrganizer.Controllers
{
    public class TodoController : Controller
    {
        //
        // GET: /Todo/

        [Authorize]
        public ActionResult Index()
        {
            NewTodo oTodo = new NewTodo();
            oTodo.TodoItems = TodoItem.ThingsTodo;
            oTodo.Categories = new List<Category>{
                new Category{ Name="Home", Description = "isang malupet"},
                new Category{ Name="Work", Description = "isang malupet"}
            };

            ViewData.Model = oTodo; //TodoItem.ThingsTodo;
            return View();
        }

        //Get: /Todo/Create
        [Authorize]
        public ActionResult Create() {
            ViewData.Model = new TodoItemDTO();
            return View("Create");
        }

        //Post
        [HttpPost]
        [Authorize]
        //public ActionResult Create(TodoItem oTodo)
        public ActionResult Create(TodoItemDTO oTodo)
        {
            //TodoItem.ThingsTodo.Add(oTodo);
            return RedirectToAction("Index");
        }

        public ActionResult Browse(string Category) {

            return RedirectToAction("Index");
            //return View("Index");
        }
    }
}
