namespace RightTriangles
{
    public interface IRightTriangleDrawer
    {
        public DrawerConfiguration Configuration { get; set; }
        public void Draw(RightTriangleData data, Graphics g, Point drawPosition);
        public void DrawInRatios(RightTriangleData data, Graphics g, Point drawPosition);
        public Size GetTriangleDrawingSize(RightTriangleData data);
        public Size GetTriangleRatiosDrawingSize(RightTriangleData data);
    }
}
