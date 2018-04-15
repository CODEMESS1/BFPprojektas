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

        public Competition()
        {

        }

        public Competition(string name, string locaction, string address, DateTime date,
            Boolean registration, DateTime? registrationStartDate, DateTime? registrationEndDate)
        {
            Name = name;
            Location = locaction;
            Address = address;
            Date = date;
            Registration = registration;
            RegistrationStartDate = new DateTime?(registrationStartDate.Value);
            RegistrationEndDate = new DateTime?(registrationEndDate.Value);
        }
    }
}