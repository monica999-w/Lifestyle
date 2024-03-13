using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestyle.Exercise;

namespace Lifestyle.Models
{
    public class Planner : IEnumerable<Exercise.Exercise>
    {

        public List<Exercise.Exercise> Exercises { get; set; }
        public Dictionary<string,List<Meal.Meal>> MealsPerDay { get; set; }

        public Planner()
        {
            Exercises = new List<Exercise.Exercise>();
            MealsPerDay = new Dictionary<string,List < Meal.Meal >> ();
        }

        public void AddExercise(Exercise.Exercise exercise)
        {
            Exercises.Add(exercise);
        }

        // Method with optional parameters and named arguments
        //overloading
        public void AddExercise(string name = "Exercise", int durationInMinutes = 30)
        {
            Console.WriteLine($"Adding exercise: {name}, Duration: {durationInMinutes} minutes");

        }

        public void RemoveExercise(Exercise.Exercise exercise)
        {
            Exercises.Remove(exercise);
        }

        public void AddMeal(string mealName, Meal.Meal meal)
        {
            if (!MealsPerDay.ContainsKey(mealName))
            {
                MealsPerDay[mealName] = new List<Meal.Meal>();
            }
            MealsPerDay[mealName].Add(meal);
        }

        


        public IEnumerator<Exercise.Exercise> GetEnumerator()
        {
            return Exercises.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
