using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public interface IDrawerConfigurationInput
    {
        public DrawerConfiguration Configuration { get; }
        public Point Location { get; }
        public Size Size { get; }
        public event Action? AnyValueChanged;
    }
}
