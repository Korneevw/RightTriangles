using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class RightTriangleDrawer : IRightTriangleDrawer
    {
        public RightTriangleDrawerConfiguration Configuration { get; set; }
        private IRightTriangleValidator _validator = new RightTriangleValidator();
        public RightTriangleDrawer(RightTriangleDrawerConfiguration configuration)
        {
            Configuration = configuration;
        }
        public RightTriangleDrawer(RightTriangleDrawerConfiguration configuration, IRightTriangleValidator validator) : this(configuration)
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
                    new Pen(Configuration.AngleAlphaArcColor, Configuration.LineThickness), 
                    alphaArcRect, 
                    -(int)(data.AngleAlpha * (180 / Math.PI)), 
                    (int)(data.AngleAlpha * (180 / Math.PI)));
                g.DrawString(Configuration.AngleAlphaLabel, Configuration.LabelFont,
                    new SolidBrush(Configuration.AngleAlphaLabelColor),
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
                g.DrawArc(new Pen(Configuration.AngleBetaArcColor, Configuration.LineThickness), betaArcRect, 90, (int)(data.AngleBeta * (180 / Math.PI)));
                g.DrawString(Configuration.AngleBetaLabel, Configuration.LabelFont,
                    new SolidBrush(Configuration.AngleBetaLabelColor),
                    new Point(
                        (int)Math.Round(upRight.X - Math.Sin(data.AngleBeta / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - Configuration.LabelFont.Size * Configuration.AngleBetaLabel.Length / 2), 
                        (int)Math.Round(upRight.Y + (Math.Cos(data.AngleBeta / 2) * (Configuration.AngleArcSize + Configuration.AngleLabelDistance)) - Configuration.LabelFont.Height * 0.6)));
            }
            if (Configuration.RightAngleRect)
            {
                g.DrawRectangle(
                    new Pen(Configuration.RightAngleRectColor, Configuration.LineThickness),
                    new Rectangle(
                        new Point(
                            downRight.X - Configuration.AngleArcSize, 
                            downRight.Y - Configuration.AngleArcSize),
                        new Size(
                            Configuration.AngleArcSize, 
                            Configuration.AngleArcSize)));
                g.DrawString(Configuration.RightTriangleRectLabel, Configuration.LabelFont,
                    new SolidBrush(Configuration.RightTriangleRectLabelColor),
                    new Point(
                        (int)Math.Round(downRight.X - (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - Configuration.LabelFont.Size * Configuration.RightTriangleRectLabel.Length / 2), 
                        (int)Math.Round(downRight.Y - (Configuration.AngleArcSize + Configuration.AngleLabelDistance) - Configuration.LabelFont.Height * 0.6)));
            }
            g.DrawLine(new Pen(Configuration.AdjacentLegColor, Configuration.LineThickness), downLeft, downRight); // Adjacent leg
            g.DrawLine(new Pen(Configuration.OppositeLegColor, Configuration.LineThickness), upRight, downRight); // Opposite leg
            g.DrawLine(new Pen(Configuration.HypotenuseColor, Configuration.LineThickness), downLeft, upRight); // Hypotenuse
            g.DrawString(Configuration.AdjacentLegLabel, Configuration.LabelFont, 
                new SolidBrush(Configuration.AdjacentLegLabelColor), 
                new Point(
                    (int)Math.Round(downLeft.X + data.AdjacentLeg / 2 - Configuration.LabelFont.Size * Configuration.AdjacentLegLabel.Length / 2), 
                    downLeft.Y)); // Adjacent leg label
            g.DrawString(Configuration.OppositeLegLabel, Configuration.LabelFont, 
                new SolidBrush(Configuration.OppositeLegLabelColor), 
                new Point(
                    upRight.X, 
                    (int)Math.Round(upRight.Y + data.OppositeLeg / 2 - Configuration.LabelFont.Height * 0.6))); // Opposite leg label
            g.DrawString(Configuration.HypotenuseLabel, Configuration.LabelFont, 
                new SolidBrush(Configuration.HypotenuseLabelColor),
                new Point(
                    (int)Math.Round(downLeft.X + Math.Cos(data.AngleAlpha) * (data.Hypotenuse / 2) - 10 - Configuration.LabelFont.Size * Configuration.HypotenuseLabel.Length), 
                    (int)Math.Round(downLeft.Y - Math.Sin(data.AngleAlpha) * (data.Hypotenuse / 2) - 10 - Configuration.LabelFont.Height * 0.6))); // Hypotenuse label
            g.DrawString(Configuration.HypotenuseAdjacentLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Configuration.HypotenuseAdjacentLegVertexLabelColor),
                new Point(
                    (int)Math.Round(downLeft.X - Configuration.LabelFont.Size * Configuration.HypotenuseAdjacentLegVertexLabel.Length - 10), 
                    (int)Math.Round(downLeft.Y - Configuration.LabelFont.Height * 0.6))); // Hypotenuse adjacent leg vertex label
            g.DrawString(Configuration.HypotenuseOppositeLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Configuration.HypotenuseOppositeLegVertexLabelColor),
                new Point(
                    (int)Math.Round(upRight.X - Configuration.LabelFont.Size * Configuration.HypotenuseOppositeLegVertexLabel.Length / 2),
                    upRight.Y - Configuration.LabelFont.Height)); // Hypotenuse opposite leg vertex label
            g.DrawString(Configuration.AdjacentLegOppositeLegVertexLabel, Configuration.LabelFont,
                new SolidBrush(Configuration.AdajcentLegOppositeLegVertexLabelColor),
                new Point(
                    (int)Math.Round(downRight.X - Configuration.LabelFont.Size * Configuration.AdjacentLegOppositeLegVertexLabel.Length / 2),
                    downRight.Y)); // Adjacent leg opposite leg vertex label

        }
        public void DrawInRatios(RightTriangleData data, Graphics g, Point drawPosition, int size)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid."); // May affect perfomance?
            RightTriangleData ratioedData = new RightTriangleData()
            {
                Hypotenuse = size,
                AdjacentLeg = Math.Cos(data.AngleAlpha) * size,
                OppositeLeg = Math.Sin(data.AngleAlpha) * size,
                AngleAlpha = data.AngleAlpha,
                AngleBeta = data.AngleBeta,
            };
            Draw(ratioedData, g, drawPosition);
        }
    }
}
