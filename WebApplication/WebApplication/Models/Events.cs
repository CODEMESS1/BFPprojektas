using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Events
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public int SubgroupsId { get; set; }

        public Events()
        {

        }

        public Events(string id, string title, string subgroupsId)
        {
            Id = Convert.ToInt32(id);
            Title = title;
            SubgroupsId = Convert.ToInt32(subgroupsId);
        }

        public override string ToString()
        {
            return String.Format("{0} ",Title);
        }

    }
}