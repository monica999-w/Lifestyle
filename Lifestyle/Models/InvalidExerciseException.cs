using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Models
{
    public class InvalidExerciseException : Exception
    {
        public InvalidExerciseException(string message) : base(message)
        {
        }
    }
}
