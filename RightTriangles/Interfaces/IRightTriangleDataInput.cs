using System;
using System.Collections.Generic;
using System.Linq;
namespace RightTriangles
{
    public interface IRightTriangleDataInput
    {
        public RightTriangleData InputData { get; }
        public Size Size { get; }
        public event Action? AnyValueChanged;
        public event Action? ResetButtonClick;
        public void UpdateDecimalAccuracy();
        public void UpdateIncrement();
    }
}
