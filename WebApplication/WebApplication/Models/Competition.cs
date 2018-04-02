using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Competition
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public Boolean Registration { get; set; }
        public DateTime? RegistrationStartDate { get; set; }
        public DateTime? RegistrationEndDate { get; set; }
    }
}