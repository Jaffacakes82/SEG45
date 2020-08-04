using System.Collections.Generic;

namespace SEG45.Models
{
    public class PlanModel
    {
        public IList<string> BackAndArms { get; set; } = new List<string>();
        public IList<string> ChestAndShoulders { get; set; } = new List<string>();
        public IList<string> Legs { get; set; } = new List<string>();
        public IList<string> Cardio { get; set; } = new List<string>();
        public IList<Food> Food { get; set; } = new List<Food>();
    }

    public class Food
    {
        public string Day { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
    }
}
