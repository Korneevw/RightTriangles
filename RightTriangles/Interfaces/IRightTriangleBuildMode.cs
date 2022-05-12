namespace RightTriangles
{
    public interface IRightTriangleBuildMode
    {
        public RightTriangleData Build(RightTriangleData data);
        public bool CheckCondition(RightTriangleData data);
    }
}
