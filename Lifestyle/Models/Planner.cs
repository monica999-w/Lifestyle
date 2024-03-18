
#define DEBUG
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
    public delegate void MealOperation(Meal.Meal meal);

    //extension methods
    public static class MealExtensions
    {
        public static void DoubleCalories(this IEnumerable<Meal.Meal> meals)
        {
            foreach (var meal in meals)
            {
                meal.Nutrients.Calories *= 2;
            }
        }
    }

    public class Planner : IEnumerable<object> 
    {
    
            private IExerciseRepository<Exercise.Exercise> exerciseRepository;
            private IMealRepository<Meal.Meal> mealRepository;

       
            public Planner()
            {
                exerciseRepository = new ExerciseRepository();
                mealRepository = new MealRepository();
            }


            // throws exceptions​
            public void AddExercise(Exercise.Exercise exercise)
            {
#if DEBUG
    Console.WriteLine("Debug mode is enabled.");
#endif

            if (exercise == null)
            {
                throw new ArgumentNullException("Exercise cannot be null.");
            }

            try
                {
                    
                    exerciseRepository.Add(exercise);
                   
                }
                catch (ArgumentNullException ex)
                {
                    // Log the exception
                    Console.WriteLine($"ArgumentNullException caught: {ex.Message}");

                    // Rethrow the exception
                    throw;
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


        //delegate
        /* public void ApplyOperationOnMeals(string mealName, MealOperation operation)
         {

             foreach (var meal in mealRepository.GetAll(mealName))
             {
                 operation(meal);
             }
         }*/

        //anonymous
        /* public void ApplyOperationOnMeals(string mealName, Action<Meal.Meal> operation)
        {
            

            foreach (var meal in mealRepository.GetAll(mealName))
            {
                operation(meal);
            }
        }*/

        public void ApplyOperationOnMeals(string mealName, Action<IEnumerable<Meal.Meal>> operation)
        {
            var meals = mealRepository.GetAll(mealName);
            operation(meals);
        }


        public IEnumerable<string> GetMealNamesWithCaloriesGreaterThan(int calories)
        {
            //  Where pentru a filtra mesele
            return mealRepository.GetAllMealNames().Where(mealName =>
            {
                return mealRepository.GetAll(mealName).Any(meal => meal.Nutrients.Calories > calories);
            });
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