﻿using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public class PersonSummaryView
    {
        [Required]
        public int PersonSummaryViewId { get; set; }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public int ActivitiesCount { get; set; }
        public int MealsCount { get; set; }
        public int HydrationCount { get; set; }
    }
}