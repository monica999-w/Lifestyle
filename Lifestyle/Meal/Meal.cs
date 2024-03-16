using Lifestyle.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Meal
{
    public class Meal
    {
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public Nutrients Nutrients { get; set; }

        public Meal(string name,MealType mealType, Nutrients nutrients)
        {
            Name = name;
            MealType = mealType;
            Nutrients = nutrients;
        }
    }
}
