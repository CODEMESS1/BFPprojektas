using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitorsContainer : DbContext
    {
        public CompetitorsContainer() : base("DefaultConnection")
        {

        }

        public DbSet<Competitors> Comp { get; set; }

        /// <summary>
        /// pagal trenerio id, išfiltruoja sąrašą dalyvių
        /// </summary>
        /// <returns></returns>
        public List<Competitors> getFilteredCompetitors(string coachId)
        {
            List<Competitors> competitors = Comp.Where(c => c.CoachId.Equals(coachId)).ToList();
            return competitors;
        }

        /// <summary>
        /// gauna dalyvį pagal id
        /// </summary>
        /// <param name="coachId"></param>
        /// <returns></returns>
        public Competitors GetCompetitor(int id)
        {
            List<Competitors> competitor = Comp.Where(c => c.Id == id).ToList();

            if (competitor.Count != 0)
            {
                return competitor[0];
            }
            else
            {
                return null;
            }
        }

        public List<Competitors> CompetitorBySurname(string surname)
        {
            return Comp.Where(c => c.Surname.Equals(surname)).ToList();
        }

        public List<Competitors> RemoveCompetitorFromCompetitors(int id)
        {
            Competitors competitor = GetCompetitor(id);
            if (competitor != null)
            {
                Comp.Remove(competitor);
                SaveChanges();
                return Comp.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Competitors> AddCompetitorToCompetitors(Competitors competitor)
        {
            Comp.Add(competitor);
            SaveChanges();
            return Comp.ToList();
        }

        public bool CompetitorExists(Competitors competitor)
        {
            if (Comp.ToList().Contains(competitor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReplaceExisting(Competitors competitor)
        {
            List<Competitors> removedOld = RemoveCompetitorFromCompetitors(competitor.Id);
            if (removedOld != null)
            {
                AddCompetitorToCompetitors(competitor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeCompetitorValues(Competitors competitor)
        {
            if (competitor != null)
            {
                Competitors original = Comp.Where(c => c.Id == competitor.Id).ToList()[0];

                if (!(original.Name.Equals(competitor.Name)) && !(competitor.Name.Equals(string.Empty)))
                {
                    original.Name = competitor.Name;
                }
                if (!(original.Surname.Equals(competitor.Surname)) && !(competitor.Surname.Equals(string.Empty)))
                {
                    original.Surname = competitor.Surname;
                }
                if (!(original.Year.Equals(competitor.Year)) && !(competitor.Year.Equals(string.Empty)))
                {
                    original.Year = competitor.Year;
                }
                if (!(original.City.Equals(competitor.City)) && !(competitor.City.Equals(string.Empty)))
                {
                    original.City = competitor.City;
                }
                if (!(original.Country.Equals(competitor.Country)) && !(competitor.Country.Equals(string.Empty)))
                {
                    original.Country = competitor.Country;
                }
                if (!(original.Gender.Equals(competitor.Gender)) && !(competitor.Gender.Equals(string.Empty)))
                {
                    original.Gender = competitor.Gender;
                }

                ReplaceExisting(original);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}