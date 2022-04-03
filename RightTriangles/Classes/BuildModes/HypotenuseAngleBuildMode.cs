using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class HypotenuseAngleBuildMode : IBuildModeConditionContaining
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.Hypotenuse > 0 && data.AngleAlpha > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double hypotenuse = data.Hypotenuse;
            double adjacentLeg = Math.Cos(data.AngleAlpha) * data.Hypotenuse;
            double oppositeLeg = Math.Sin(data.AngleAlpha) * data.Hypotenuse;
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
