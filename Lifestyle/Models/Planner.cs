using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestyle.Exercise;
using Lifestyle.Interface;
using Lifestyle.Meal;

namespace Lifestyle.Models
{
    public class Planner : IEnumerable<object> 
    {
        private IRepository<Exercise.Exercise> exerciseRepository;
        private IMealRepository<Meal.Meal> mealRepository;
      

        public Planner()
        {
            exerciseRepository = new ExerciseRepository();
            mealRepository = new MealRepository();
        }


        // throws exceptions​
        public void AddExercise(Exercise.Exercise exercise)
        {

            try
            {
                if (exercise == null)
                {
                    throw new ArgumentNullException("Exercise cannot be null.");
                }

                exerciseRepository.Add(exercise);
                Console.WriteLine("Exercise added successfully.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                // Handle ArgumentNullException
            }
            catch (InvalidExerciseException ex)
            {
                Console.WriteLine($"InvalidExerciseException: {ex.Message}");
                // Handle InvalidExerciseException
            }
            finally
            {
                // Clean up code (if any)
                Console.WriteLine("AddExercise method execution completed.");
            }
        }

        // Method with optional parameters and named arguments
        //overloading
        public void AddExercise(string name = "Exercise", int durationInMinutes = 30)
        {
            Console.WriteLine($"Adding exercise: {name}, Duration: {durationInMinutes} minutes");

        }

        public void RemoveExercise(Exercise.Exercise exercise)
        {
            exerciseRepository.Remove(exercise);
        }

        public void AddMeal(string mealName, Meal.Meal meal)
        {
           
            mealRepository.Add(mealName, meal);
        }

        public void RemoveExercise(string mealName, Meal.Meal meal)
        {
            mealRepository.Remove(mealName, meal);
        }


        public IEnumerator<object> GetEnumerator()
        {
            foreach (var exercise in exerciseRepository.GetAll())
            {
                yield return exercise;
            }

            foreach (var mealName in mealRepository.GetAllMealNames())
            {
                foreach (var meal in mealRepository.GetAll(mealName))
                {
                    yield return meal;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
