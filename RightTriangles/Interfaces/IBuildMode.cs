using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public interface IBuildMode
    {
        public RightTriangleData Build(RightTriangleData data);
        public bool CheckCondition(RightTriangleData data);
    }
}
