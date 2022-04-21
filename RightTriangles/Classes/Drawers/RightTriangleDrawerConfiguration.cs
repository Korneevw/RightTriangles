using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class RightTriangleDrawerConfiguration
    {
        public int AngleArcSize { get; set; } = 50;
        public int AngleLabelDistance { get; set; } = 30; 
        public bool AngleAlphaArc { get; set; } = true;
        public Color AngleAlphaArcColor { get; set; } = Color.Black;
        public string AngleAlphaLabel { get; set; } = "α";
        public Color AngleAlphaLabelColor { get; set; } = Color.Black;
        public bool AngleBetaArc { get; set; } = true;
        public Color AngleBetaArcColor { get; set; } = Color.Black;
        public string AngleBetaLabel { get; set; } = "β";
        public Color AngleBetaLabelColor { get; set; } = Color.Black;
        public bool RightAngleRect { get; set; } = true;
        public Color RightAngleRectColor { get; set; } = Color.Black;
        public string RightTriangleRectLabel { get; set; } = "";
        public Color RightTriangleRectLabelColor { get; set; } = Color.Black;
        public string AdjacentLegLabel { get; set; } = "b";
        public Color AdjacentLegLabelColor { get; set; } = Color.Black;
        public Color AdjacentLegColor { get; set; } = Color.Black;
        public string OppositeLegLabel { get; set; } = "a";
        public Color OppositeLegLabelColor { get; set; } = Color.Black;
        public Color OppositeLegColor { get; set; } = Color.Black;
        public string HypotenuseLabel { get; set; } = "c";
        public Color HypotenuseLabelColor { get; set; } = Color.Black;
        public Color HypotenuseColor { get; set; } = Color.Black;
        public string HypotenuseAdjacentLegVertexLabel { get; set; } = "A";
        public Color HypotenuseAdjacentLegVertexLabelColor { get; set; } = Color.Black;
        public string HypotenuseOppositeLegVertexLabel { get; set; } = "B";
        public Color HypotenuseOppositeLegVertexLabelColor { get; set; } = Color.Black;
        public string AdjacentLegOppositeLegVertexLabel { get; set; } = "C";
        public Color AdajcentLegOppositeLegVertexLabelColor { get; set; } = Color.Black;
        public Font LabelFont { get; set; } = new Font("Georgia", 20, FontStyle.Italic);
        public int LineThickness { get; set; } = 2;
    }
}
