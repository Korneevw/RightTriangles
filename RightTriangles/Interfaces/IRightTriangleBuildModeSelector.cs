namespace RightTriangles
{
    public interface IRightTriangleBuildModeSelector
    {
        public IRightTriangleBuildMode SelectMode(RightTriangleData data);
    }
}
