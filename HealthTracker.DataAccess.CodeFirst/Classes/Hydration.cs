using System;
using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public class Hydration
    {
        public int HydrationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Hydration amount must be between 0 - 20.")]
        public int Count { get; set; }

        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
