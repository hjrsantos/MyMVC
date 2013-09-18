using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC4.MyOrganizer.Models
{
    public class OrganizerDBContext:DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public OrganizerDBContext()
            : base("name=MDFConnection")
        {}
    }
}