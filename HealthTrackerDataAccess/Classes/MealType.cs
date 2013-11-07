using System.ComponentModel.DataAnnotations;

namespace HealthTracker.DataAccess.Classes
{
    public enum MealType
    {
        Breakfast,

        [Display(Name = "Mid-Morning")]
        MidMorning,
        Lunch,
        [Display(Name = "Mid-Afternoon")]
        MidAfternoon,
        Dinner,
        Snack,
        Brunch,
        Other
    }
}