namespace RightTriangles
{
    public interface IDrawingSaver
    {
        public void Save(RightTriangleData data, IRightTriangleDrawer drawer);
    }
}
