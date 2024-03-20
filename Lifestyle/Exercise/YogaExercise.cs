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
        public YogaExercise(int id, string name, int durationInMinutes, ExerciseType type, UserBase userId) : base(id, name, durationInMinutes, type, userId)
        {
        }

        public override void DoExercise()
        {
            Console.WriteLine($"Performing Yoga Exercise {Name} for {DurationInMinutes} minutes");
        }


    }
}
