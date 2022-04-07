using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal interface IBuildMode
    {
        public RightTriangleData Build(RightTriangleData data);
        public bool CheckCondition(RightTriangleData data);
    }
}
