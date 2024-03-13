// See https://aka.ms/new-console-template for more information
using Lifestyle.Class;
using Lifestyle.Exercise;
using Lifestyle.Meal;
using Lifestyle.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        //user
        UserProfile profile1 = new UserProfile("user1", "password", "user.test@example.com", 180, 80);

        //  add exercise
        if (profile1.Planner is Planner)
        {
            Planner planner = profile1.Planner as Planner;
            if (planner != null)
            {
                planner.AddExercise(new CardioExercise("Alerare", 30));
            }
        }

        // add meal
        Nutrients breakfastNutrients = new Nutrients
        {
            Calories = 300,
            Protein = 20,
            Fat = 10,
            Carbohydrates = 40
        };
        Meal breakfast = new Meal("Eggs Benedict", breakfastNutrients);

        if (profile1.Planner is Planner)
        {
            Planner planner = profile1.Planner as Planner;
            if (planner != null)
            {
                planner.AddMeal("breakfast", breakfast);
            }
        }

        
        if (profile1.Planner is Planner)
        {
            Planner planner = profile1.Planner as Planner;
            if (planner != null)
            {
                foreach (var exercise in planner.Exercises)
                {
                    Console.WriteLine($"User {profile1.Username} will do {exercise.Name} for {exercise.DurationInMinutes} minutes");
                }
            }
        }

        
        if (profile1.Planner is Planner)
        {
            Planner planner = profile1.Planner as Planner;
            if (planner != null)
            {
                foreach (var mealsPair in planner.MealsPerDay)
                {
                    Console.WriteLine($"Meal: {mealsPair.Key}");
                    foreach (var meal in mealsPair.Value)
                    {
                        Console.WriteLine($"{meal.Name}:");
                        Console.WriteLine($"Calories: {meal.Nutrients.Calories} kcal");
                        Console.WriteLine($"Protein: {meal.Nutrients.Protein}g");
                        Console.WriteLine($"Fat: {meal.Nutrients.Fat}g");
                        Console.WriteLine($"Carbohydrates: {meal.Nutrients.Carbohydrates}g");
                    }
                }
            }
        }
    }
}
