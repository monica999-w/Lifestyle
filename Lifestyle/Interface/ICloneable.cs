using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Interface
{
    public interface ICloneable<T>
    {
        T Clone();
    }
}
