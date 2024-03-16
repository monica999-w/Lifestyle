// See https://aka.ms/new-console-template for more information
using Lifestyle.Class;
using Lifestyle.Enums;
using Lifestyle.Exercise;
using Lifestyle.Meal;
using Lifestyle.Models;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        //user
        UserProfile profile1 = new UserProfile("user1", "password", "user.test@example.com", 180, 80);

        // Add an exercise to the planner
        profile1.Planner.AddExercise(new CardioExercise("Running", 30));
        profile1.Planner.AddExercise(new CardioExercise("Add", 130));

        // profile1.Planner.AddExercise(null);

        // Add a meal to the planner
        Nutrients breakfastNutrients = new Nutrients
        {
            Calories = 300,
            Protein = 20,
            Fat = 10,
            Carbohydrates = 40
        };
        Meal breakfast = new Meal("Eggs Benedict",MealType.Breakfast, breakfastNutrients);
        Meal dinner = new Meal("nimic",MealType.Dinner, breakfastNutrients);
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

        //  meals 
        Console.WriteLine($"Meals for user {profile1.Username} :");
        foreach (var planItem in profile1.Planner)
        {
            if (planItem is Meal meal)
            {
                string mealType = meal.MealType switch
                {
                    MealType.Breakfast => "Breakfast",
                    MealType.Lunch => "Lunch",
                    MealType.Dinner => "Dinner",
                    _ => "Unknown"
                };

                Console.WriteLine($"- {mealType}: {meal.Name}, Calories: {meal.Nutrients.Calories} kcal");
            }
        }
    }
}

