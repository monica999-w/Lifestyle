using Lifestyle.Class;
using Lifestyle.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Interface
{
    public interface IExercise
    {
        int Id { get; }
        string Name { get; }
        int DurationInMinutes { get; }
        ExerciseType Type { get; }
        UserBase UserId { get; }
        void DoExercise();
    }
}
