using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal abstract class BuildModeCondition : IBuildModeCondition
    {
        protected RightTriangleData Data;
        public BuildModeCondition(RightTriangleData data) => Data = data;
        public abstract IBuildMode? CheckCondition();
    }
}
