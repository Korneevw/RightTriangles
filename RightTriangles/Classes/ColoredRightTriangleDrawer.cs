using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class ColoredRightTriangleDrawer : IRightTriangleDrawer
    {
        private Font _font = new Font("Georgia", 20, FontStyle.Italic);
        private Pen _adjLegPen;
        private Pen _oppLegPen;
        private Pen _hypPen;
        private IRightTriangleValidator _validator = new RightTriangleValidator();
        public ColoredRightTriangleDrawer(Pen adjLegPen, Pen oppLegPen, Pen hypPen)
        {
            _adjLegPen = adjLegPen;
            _oppLegPen = oppLegPen;
            _hypPen = hypPen;
        }
        public ColoredRightTriangleDrawer(Pen adjLegPen, Pen oppLegPen, Pen hypPen, IRightTriangleValidator validator) : this(adjLegPen, oppLegPen, hypPen)
        {
            _validator = validator;
        }
        public void Draw(RightTriangleData data, Graphics g, Point drawPosition)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid."); // May affect perfomance?
            Rectangle alphaArcRect = 
                new Rectangle(new Point((int)Math.Round(drawPosition.X - data.Hypotenuse / 8), (int)Math.Round(drawPosition.Y + data.OppositeLeg - data.Hypotenuse / 8)), 
                new Size((int)Math.Round(data.Hypotenuse / 8 * 2), (int)Math.Round(data.Hypotenuse / 8 * 2)));
            g.DrawArc( // Angle alpha arc
                Pens.Black, 
                alphaArcRect,
                -(int)(data.AngleAlpha * (180 / Math.PI)), 
                (int)(data.AngleAlpha * (180 / Math.PI)));
            Rectangle betaArcRect =
                new Rectangle(new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg - data.Hypotenuse / 8), (int)Math.Round(drawPosition.Y - data.Hypotenuse / 8)),
                new Size((int)Math.Round(data.Hypotenuse / 8 * 2), (int)Math.Round(data.Hypotenuse / 8 * 2)));
            g.DrawArc( // Angle beta arc
                Pens.Black,
                betaArcRect,
                90,
                (int)(data.AngleBeta * (180 / Math.PI)));
            g.DrawLine( // Adjacent leg
                _adjLegPen, 
                new Point(drawPosition.X, (int)Math.Round(drawPosition.Y + data.OppositeLeg)), 
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg), (int)Math.Round(drawPosition.Y + data.OppositeLeg)));
            g.DrawLine( // Opposite leg
                _oppLegPen, 
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg), (int)Math.Round(drawPosition.Y + data.OppositeLeg)), 
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg), drawPosition.Y));
            g.DrawLine( // Hypotenuse
                _hypPen, 
                new Point(drawPosition.X, (int)Math.Round(drawPosition.Y + data.OppositeLeg)), 
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg), drawPosition.Y));
            g.DrawString("b", _font, new SolidBrush(_adjLegPen.Color), // Adjacent leg
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg / 2 - _font.Size / 2), (int)Math.Round(drawPosition.Y + data.OppositeLeg)));
            g.DrawString("a", _font, new SolidBrush(_oppLegPen.Color), // Opposite leg
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg), (int)Math.Round(drawPosition.Y + data.OppositeLeg / 2 - _font.Size / 2)));
            g.DrawString("c", _font, new SolidBrush(_hypPen.Color), // Hypotenuse
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg / 2 - _font.Size / 2), (int)Math.Round(drawPosition.Y + data.OppositeLeg - Math.Sin(data.AngleAlpha) * (data.Hypotenuse / 2) - (_font.Height + _font.Height / 3))));
            g.DrawString("α", _font, Brushes.Black, // Angle alpha
                new Point((int)Math.Round(drawPosition.X + Math.Cos(data.AngleAlpha / 2) * (data.Hypotenuse / 8 + _font.Size * 2) - _font.Size / 2), (int)Math.Round(drawPosition.Y + data.OppositeLeg - (Math.Sin(data.AngleAlpha / 2) * (data.Hypotenuse / 8 + _font.Size * 2)) - _font.Height * 0.6)));
            g.DrawString("β", _font, Brushes.Black, // Angle beta
                new Point((int)Math.Round(drawPosition.X + data.AdjacentLeg - Math.Sin(data.AngleBeta / 2) * (data.Hypotenuse / 8 + _font.Size * 2) - _font.Size / 2), (int)Math.Round(drawPosition.Y + (Math.Cos(data.AngleBeta / 2) * (data.Hypotenuse / 8 + _font.Size * 2)) - _font.Height * 0.6)));
        }
    }
}
