using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEG45.Models;

namespace SEG45.Controllers
{
    public class HomeController : Controller
    {
        public static IList<string> BackExercises = new List<string>
        {
            "Kettlebell Swings",
            "Barbell Deadlift",
            "Barbell Bent-Over Row",
            "Pull-Up",
            "Dumbbell Single Arm Row",
            "Chest-Supported Dumbbell Row",
            "Inverted Row",
            "Lat Pull-Downs",
            "Good morning",
            "Wide dumbbell row",
            "Hyperextension (yoga ball)",
            "Renegade dumbbell row",
            "Woodchop"
        };

        public static IList<string> ChestExercises = new List<string>
        {
            "Barbell benchpress",
            "Flat bench dumbbell press",
            "Incline barbell press",
            "Machine decline press",
            "Seated machine chest press",
            "Incline dumbbell press",
            "Dips for chest",
            "Incline bench cable fly",
            "Incline dumbbell pull over",
            "Pec deck machine"
        };

        public static IList<string> LegExercises = new List<string>
        {
            "Squats",
            "Hack squats",
            "Deadlift",
            "Bulgarian split squat",
            "Dumbbell lunge",
            "Leg press",
            "Romanian deadlift",
            "Step ups",
            "Leg extensions",
            "Leg curls",
            "Standing calf raises"
        };

        public static IList<string> ArmExercises = new List<string>
        {
            "Close grip bench press",
            "Raised leg seated dips",
            "Bicep curl standing",
            "Bicep curl - seated - elbow planted",
            "21s",
            "Ez bar curl",
            "Hammer curls",
            "Skull crushers",
            "Tricep pulldown"
        };

        public static IList<string> ShoulderExercises = new List<string>
        {
            "Seated overhead dumbbell press",
            "Standing shoulder press",
            "Seated barbell row",
            "Plate press out",
            "Lateral raises",
            "Shoulder shrugs",
            "Rear delt flys",
            "Dumbbell incline row",
            "Arnie press",
            "Turkish get up"
        };

        public static IList<string> CardioExercises = new List<string>
        {
            "Sprint intervals",
            "Box jumps",
            "Full burpees",
            "Rowing machine",
            "Cart push"
        };

        public static IList<string> Breakfasts = new List<string>
        {

        };

        public static IList<string> Lunches = new List<string>
        {

        };

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate()
        {
            var planModel = new PlanModel();

            var backIndexes = new List<int>();
            var armsIndexes = new List<int>();
            var shouldersIndexes = new List<int>();
            var chestIndexes = new List<int>();
            var legsIndexes = new List<int>();
            var cardioIndexes = new List<int>();

            while (backIndexes.Count < 3)
            {
                var randIndex = GetRandIndex(BackExercises);

                if (!backIndexes.Contains(randIndex))
                {
                    backIndexes.Add(randIndex);
                }
            }

            while (armsIndexes.Count < 2)
            {
                var randIndex = GetRandIndex(ArmExercises);

                if (!armsIndexes.Contains(randIndex))
                {
                    armsIndexes.Add(randIndex);
                }
            }

            while (shouldersIndexes.Count < 2)
            {
                var randIndex = GetRandIndex(ShoulderExercises);

                if (!shouldersIndexes.Contains(randIndex))
                {
                    shouldersIndexes.Add(randIndex);
                }
            }

            while (chestIndexes.Count < 3)
            {
                var randIndex = GetRandIndex(ChestExercises);

                if (!chestIndexes.Contains(randIndex))
                {
                    chestIndexes.Add(randIndex);
                }
            }

            while (legsIndexes.Count < 5)
            {
                var randIndex = GetRandIndex(LegExercises);

                if (!legsIndexes.Contains(randIndex))
                {
                    legsIndexes.Add(randIndex);
                }
            }

            while (cardioIndexes.Count < 3)
            {
                var randIndex = GetRandIndex(CardioExercises);

                if (!cardioIndexes.Contains(randIndex))
                {
                    cardioIndexes.Add(randIndex);
                }
            }

            foreach (var back in backIndexes)
            {
                planModel.BackAndArms.Add(BackExercises[back]);
            }

            foreach (var arm in armsIndexes)
            {
                planModel.BackAndArms.Add(ArmExercises[arm]);
            }

            foreach (var chest in chestIndexes)
            {
                planModel.ChestAndShoulders.Add(ChestExercises[chest]);
            }

            foreach (var shoulder in shouldersIndexes)
            {
                planModel.ChestAndShoulders.Add(ShoulderExercises[shoulder]);
            }

            foreach (var leg in legsIndexes)
            {
                planModel.Legs.Add(LegExercises[leg]);
            }

            foreach (var car in cardioIndexes)
            {
                planModel.Cardio.Add(CardioExercises[car]);
            }

            return this.View(planModel);
        }

        private int GetRandIndex(IList<string> exercises)
        {
            var rand = new Random();
            return rand.Next(0, exercises.Count);
        }
    }
}
