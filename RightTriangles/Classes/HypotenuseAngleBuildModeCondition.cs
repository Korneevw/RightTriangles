using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class HypotenuseAngleBuildModeCondition : BuildModeCondition
    {
        public HypotenuseAngleBuildModeCondition(RightTriangleData data) : base(data) { }
        public override IBuildMode? CheckCondition()
        {
            if (Data.AngleAlpha > 0 && Data.Hypotenuse > 0)
            {
                return new HypotenuseAngleBuildMode(Data);
            }
            return null;
        }
    }
}
