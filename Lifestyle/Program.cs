// See https://aka.ms/new-console-template for more information
using Lifestyle.Class;
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

        // Add a meal to the planner
        Nutrients breakfastNutrients = new Nutrients
        {
            Calories = 300,
            Protein = 20,
            Fat = 10,
            Carbohydrates = 40
        };
        Meal breakfast = new Meal("Eggs Benedict", breakfastNutrients);
        profile1.Planner.AddMeal("breakfast", breakfast);

        // exercises 
        Console.WriteLine($"Exercises for user {profile1.Username}:");
        foreach (var exercise in profile1.Planner)
        {
            if (exercise is Exercise)
            {
                Console.WriteLine($"- {((Exercise)exercise).Name}, Duration: {((Exercise)exercise).DurationInMinutes} minutes");
            }
        }

        //  meals 
        Console.WriteLine($"Meals for user {profile1.Username}:");
        foreach (var meal in profile1.Planner)
        {
            if (meal is Meal)
            {
                Console.WriteLine($"- {((Meal)meal).Name}, Calories: {((Meal)meal).Nutrients.Calories} kcal");
            }
        }
    }
}

