using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal interface IRightTriangleDrawer
    {
        public void Draw(RightTriangleData data, Graphics g, Point drawPosition);
        public void DrawInRatios(RightTriangleData data, Graphics g, Point drawPosition, int size);
    }
}
