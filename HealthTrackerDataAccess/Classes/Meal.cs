using System;
using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public class Meal
    {
        public int MealId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [EnumDataType(typeof(MealType))]
        public MealType Type { get; set; }

        [StringLength(100, ErrorMessage =
            "Description must be less than 100 characters.")]
        public string Description { get; set; }

        [Required]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}