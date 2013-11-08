using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters."),
        MinLength(2, ErrorMessage = "Name must be less than 2 characters.")]
        public string Name { get; set; }

        public virtual List<Meal> Meals { get; set; }
        public virtual List<Activity> Activities { get; set; }
        public virtual List<Hydration> Hydrations { get; set; }
    }
}
