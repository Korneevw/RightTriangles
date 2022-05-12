namespace RightTriangles
{
    public class DrawerConfiguration
    {
        public int AngleArcSize { get; set; } = 25;
        public int AngleLabelDistance { get; set; } = 30; 
        public bool AngleAlphaArc { get; set; } = true;
        public string AngleAlphaLabel { get; set; } = "α";
        public bool AngleBetaArc { get; set; } = true;
        public string AngleBetaLabel { get; set; } = "β";
        public bool RightAngleRect { get; set; } = true;
        public string RightAngleLabel { get; set; } = "";
        public string AdjacentLegLabel { get; set; } = "b";
        public string OppositeLegLabel { get; set; } = "a";
        public string HypotenuseLabel { get; set; } = "c";
        public string HypotenuseAdjacentLegVertexLabel { get; set; } = "A";
        public string HypotenuseOppositeLegVertexLabel { get; set; } = "B";
        public string AdjacentLegOppositeLegVertexLabel { get; set; } = "C";
        public Font LabelFont { get; set; } = new Font("Georgia", 20, FontStyle.Italic);
        public int LineThickness { get; set; } = 2;
        public int Size { get; set; } = 3;
    }
}
