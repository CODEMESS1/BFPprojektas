using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CompetitionAgeSubgroups
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int AgeGroupId { get; set; }
        public int SubGroupCount { get; set; }

        public CompetitionAgeSubgroups()
        {

        }

        public CompetitionAgeSubgroups(int competitionId, int ageGroupId, int subGroupCount)
        {
            CompetitionId = competitionId;
            AgeGroupId = ageGroupId;
            SubGroupCount = subGroupCount;
        }
    }
}