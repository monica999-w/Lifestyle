using Lifestyle.Class;
using Lifestyle.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Exercise
{
    public class YogaExercise : Exercise
    {
        public YogaExercise(string name, int durationInMinutes) : base(name, durationInMinutes, ExerciseType.Yoga)
        {
        }
        public override void DoExercise()
        {
            Console.WriteLine($"Performing Yoga Exercise {Name} for {DurationInMinutes} minutes");
        }


    }
}
