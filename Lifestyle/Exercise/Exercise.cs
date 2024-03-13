using Lifestyle.Enumeration;
using Lifestyle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Exercise
{
    public abstract class Exercise : IExercise
    {
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public ExerciseType Type { get; set; }

        public Exercise(string name, int durationInMinutes, ExerciseType type)
        {
            Name = name;
            DurationInMinutes = durationInMinutes;
            Type = type;
        }

        public abstract void DoExercise();
    }
}
