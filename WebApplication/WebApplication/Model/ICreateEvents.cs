using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Model
{
    public interface ICreateEvents
    {
        List<EventTypes> EventTypes { set; }
        List<Events> Events { set; }
        List<AgeGroupTypes> AgeGroupTypes { set; }
        string Title { get; set; }
        string Type { get; set; }
        bool AddEvent(Events eventToAdd);
        bool RemoveEvent(int eventIdToRemove);
        bool EditEvent(int eventIdToEdit);
    }
}
