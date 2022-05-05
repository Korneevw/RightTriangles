using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public class HypotenuseAdjacentLegBuildMode : IBuildMode
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.Hypotenuse > 0 && data.AdjacentLeg > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double hypotenuse = data.Hypotenuse;
            double adjacentLeg = data.AdjacentLeg;
            double angleAlpha = Math.Acos(data.AdjacentLeg / data.Hypotenuse);
            double oppositeLeg = Math.Sin(angleAlpha) * data.Hypotenuse;
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
