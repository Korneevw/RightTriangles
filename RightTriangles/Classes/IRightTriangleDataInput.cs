using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal interface IRightTriangleDataInput
    {
        public RightTriangleData InputData { get; }
        public event Action? AnyValueChanged;
    }
}
