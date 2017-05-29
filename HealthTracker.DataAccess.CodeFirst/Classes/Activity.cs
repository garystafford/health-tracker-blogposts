using System;
using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [EnumDataType(typeof(ActivityType))]
        public ActivityType ActivityTypeId { get; set; }

        [StringLength(100, ErrorMessage =
            "Note must be less than 100 characters.")]
        public string Notes { get; set; }

        [Required]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}