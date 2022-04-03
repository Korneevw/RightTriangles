using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class AdjacentLegAngleBuildMode : IBuildModeConditionContaining
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.AdjacentLeg > 0 && data.AngleAlpha > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double hypotenuse = data.AdjacentLeg / Math.Cos(data.AngleAlpha);
            double adjacentLeg = data.AdjacentLeg;
            double oppositeLeg = Math.Tan(data.AngleAlpha) * data.AdjacentLeg;
            double angleAlpha = data.AngleAlpha;
            double angleBeta = Math.PI / 2 - data.AngleAlpha;
            RightTriangleData newData = new RightTriangleData()
            {
                Hypotenuse = hypotenuse,
                AdjacentLeg = adjacentLeg,
                OppositeLeg = oppositeLeg,
                AngleAlpha = angleAlpha,
                AngleBeta = angleBeta
            };
            return newData;
        }
    }
}
