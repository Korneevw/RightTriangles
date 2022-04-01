using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal abstract class BuildMode : IBuildMode
    {
        protected RightTriangleData Data;
        public BuildMode(RightTriangleData data) => Data = data;
        public abstract RightTriangleData Build();
    }
}
