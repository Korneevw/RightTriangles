using System;
using System.Drawing;

namespace RightTriangles
{
    public interface IDrawerConfigurationInput
    {
        public DrawerConfiguration Configuration { get; }
        public Point Location { get; }
        public Size Size { get; }
        public event Action? AnyValueChanged;
        public event Action? ResetButtonClick;
    }
}
