using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class OppositeLegAngleBuildMode : IBuildMode
    {
        public bool CheckCondition(RightTriangleData data)
        {
            if (data.OppositeLeg > 0 && data.AngleAlpha > 0)
            {
                return true;
            }
            return false;
        }
        public RightTriangleData Build(RightTriangleData data)
        {
            double adjacentLeg = data.OppositeLeg / Math.Tan(data.AngleAlpha);
            double hypotenuse = adjacentLeg / Math.Cos(data.AngleAlpha);
            double oppositeLeg = data.OppositeLeg;
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
