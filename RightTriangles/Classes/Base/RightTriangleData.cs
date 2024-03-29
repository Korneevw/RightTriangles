﻿namespace RightTriangles
{
    public class RightTriangleData
    {
        public double Hypotenuse { get; set; } = 0;
        public double AdjacentLeg { get; set; } = 0;
        public double OppositeLeg { get; set; } = 0;
        public double AngleAlpha { get; set; } = 0;
        public double AngleBeta { get; set; } = 0;
        public double RightAngle { get; } = Math.PI / 2;
    }
}
