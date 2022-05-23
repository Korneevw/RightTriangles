using System;
using System.Drawing;
namespace RightTriangles
{
    public class RightTriangleDrawer : IRightTriangleDrawer
    {
        public DrawerConfiguration Configuration { get; set; }
        private IRightTriangleValidator _validator = new RightTriangleValidator();
        public RightTriangleDrawer(DrawerConfiguration configuration)
        {
            Configuration = configuration;
        }
        public RightTriangleDrawer(DrawerConfiguration configuration, IRightTriangleValidator validator) : this(configuration)
        {
            _validator = validator;
        }
        public void Draw(RightTriangleData data, Graphics g, Point upLeft)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid."); // May affect perfomance?
            Point upRight = new Point((int)Math.Round(upLeft.X + data.AdjacentLeg), upLeft.Y);
            Point downLeft = new Point(upLeft.X, (int)Math.Round(upLeft.Y + data.OppositeLeg));
            Point downRight = new Point((int)Math.Round(upLeft.X + data.AdjacentLeg), (int)Math.Round(upLeft.Y + data.OppositeLeg));
            if (Configuration.AngleAlphaArc)
            {
                Rectangle alphaArcRect =
                new Rectangle(
                    new Point(
                        downLeft.X - Configuration.AngleArcSize, 
                        downLeft.Y - Configuration.AngleArcSize),
                    new Size(
                        Configuration.AngleArcSize * 2, 
                        Configuration.AngleArcSize * 2));
                g.DrawArc(
                    new Pen(Color.Black, Configuration.LineThickness), 
                    alphaArcRect, 
                    -(int)(data.AngleAlpha * (180 / Math.PI)), 
                    (int)(data.AngleAlpha * (180 / Math.PI)));
                g.DrawString(Configuration.AngleAlphaLabel, Configuration.LabelFont,
                    new SolidBrush(Color.Black),
                    new Point(
                        (int)Math.Round(downLeft.X + Math.Cos(data.AngleAlpha / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance)), 
                        (int)Math.Round(downLeft.Y - (Math.Sin(data.AngleAlpha / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance)) - Configuration.LabelFont.Height * 0.6)));
            }
            if (Configuration.AngleBetaArc)
            {
                Rectangle betaArcRect = new Rectangle(
                    new Point(
                        (int)Math.Round(upLeft.X + data.AdjacentLeg - Configuration.AngleArcSize), 
                        upLeft.Y - Configuration.AngleArcSize),
                    new Size(
                        Configuration.AngleArcSize * 2, 
                        Configuration.AngleArcSize * 2));
                g.DrawArc(new Pen(Color.Black, Configuration.LineThickness), betaArcRect, 90, (int)(data.AngleBeta * (180 / Math.PI)));
                g.DrawString(Configuration.AngleBetaLabel, Configuration.LabelFont,
                    new SolidBrush(Color.Black),
                    new Point(
                        (int)Math.Round(upRight.X - Math.Sin(data.AngleBeta / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - g.MeasureString(Configuration.AngleBetaLabel, Configuration.LabelFont).Width / 2), 
                        (int)Math.Round(upRight.Y + (Math.Cos(data.AngleBeta / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance)) - g.MeasureString(Configuration.AngleBetaLabel, Configuration.LabelFont).Height / 2)));
            }
            if (Configuration.RightAngleRect)
            {
                g.DrawRectangle(
                    new Pen(Color.Black, Configuration.LineThickness),
                    new Rectangle(
                        new Point(
                            downRight.X - Configuration.AngleArcSize, 
                            downRight.Y - Configuration.AngleArcSize),
                        new Size(
                            Configuration.AngleArcSize, 
                            Configuration.AngleArcSize)));
                g.DrawString(Configuration.RightAngleLabel, Configuration.LabelFont,
                    new SolidBrush(Color.Black),
                    new Point(
                        (int)Math.Round(downRight.X - (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - Configuration.LabelFont.Size * Configuration.RightAngleLabel.Length / 2), 
                        (int)Math.Round(downRight.Y - (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - g.MeasureString(Configuration.RightAngleLabel, Configuration.LabelFont).Height / 2)));
            }
            g.DrawLine(new Pen(Color.Black, Configuration.LineThickness), downLeft, downRight); // Adjacent leg
            g.DrawLine(new Pen(Color.Black, Configuration.LineThickness), upRight, downRight); // Opposite leg
            g.DrawLine(new Pen(Color.Black, Configuration.LineThickness), downLeft, upRight); // Hypotenuse
            g.DrawString(Configuration.AdjacentLegLabel, Configuration.LabelFont, 
                new SolidBrush(Color.Black), 
                new Point(
                    (int)Math.Round(downLeft.X + data.AdjacentLeg / 2 - g.MeasureString(Configuration.AdjacentLegLabel, Configuration.LabelFont).Width / 2), 
                    downLeft.Y)); // Adjacent leg label
            g.DrawString(Configuration.OppositeLegLabel, Configuration.LabelFont, 
                new SolidBrush(Color.Black), 
                new Point(
                    upRight.X, 
                    (int)Math.Round(upRight.Y + data.OppositeLeg / 2 - Configuration.LabelFont.Height * 0.6))); // Opposite leg label
            g.DrawString(Configuration.HypotenuseLabel, Configuration.LabelFont, 
                new SolidBrush(Color.Black),
                new Point(
                    (int)Math.Round(downLeft.X + Math.Cos(data.AngleAlpha) * (data.Hypotenuse / 2) - 10 - g.MeasureString(Configuration.HypotenuseLabel, Configuration.LabelFont).Width), 
                    (int)Math.Round(downLeft.Y - Math.Sin(data.AngleAlpha) * (data.Hypotenuse / 2) - 10 - g.MeasureString(Configuration.HypotenuseLabel, Configuration.LabelFont).Height / 2))); // Hypotenuse label
            g.DrawString(Configuration.HypotenuseAdjacentLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Color.Black),
                new Point(
                    (int)Math.Round(downLeft.X - g.MeasureString(Configuration.HypotenuseAdjacentLegVertexLabel, Configuration.LabelFont).Width - 10), 
                    (int)Math.Round(downLeft.Y - g.MeasureString(Configuration.HypotenuseAdjacentLegVertexLabel, Configuration.LabelFont).Height / 2))); // Hypotenuse adjacent leg vertex label
            g.DrawString(Configuration.HypotenuseOppositeLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Color.Black),
                new Point(
                    (int)Math.Round(upRight.X - g.MeasureString(Configuration.HypotenuseOppositeLegVertexLabel, Configuration.LabelFont).Width / 2),
                    upRight.Y - (int)g.MeasureString(Configuration.HypotenuseOppositeLegVertexLabel, Configuration.LabelFont).Height)); // Hypotenuse opposite leg vertex label
            g.DrawString(Configuration.AdjacentLegOppositeLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Color.Black),
                new Point(
                    /*(int)Math.Round(*/downRight.X/* - g.MeasureString(Configuration.AdjacentLegOppositeLegVertexLabel, Configuration.LabelFont).Width / 2) */,
                    downRight.Y)); // Adjacent leg opposite leg vertex label

        }
        public void DrawInRatios(RightTriangleData data, Graphics g, Point drawPosition)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid."); // May affect perfomance?
            RightTriangleData ratioedData = new RightTriangleData()
            {
                Hypotenuse = 50 * Configuration.Size,
                AdjacentLeg = Math.Cos(data.AngleAlpha) * (50 * Configuration.Size),
                OppositeLeg = Math.Sin(data.AngleAlpha) * (50 * Configuration.Size),
                AngleAlpha = data.AngleAlpha,
                AngleBeta = data.AngleBeta,
            };
            Draw(ratioedData, g, drawPosition);
        }
        public Size GetTriangleDrawingSize(RightTriangleData data)
        {
            return new Size((int)Math.Ceiling(data.AdjacentLeg), (int)Math.Ceiling(data.OppositeLeg));
        }
        public Size GetTriangleRatiosDrawingSize(RightTriangleData data)
        {
            return new Size((int)Math.Ceiling(Math.Cos(data.AngleAlpha) * (50 * Configuration.Size)), (int)Math.Ceiling(Math.Sin(data.AngleAlpha) * (50 * Configuration.Size)));
        }
    }
}
