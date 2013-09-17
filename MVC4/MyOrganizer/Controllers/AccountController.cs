using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.MyOrganizer.Models;
using System.Web.Security;
using MVC4.MyOrganizer.Utils;

namespace MVC4.MyOrganizer.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AppUser oLogin, string returnURL, string cRememberLogin)
        {
            if (Security.isValidUser(oLogin.UserName, oLogin.Password))
            {
                bool isRememberLogin = !string.IsNullOrEmpty(cRememberLogin) && Request.Form.AllKeys.Contains("cRememberLogin");
                if (string.IsNullOrEmpty(returnURL))
                {
                    FormsAuthentication.SetAuthCookie(oLogin.UserName, isRememberLogin);
                    return RedirectToAction("Index", "Todo");
                }
                else
                    FormsAuthentication.RedirectFromLoginPage(oLogin.UserName, isRememberLogin);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(oLogin);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signout() {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDTO oDTO) {

            if (!validateRegistration(oDTO))
                return View(oDTO);        

            if (DBHandler.registerUser(oDTO))
                return RedirectToAction("Login");
            else
            {
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "The user name is already taken.");
                return View(oDTO);   
            }
        }

        private bool validateRegistration(RegisterDTO oDTO)
        {
            if (string.IsNullOrEmpty(oDTO.UserName) ||
                string.IsNullOrEmpty(oDTO.Password) ||
                string.IsNullOrEmpty(oDTO.ConfirmPassword)
            ){            
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "Please fix the error");
                return false;             
            }
            if (oDTO.Password != oDTO.ConfirmPassword)
            {
                ModelState.AddModelError("", "Please fix the error");
                return false;
            }

            return true;        
        }

    }
}
