namespace RightTriangles
{
    internal interface IAdditionalDataDisplayer
    {
        public Size Size { get; }
        public DrawerConfiguration? Configuration { get; set; }
        public RightTriangleAdditionalData? CurrentAdditionalData { get; set; }
        public void UpdateLabels();
    }
}
