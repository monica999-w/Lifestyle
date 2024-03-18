using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Interface
{
    public interface IExerciseRepository<T> 
    {
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
    }

}
