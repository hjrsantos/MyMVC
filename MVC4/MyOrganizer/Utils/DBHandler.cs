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

        public static void registerUser(RegisterDTO oDTO) { 
            
            using(var db = new OrganizerDBContext()){

                AppUser oAppUser = new AppUser();
                oAppUser.UserName = oDTO.UserName;
                oAppUser.Password = PasswordHash.CreateHash(oDTO.Password);

                db.AppUsers.Add(oAppUser);
                db.Entry(oAppUser).State = System.Data.EntityState.Added;
                db.SaveChanges();
            }
        
        }

        public static AppUser getAppUserByUserName(string sUserName)
        { 
            AppUser oAppUser = null;
            using(var db = new OrganizerDBContext()){

                oAppUser = db.AppUsers.Single(p => p.UserName == sUserName);            
            }

            return oAppUser;
        }
    }
}