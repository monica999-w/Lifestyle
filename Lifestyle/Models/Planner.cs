
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestyle.Class;
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
    
            private IRepository<Exercise.Exercise> exerciseRepository;
            private IMealRepository<Meal.Meal> mealRepository;
            private IRepository<UserProfile> userRepository;

       
            public Planner()
            {
                exerciseRepository = new ExerciseRepository();
                mealRepository = new MealRepository();
                userRepository = new UserRepository();
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

        //join
        public void JoinUsersAndExercises(List<UserProfile> users, List<Exercise.Exercise> exercises)
        {
            var result = exercises.Join(users,
                                        exercise => exercise.UserId,
                                        user => user,
                                        (exercise, user) => new { ExerciseName = exercise.Name, UserName = user.Username }
                                     );

            Console.WriteLine("Join Example: ");
            foreach (var item in result)
            {
                Console.WriteLine($"User: {item.UserName} - Exercise: {item.ExerciseName}");
            }
        }
        //groupJoin
        public void GroupJoinUsersAndExercises(List<UserProfile> users, List<Exercise.Exercise> exercises)
        {
            var result = users.GroupJoin(exercises,
                                         user => user,
                                         exercise => exercise.UserId,
                                         (user, userExercises) => new
                                         {
                                             User = user,
                                             Exercises = userExercises.ToList()
                                         });

            Console.WriteLine("GroupJoin Example: ");
            foreach (var item in result)
            {
                Console.WriteLine($"User: {item.User.Username}");
                foreach (var exercise in item.Exercises)
                {
                    Console.WriteLine($" - Exercise: {exercise.Name}");
                }
            }
        }

        //GroupBy
        public void GroupExercisesByUser(List<UserProfile> users, List<Exercise.Exercise> exercises)
        {
            var result = from user in users
                         join exercise in exercises on user equals exercise.UserId into exerciseGroup
                         select new
                         {
                             User = user,
                             Exercises = exerciseGroup.ToList()
                         };

            Console.WriteLine("GroupBy Example: ");
            foreach (var item in result)
            {
                Console.WriteLine($"User: {item.User.Username}");
                foreach (var exercise in item.Exercises)
                {
                    Console.WriteLine($" - Exercise: {exercise.Name}");
                }
            }
        }

        //Concat
        public void ConcatenateExerciseLists(List<Exercise.Exercise> firstList, List<Exercise.Exercise> secondList)
        {
            var concatenatedList = firstList.Concat(secondList);

            Console.WriteLine("Concatenated Exercise List: ");
            foreach (var exercise in concatenatedList)
            {
                Console.WriteLine($"Exercise: {exercise.Name}");
            }
        }
        //Union
        public void UnionExerciseLists(List<Exercise.Exercise> firstList, List<Exercise.Exercise> secondList)
        {
            var union = firstList.Union(secondList);
            Console.WriteLine("Union exercise List : ");
            foreach(var exercise in union)
            {
                Console.WriteLine($"Exercise : {exercise.Name}");
            }
        }


        public List<Exercise.Exercise> CombineExerciseLists(List<Exercise.Exercise> list1, List<Exercise.Exercise> list2)
        {
            var combinedList = list1.Union(list2).ToList();
            return combinedList;
        }



        public IEnumerable<Exercise.Exercise> GetExercisesEnumerable(List<Exercise.Exercise> exercises)
        {
            // Realizăm o operație LINQ pentru a filtra sau proiecta lista de exerciții, apoi returnăm rezultatul ca un obiect IEnumerable<Exercise>
            var filteredExercises = exercises.Where(e => e.DurationInMinutes > 30).AsEnumerable();

            return filteredExercises;
        }

        public int CalculateTotalDuration(List<Exercise.Exercise> exercises)
        {
            int totalDuration = exercises.Sum(e => e.DurationInMinutes);
            return totalDuration;
        }

        //Max
        public int CalculateMaxDuration(List<Exercise.Exercise> exercise)
        {
            int MaxDuration = exercise.Max(e => e.DurationInMinutes);
            return MaxDuration;
        }

        //Any
        public bool CheckExerciseExists(List<Exercise.Exercise> exercises, string exerciseName)
        {
            return exercises.Any(e => e.Name == exerciseName);
        }

        //all
        public bool ReturnExerciseExist(List<Exercise.Exercise> exercises, string exerciseName)
        {
            return exercises.All(e => e.Name == exerciseName);
        }

        //elementAtOrDefault
        public Exercise.Exercise GetExerciseAtIndex(List<Exercise.Exercise> exercises, int index)
        {
            return exercises.ElementAtOrDefault(index);
        }

        //lastOrDefault
        public Exercise.Exercise GetLastExercise(List<Exercise.Exercise> exercises)
        {
            return exercises.LastOrDefault();
        }

        //repeat
        public IEnumerable<Exercise.Exercise> GenerateRepeatedExercises(Exercise.Exercise exercise, int count)
        {
            return Enumerable.Repeat(exercise, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}