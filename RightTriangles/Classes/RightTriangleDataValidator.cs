using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class RightTriangleDataValidator
    {
        private RightTriangleData? _data;
        public RightTriangleDataValidator(RightTriangleData? data) => _data = data;
        public bool Validate()
        {
            if (_data is null) return false;
            bool sides =
                _data.Hypotenuse < (_data.AdjacentLeg + _data.OppositeLeg)
                && _data.AdjacentLeg < (_data.Hypotenuse + _data.OppositeLeg)
                && _data.OppositeLeg < (_data.Hypotenuse + _data.AdjacentLeg);
            bool hypotenuse =
                Math.Pow(_data.Hypotenuse, 2) == (Math.Pow(_data.AdjacentLeg, 2) + Math.Pow(_data.OppositeLeg, 2));
            bool angles =
                (_data.AngleAlpha + _data.AngleBeta) == (Math.PI / 2);
            return sides && hypotenuse && angles;
        }
    }
}
