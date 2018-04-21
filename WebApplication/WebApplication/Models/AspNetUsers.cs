using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AspNetUsers
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set;}
        public string UserName { get; set; }
        public DateTime? Year { get; set; }
        public string FullName { get
            {
                return string.Format("Vardas: {0}, Pavardė: {1}, Gim: {2:yyyy:MM}: ", Name, Surname, Year);
            } }


        public override string ToString()
        {
            return string.Format("Vardas: {0}, Pavardė: {1}", Name, Surname);
        }
    }
}