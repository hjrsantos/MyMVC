using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using MVC4.MyOrganizer.Models;
using MVC4.MyOrganizer.Utils;
using System.Net.Http;
using System.Net;

namespace MVC4.MyOrganizer.Controllers
{
    public class TodoApiController : ApiController
    {

        //GET api/TodoApi
        public List<TodoItem> getTodoItems() {

            return DBHandler.getAllTodoItems();
        }

        //POST
        public HttpResponseMessage SaveTodoItem(TodoItem oTodoItem)
        {


            if (ModelState.IsValid)
            {
                DBHandler.saveNewTodoItem(oTodoItem);
                return Request.CreateResponse(HttpStatusCode.Created, oTodoItem);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Invalid model state");
        }


        //PUT
        public HttpResponseMessage EditTodoItem(int id, TodoItem oTodoItem)
        {
            if (
                ModelState.IsValid &&
                id == oTodoItem.Id
            )
            {
                DBHandler.updateTodoItem(oTodoItem);
                return Request.CreateResponse(HttpStatusCode.Created, oTodoItem);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Invalid model state");
        }

    }
}
