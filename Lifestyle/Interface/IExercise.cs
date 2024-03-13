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
        string Name { get; }
        int DurationInMinutes { get; }
        ExerciseType Type { get; }
        void DoExercise();
    }
}
