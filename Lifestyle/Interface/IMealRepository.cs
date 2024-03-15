using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Interface
{
    public interface IMealRepository<T>
    {
        void Add(string mealName, T meal);
        void Remove(string mealName, T meal);
        IEnumerable<T> GetAll(string mealName);
        public IEnumerable<string> GetAllMealNames();
    }
}
