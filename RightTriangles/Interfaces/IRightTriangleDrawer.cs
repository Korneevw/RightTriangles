using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public interface IRightTriangleDrawer
    {
        public DrawerConfiguration Configuration { get; set; }
        public void Draw(RightTriangleData data, Graphics g, Point drawPosition);
        public void DrawInRatios(RightTriangleData data, Graphics g, Point drawPosition);
        public Size GetTriangleDrawingSize(RightTriangleData data);
        public Size GetTriangleDrawingSizeRatios(RightTriangleData data);
    }
}
