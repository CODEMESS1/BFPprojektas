﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EventTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public string Name { get
            {
                return Type + " " + Method;
            } }

        public EventTypes()
        {

        }

        public EventTypes(string type, string method)
        {
            Type = type;
            Method = method;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Method);
        }
    }
}