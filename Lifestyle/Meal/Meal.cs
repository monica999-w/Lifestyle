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
        public Nutrients Nutrients { get; set; }

        public Meal(string name, Nutrients nutrients)
        {
            Name = name;
            Nutrients = nutrients;
        }
    }
}
