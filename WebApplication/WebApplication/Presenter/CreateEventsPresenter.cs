using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Admin.Competition;
using WebApplication.Model;
using WebApplication.Models;
using WebApplication.Tests.Mocks;

namespace WebApplication.Presenter
{
    public class CreateEventsPresenter
    {
        private ICreateEvents View;
        private AgeGroupTypesContainer ageGroupTypesContainer = new AgeGroupTypesContainer();
        private EventsContainer eventsContainer;
        private EventTypesContainer eventTypesContainer = new EventTypesContainer();
        private List<string> selectedGroups;
        private EventsContainer context;
        private CreateEvents createEvents;

        public CreateEventsPresenter(ICreateEvents view)
        {
            if (view == null)
                throw new ArgumentNullException("view cannot be null");

            eventsContainer = new EventsContainer();
            View = view;
        }

        public CreateEventsPresenter(CreateEventsViewMock view, EventsContainer context)
        {
            View = view;

            eventsContainer = context;
        }

        /*public CreateEventsPresenter(CreateEvents createEvents)
        {
            this.createEvents = createEvents;
        }*/

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
            if (eventsContainer.AddEvent(events, selectedGroups))
            {
                return true;
            }
            return false;
        }

        public bool EditEvent(int Id)
        {
            if (eventsContainer.editEvent(Id, View.Title, View.Type, selectedGroups))
            {
                return true;
            }
            return false;
        }
    }
} 