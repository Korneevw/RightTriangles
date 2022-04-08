using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class AdjacentLegOppositeLegBuildMode : IBuildMode
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.AdjacentLeg > 0 && data.OppositeLeg > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double angleAlpha = Math.Atan(data.OppositeLeg / data.AdjacentLeg);
            double hypotenuse = Math.Sqrt(Math.Pow(data.AdjacentLeg, 2) + Math.Pow(data.OppositeLeg, 2));
            double adjacentLeg = data.AdjacentLeg;
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
