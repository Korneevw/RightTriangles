namespace RightTriangles
{
    public interface IPropertiesInput
    {
        public int DecimalAccuracy { get; }
        public decimal Increment { get; }
        public Size Size { get; }
        public event Action? AnyValueChanged;
        public void UpdateDecimalAccuracy();
    }
}
