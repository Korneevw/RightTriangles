using System;

namespace RightTriangles
{
    public class BuildModeSelector : IRightTriangleBuildModeSelector
    {
        private IRightTriangleBuildMode[] _modes;
        public BuildModeSelector(IRightTriangleBuildMode[] modes) => _modes = modes;
        public IRightTriangleBuildMode SelectMode(RightTriangleData data)
        {
            foreach (IRightTriangleBuildMode mode in _modes)
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
