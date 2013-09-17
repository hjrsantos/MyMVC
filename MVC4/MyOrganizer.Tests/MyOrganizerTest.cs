using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC4.MyOrganizer.Models;
using MVC4.MyOrganizer.Controllers;
using System.Web.Mvc;

namespace MVC4.MyOrganizer.Tests
{
    [TestClass]
    public class MyOrganizerTest
    {
        [TestMethod]
        public void Should_Display_All_Itmes()
        {
            var viewResult = (ViewResult)new TodoController().Index();
            Assert.AreEqual(TodoItem.ThingsTodo, viewResult.ViewData.Model );
        }

        [TestMethod]
        public void Should_Display_Create_View()
        {
            var viewResult = (ViewResult)new TodoController().Create();
            Assert.AreEqual("Create", viewResult.ViewName);
        }

        
        [TestMethod]
        public void Should_Add_New_TodoItem()
        {
            //var oTodo =
            //    new TodoItem
            //    {
            //        Title = "test 123"
            //    };

            //var redirectToRouteResult = (RedirectToRouteResult)new TodoController().Create(oTodo);

            //Assert.IsTrue( TodoItem.ThingsTodo.Contains(oTodo));
        }

    }
}
