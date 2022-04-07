using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class BuildModeSelector : IBuildModeSelector
    {
        private IBuildMode[] _modes;
        public BuildModeSelector(IBuildMode[] modes) => _modes = modes;
        public IBuildMode SelectMode(RightTriangleData data)
        {
            foreach (IBuildMode mode in _modes)
            {
                bool result = mode.CheckCondition(data);
                if (result == true)
                {
                    return mode;
                }
            }
            throw new ArgumentException("Given data doesn't match any IBuildMode.");
        }
    }
}
