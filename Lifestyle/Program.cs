// See https://aka.ms/new-console-template for more information
using Lifestyle.Class;
using Lifestyle.Enumeration;
using Lifestyle.Enums;
using Lifestyle.Exercise;
using Lifestyle.Interface;
using Lifestyle.Meal;
using Lifestyle.Models;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

class Program
{
    static void Main(string[] args)
    {

             Planner planner = new Planner();
             
            //user
            UserProfile profile1 = new UserProfile("user1", "password", "user.test@example.com", 180, 80);

            // Add an exercise to the planner
          //  profile1.Planner.AddExercise(new CardioExercise(1,"Running", 30,ExerciseType.Cardio,profile1));
          //  profile1.Planner.AddExercise(new CardioExercise(2,"Add", 130,ExerciseType.Yoga,profile1));

            // profile1.Planner.AddExercise(null);

            // Add a meal to the planner
            Nutrients breakfastNutrients = new Nutrients
            {
                Calories = 300,
                Protein = 20,
                Fat = 10,
                Carbohydrates = 40
            };

            Meal breakfast = new Meal("Eggs Benedict", MealType.Breakfast, breakfastNutrients);
            Meal dinner = new Meal("nimic", MealType.Dinner, breakfastNutrients);
            profile1.Planner.AddMeal("breakfast", breakfast);
            profile1.Planner.AddMeal("dinner", dinner);


            // exercises 
            Console.WriteLine($"Exercises for user {profile1.Username}:");
            foreach (var planItem in profile1.Planner)
            {
                var exercise = planItem as Exercise;
                if (exercise != null)
                {
                    Console.WriteLine($"- {exercise.Name}, Duration: {exercise.DurationInMinutes} minutes");
                }
            }

        //anonymous

        /* profile1.Planner.ApplyOperationOnMeals("breakfast", delegate (Meal meal)
         {
             meal.Nutrients.Calories *= 2;
         });*/

        //lamda
        // profile1.Planner.ApplyOperationOnMeals("breakfast", meal => meal.Nutrients.Calories *= 2);

        //extension methods
        profile1.Planner.ApplyOperationOnMeals("breakfast", meals => meals.DoubleCalories());

        //Where operators
        var mealNames = profile1.Planner.GetMealNamesWithCaloriesGreaterThan(500);
        foreach (var mealName in mealNames)
        {
            Console.WriteLine(mealName);
        }

        //  meals 
        Console.WriteLine($"Meals for user {profile1.Username} :");
            foreach (var planItem in profile1.Planner)
            {
                if (planItem is Meal meal)
                {
                    Console.WriteLine($"- {meal.MealType}: {meal.Name}, Calories: {meal.Nutrients.Calories} kcal");
                }
            }


        // Advanced LINQ
        List<UserProfile> users = new List<UserProfile>();
        List<Exercise> exercises = new List<Exercise>();
        users.Add(profile1);
        exercises.Add(new CardioExercise(1, "Morning Run", 30, ExerciseType.Cardio, profile1));
        exercises.Add(new CardioExercise(2, "Weightlifting Session", 45, ExerciseType.Yoga, profile1));


        planner.JoinUsersAndExercises(users, exercises);
        planner.GroupJoinUsersAndExercises(users,exercises);
        planner.GroupExercisesByUser(users, exercises);


        List<Exercise> exercisesList = new List<Exercise>();
        Exercise exercise1 = new CardioExercise(0, "Running", 30, ExerciseType.Cardio, profile1);
        Exercise exercise2 = new YogaExercise(1, "Weightlifting", 45, ExerciseType.Yoga, profile1);
       
        exercisesList.Add(exercise1);
        exercisesList.Add(exercise2);
       

        IEnumerable<Exercise> exerciseEnumerable = planner.GetExercisesEnumerable(exercisesList);

        foreach (var exercise in exerciseEnumerable)
        {
            Console.WriteLine($"Exercise: {exercise.Name}, Duration: {exercise.DurationInMinutes} minutes");
        
        }

        int totalDuration = planner.CalculateTotalDuration(exercisesList);
        Console.WriteLine($"Total duration of exercises: {totalDuration} minutes");

        string exerciseNameToCheck = "Runening";
        bool exerciseExists = planner.CheckExerciseExists(exercisesList, exerciseNameToCheck);

        if (exerciseExists)
        {
            Console.WriteLine($"Exercise '{exerciseNameToCheck}' exists in the list.");
        }
        else
        {
            Console.WriteLine($"Exercise '{exerciseNameToCheck}' does not exist in the list.");
        }

        int indexToGet = 1; 
        Exercise exerciseAtIndex = planner.GetExerciseAtIndex(exercisesList, indexToGet);
        Exercise lastExercises = planner.GetLastExercise(exercisesList);

        if (exerciseAtIndex != null)
        {
            Console.WriteLine($"Exercise at index {indexToGet}: {exerciseAtIndex.Name}");
        }
        else
        {
            Console.WriteLine($"No exercise found at index {indexToGet}.");
        }

        int repeatCount = 5;

       
        IEnumerable<Exercise> repeatedExercises = planner.GenerateRepeatedExercises(exercise1, repeatCount);
        foreach (var repeatedExercise in repeatedExercises)
        {
            Console.WriteLine($"Repeated Exercise: {repeatedExercise.Name}, Duration: {repeatedExercise.DurationInMinutes} minutes");
        }

    }
}


