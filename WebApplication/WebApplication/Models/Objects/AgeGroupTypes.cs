using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AgeGroupTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public AgeGroupTypes()
        {

        }

        public AgeGroupTypes(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("{0}", Type);
        }
    }
}