using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AspUsersContainer: DbContext
    {
        public AspUsersContainer() : base("DefaultConnection")
        {

        }

        public DbSet<AspNetUsers> aspNetUsers { get; set; }
    }
}