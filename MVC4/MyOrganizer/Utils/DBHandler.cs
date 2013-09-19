using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4.MyOrganizer.Models;
using HealthyJuanWeb.Utilities;

namespace MVC4.MyOrganizer.Utils
{
    public class DBHandler
    {

        public static bool registerUser(RegisterDTO oDTO) {

            if(!isUserNameUnique(oDTO.UserName))
                return false;


            using (var db = new OrganizerDBContext())
            {

                AppUser oAppUser = new AppUser();
                oAppUser.UserName = oDTO.UserName;
                oAppUser.Password = PasswordHash.CreateHash(oDTO.Password);

                db.AppUsers.Add(oAppUser);
                db.Entry(oAppUser).State = System.Data.EntityState.Added;
                db.SaveChanges();
            }
            return true;

        }

        private static bool isUserNameUnique(string userName) {

            AppUser appUser;
            using (var db = new OrganizerDBContext()) {
                appUser = db.AppUsers.SingleOrDefault(p => p.UserName == userName);            
            }
            return appUser == null;
        }


        public static AppUser getAppUserByUserName(string sUserName)
        { 
            AppUser oAppUser = null;
            using(var db = new OrganizerDBContext()){
                oAppUser = 
                    db.
                    AppUsers.
                    Include("ThingsTodo").
                    Where(p => p.UserName == sUserName).
                    FirstOrDefault();            
            }
            return oAppUser;
        }


        public static List<TodoItem> getAllTodoItemsByCategoryId(string categoryId)
        {
            AppUser appUser = getAppUserByUserName(HttpContext.Current.User.Identity.Name);

            if (string.IsNullOrEmpty(categoryId))
                return appUser.ThingsTodo.ToList();

            return appUser.ThingsTodo.Where(p => p.CategoryId == int.Parse(categoryId)).ToList();
        }

        public static IEnumerable<Category> getAllCategories() {

            List<Category> listCategories = new List<Category>();
            using(var db = new OrganizerDBContext()){

                listCategories = db.Categories.ToList();
            }
            return listCategories;
        }

        public static void saveTodoItem(TodoItemDTO todoItemDTO)
        {
            using(var db = new OrganizerDBContext()){

                AppUser appUser =
                    db.
                    AppUsers.
                    Include("ThingsTodo").
                    Single(p => p.UserName == HttpContext.Current.User.Identity.Name);                  
                appUser.ThingsTodo.Add(
                    new TodoItem { CategoryId = todoItemDTO.SelectedCategoryId, Title = todoItemDTO.Title, Completed = false }
                );

                
                db.AppUsers.Attach(appUser);
                db.Entry(appUser).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }        
        }

        public static void EditTodoItem(TodoItemDTO todoItemDTO, int todoItemId) {

            TodoItem todoItem = 
                getAppUserByUserName(HttpContext.Current.User.Identity.Name).
                ThingsTodo.
                FirstOrDefault(p=>p.Id == todoItemId);

            if (todoItem == null)
                throw new Exception("Access denied");


            todoItem.CategoryId = todoItemDTO.SelectedCategoryId;
            todoItem.Completed = todoItemDTO.SelectedCompletedId == 0 ? false : true;
            todoItem.Title = todoItemDTO.Title;

            using (var db = new OrganizerDBContext())
            {
                db.TodoItems.Attach(todoItem);
                db.Entry(todoItem).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }


        public static TodoItem getTodoItemById(int id) {

            return getAppUserByUserName(HttpContext.Current.User.Identity.Name).ThingsTodo.FirstOrDefault(p => p.Id == id);
            
        }

        public static void deleteTodoItemById(int id) {
            TodoItem todoItem = getAppUserByUserName(HttpContext.Current.User.Identity.Name).ThingsTodo.FirstOrDefault(p => p.Id == id);

            using(var db = new OrganizerDBContext()){

                db.Entry(todoItem).State = System.Data.EntityState.Deleted;
                db.SaveChanges();
            
            }
        }


       //additional features for knockout demo
        public static List<TodoItem> getAllTodoItems() {

            using (var db = new OrganizerDBContext()) {

                return db.TodoItems.ToList();            
            }
        }

        public static void saveNewTodoItem(TodoItem oTodoItem) { 
            using(var db = new OrganizerDBContext()){

                db.TodoItems.Add(oTodoItem);
                db.Entry(oTodoItem).State = System.Data.EntityState.Added;
                db.SaveChanges();
            
            }
            
        }

        public static void updateTodoItem(TodoItem oTodoItem)
        {
            using (var db = new OrganizerDBContext())
            {

                db.TodoItems.Attach(oTodoItem);
                db.Entry(oTodoItem).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }

        }
    }
}