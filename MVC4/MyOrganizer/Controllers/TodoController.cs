using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.MyOrganizer.Models;
using MVC4.MyOrganizer.Utils;

namespace MVC4.MyOrganizer.Controllers
{
    public class TodoController : Controller
    {
        //
        // GET: /Todo/

        [Authorize]
        public ActionResult Index(string category, string id)
        {
            NewTodo oTodo = new NewTodo();
            oTodo.TodoItems = DBHandler.getAllTodoItemsByCategoryId(id);
            oTodo.Categories = DBHandler.getAllCategories();
            oTodo.TodoDTO = new TodoItemDTO();
            ViewData.Model = oTodo;
            ViewBag.Category = category;


            return View();
        }

        //Get: /Todo/Create
        [Authorize]
        public ActionResult Create() {
            ViewData.Model = new TodoItemDTO();
            return View("Create");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(TodoItemDTO oTodo)
        {
            DBHandler.saveTodoItem(oTodo);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(string id) {
            
            TodoItem todoItem = DBHandler.getTodoItemById(int.Parse(id));
            if (todoItem == null)
                RedirectToAction("Index");

            TodoItemDTO todoItemDTO = new TodoItemDTO();

            todoItemDTO.Title = todoItem.Title;
            todoItemDTO.SelectedCategoryId = todoItem.CategoryId;
            todoItemDTO.SelectedCompletedId = todoItem.Completed ? 1 : 0;

            SelectListItem completedSelectItem = todoItemDTO.Completed.Where(p => int.Parse(p.Value) == todoItemDTO.SelectedCompletedId).FirstOrDefault();
            if (completedSelectItem != null)
                completedSelectItem.Selected = true;

            SelectListItem selectItem = todoItemDTO.Categories.Where(p => int.Parse(p.Value) == todoItem.CategoryId).FirstOrDefault();
            if (selectItem != null)
                selectItem.Selected = true;

            ViewData.Model = todoItemDTO;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(TodoItemDTO oTodo, string id)
        {

            DBHandler.EditTodoItem(oTodo, int.Parse(id));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id) {

            DBHandler.deleteTodoItemById(int.Parse(id));
            return RedirectToAction("Index");
        
        }
    }
}
