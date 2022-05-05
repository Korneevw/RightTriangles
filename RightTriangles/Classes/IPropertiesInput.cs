using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public interface IPropertiesInput
    {
        public int DecimalAccuracy { get; }
        public decimal Increment { get; }
        public Size TotalControlSize { get; }
        public event Action? AnyValueChanged;
        public void UpdateDecimalAccuracy();
    }
}
