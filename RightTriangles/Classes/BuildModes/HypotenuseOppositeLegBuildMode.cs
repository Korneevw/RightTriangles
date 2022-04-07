using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class HypotenuseOppositeLegBuildMode : IBuildMode
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.Hypotenuse > 0 && data.OppositeLeg > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double hypotenuse = data.Hypotenuse;
            double angleAlpha = Math.Asin(data.OppositeLeg / data.Hypotenuse);
            double adjacentLeg = Math.Cos(angleAlpha) * data.Hypotenuse;
            double oppositeLeg = data.OppositeLeg;
            double angleBeta = Math.PI / 2 - angleAlpha;
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
