using Lifestyle.Class;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public ExerciseType Type { get; set; }
        public UserBase UserId { get; set; }

        public Exercise(int id,string name, int durationInMinutes, ExerciseType type,UserBase userId)
        {
            Id = id;
            Name = name;
            DurationInMinutes = durationInMinutes;
            Type = type;
            UserId = userId;
        }

        public abstract void DoExercise();
    }
}
