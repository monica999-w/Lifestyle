using Lifestyle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Exercise
{
    public class ExerciseRepository : IExerciseRepository<Exercise>
    {
        private List<Exercise> exercises;

        public ExerciseRepository()
        {
            exercises = new List<Exercise>();
        }

        public void Add(Exercise entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            exercises.Add(entity);
        }

        public void Remove(Exercise entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            exercises.Remove(entity);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return exercises;
        }

    }

}
