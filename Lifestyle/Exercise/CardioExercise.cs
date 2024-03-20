using Lifestyle.Class;
using Lifestyle.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lifestyle.Exercise
{
    public class CardioExercise : Exercise
    {
        public CardioExercise(int id, string name, int durationInMinutes, ExerciseType type, UserBase userId) : base(id, name, durationInMinutes, type, userId)
        {
        }

        public override void DoExercise()
        {
            Console.WriteLine($"Performing Cardio Exercise {Name} for {DurationInMinutes} minutes");
        }
    }
}
