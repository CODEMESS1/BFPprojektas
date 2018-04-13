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

        public Competition(string name, string locaction, int id, DateTime date, string address, 
            Boolean registration, DateTime? registrationStartDate, DateTime? registrationEndDate)
        {
            Name = name;
            Location = locaction;
            Id = id;
            Date = date;
            Address = address;
            Registration = registration;
            RegistrationStartDate = registrationStartDate;
            RegistrationEndDate = registrationEndDate;
        }
    }
}