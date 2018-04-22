using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;
using WebApplication.Models;

namespace WebApplication.Presenter
{
    public class CreateEventsPresenter
    {
        private ICreateEvents View;
        private AgeGroupTypesContainer ageGroupTypesContainer = new AgeGroupTypesContainer();
        private EventsContainer eventsContainer = new EventsContainer();
        private EventTypesContainer eventTypesContainer = new EventTypesContainer();
        private List<string> selectedGroups;

        public CreateEventsPresenter(ICreateEvents view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            this.View = view;
        }

        public void InitView()
        {
            populateGridView();
        }

        public void setEventTypes()
        {
            View.EventTypes = eventTypesContainer.EventTypes.ToList();
        }

        public void setAgeGroupTypes()
        {
            View.AgeGroupTypes = ageGroupTypesContainer.AgeGroupTypes.ToList();
        }

        public void setSelectedGroups(List<string> selectedGroups)
        {
            this.selectedGroups = selectedGroups;
        }

        public void populateGridView()
        {
            View.Events = eventsContainer.Events.ToList();
        }

        public bool AddNewEvent(Events events)
        {
            if (eventsContainer.addEvent(events, selectedGroups))
            {
                return true;
            }
            return false;
        }

        public bool EditEvent(int Id)
        {
            if (eventsContainer.editEvent(Id, View.Title, View.Type))
            {
                return true;
            }
            return false;
        }
    }
}