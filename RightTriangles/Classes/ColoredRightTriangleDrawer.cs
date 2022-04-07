using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class ColoredRightTriangleDrawer : IRightTriangleDrawer
    {
        private Font _font;
        private Pen _adjLegPen;
        private Pen _oppLegPen;
        private Pen _hypPen;
        private IRightTriangleValidator _validator = new RightTriangleValidator();
        public ColoredRightTriangleDrawer(Font font, Pen adjLegPen, Pen oppLegPen, Pen hypPen)
        {
            _font = font;
            _adjLegPen = adjLegPen;
            _oppLegPen = oppLegPen;
            _hypPen = hypPen;
        }
        public ColoredRightTriangleDrawer(Font font, Pen adjLegPen, Pen oppLegPen, Pen hypPen, IRightTriangleValidator validator) : this(font, adjLegPen, oppLegPen, hypPen)
        {
            _validator = validator;
        }
        public void Draw(RightTriangleData data, Graphics g, Point drawPosition)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid."); // May affect perfomance?
            g.DrawLine(_adjLegPen, new PointF(drawPosition.X, drawPosition.Y + (float)data.OppositeLeg), new PointF(drawPosition.X + (float)data.AdjacentLeg, drawPosition.Y + (float)data.OppositeLeg));
            g.DrawLine(_oppLegPen, new PointF(drawPosition.X + (float)data.AdjacentLeg, drawPosition.Y + (float)data.OppositeLeg), new PointF(drawPosition.X + (float)data.AdjacentLeg, drawPosition.Y));
            g.DrawLine(_hypPen, new PointF(drawPosition.X, drawPosition.Y + (float)data.OppositeLeg), new PointF(drawPosition.X + (float)data.AdjacentLeg, drawPosition.Y));
            g.DrawString("b", _font, new SolidBrush(_adjLegPen.Color), new PointF(drawPosition.X + (float)data.AdjacentLeg / 2 - _font.Size / 2, drawPosition.Y + (float)data.OppositeLeg));
            g.DrawString("a", _font, new SolidBrush(_oppLegPen.Color), new PointF(drawPosition.X + (float)data.AdjacentLeg, drawPosition.Y + (float)data.OppositeLeg / 2 - _font.Height / 2));
            g.DrawString("c", _font, new SolidBrush(_hypPen.Color), new PointF(drawPosition.X + (float)data.AdjacentLeg / 2 - _font.Size, drawPosition.Y + (float)data.OppositeLeg / 2 - _font.Height));
        }
    }
}
