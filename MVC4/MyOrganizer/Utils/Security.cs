using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using HealthyJuanWeb.Utilities;
using MVC4.MyOrganizer.Models;

namespace MVC4.MyOrganizer.Utils
{
    public class Security
    {
        public static bool isValidUser(string sUserName, string sPassword) {

            AppUser oAppUser = DBHandler.getAppUserByUserName(sUserName);
            return PasswordHash.ValidatePassword(sPassword, oAppUser.Password);        
        }
    }
}