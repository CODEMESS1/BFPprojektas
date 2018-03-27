using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ContainerCompetitors: DbContext
    {
        public ContainerCompetitors(): base("DefaultConnection")
        {

        }

        public DbSet<Competitors> Comp { get; set; }


    }
}