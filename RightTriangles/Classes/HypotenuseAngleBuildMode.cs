using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class HypotenuseAngleBuildMode : BuildMode
    {
        public HypotenuseAngleBuildMode(RightTriangleData data) : base(data) { }
        public override RightTriangleData Build()
        {
            RightTriangleData newData = new RightTriangleData()
            {
                Hypotenuse = Data.Hypotenuse,
                AdjacentLeg = Math.Cos(Data.AngleAlpha) * Data.Hypotenuse,
                OppositeLeg = Math.Sin(Data.AngleAlpha) * Data.Hypotenuse,
                AngleAlpha = Data.AngleAlpha,
                AngleBeta = Math.PI / 2 - Data.AngleAlpha
            };
            return newData;
        }
    }
}
