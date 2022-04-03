using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class BuildModeSelector
    {
        private IBuildModeConditionContaining[] _modes;
        public BuildModeSelector(IBuildModeConditionContaining[] modes) => _modes = modes;
        public IBuildModeConditionContaining CheckConditions(RightTriangleData data)
        {
            foreach (IBuildModeConditionContaining mode in _modes)
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
