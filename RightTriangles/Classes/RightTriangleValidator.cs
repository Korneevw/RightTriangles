using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class RightTriangleValidator
    {
        public bool Validate(RightTriangleData data)
        {
            if (data is null) return false;
            bool sides =
                Math.Round(data.Hypotenuse, Properties.DecimalAccuracy) < Math.Round(data.AdjacentLeg + data.OppositeLeg, Properties.DecimalAccuracy)
                && Math.Round(data.AdjacentLeg, Properties.DecimalAccuracy) < Math.Round(data.Hypotenuse + data.OppositeLeg, Properties.DecimalAccuracy)
                && Math.Round(data.OppositeLeg, Properties.DecimalAccuracy) < Math.Round(data.Hypotenuse + data.AdjacentLeg, Properties.DecimalAccuracy);
            bool hypotenuse =
                Math.Round(Math.Pow(data.Hypotenuse, 2), Properties.DecimalAccuracy) == Math.Round(Math.Pow(data.AdjacentLeg, 2) + Math.Pow(data.OppositeLeg, 2), Properties.DecimalAccuracy);
            bool angles =
                Math.Round(data.AngleAlpha + data.AngleBeta, Properties.DecimalAccuracy) == Math.Round(Math.PI / 2, Properties.DecimalAccuracy);
            return sides && hypotenuse && angles;
        }
    }
}
