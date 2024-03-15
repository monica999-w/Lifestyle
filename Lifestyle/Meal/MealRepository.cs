using Lifestyle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Meal
{

    public class MealRepository : IMealRepository<Meal>
    {
        private Dictionary<string, List<Meal>> mealsPerDay;

        public MealRepository()
        {
            mealsPerDay = new Dictionary<string, List<Meal>>();
        }

        public void Add(string mealName, Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal));

            if (!mealsPerDay.ContainsKey(mealName))
                mealsPerDay[mealName] = new List<Meal>();

            mealsPerDay[mealName].Add(meal);
        }

        public void Remove(string mealName, Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal));

            if (mealsPerDay.ContainsKey(mealName))
                mealsPerDay[mealName].Remove(meal);
        }

        public IEnumerable<Meal> GetAll(string mealName)
        {
            if (mealsPerDay.ContainsKey(mealName))
                return mealsPerDay[mealName];

            return new List<Meal>();
        }

        public IEnumerable<string> GetAllMealNames()
        {
            return mealsPerDay.Keys;
        }
    }
}
