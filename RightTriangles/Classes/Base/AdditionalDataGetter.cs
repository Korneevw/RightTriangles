using System;
namespace RightTriangles
{
    internal class AdditionalDataGetter : IRightTriangleAdditionalDataGetter
    {
        private IRightTriangleValidator _validator;
        public AdditionalDataGetter(IRightTriangleValidator validator)
        {
            _validator = validator;
        }
        public RightTriangleAdditionalData GetAdditionalData(RightTriangleData data)
        {
            if (_validator.Validate(data) == false) throw new ArgumentException("Given right triangle data is not valid.");
            RightTriangleAdditionalData additionalData = new RightTriangleAdditionalData()
            {
                AngleAlphaRad = data.AngleAlpha,
                AngleBetaRad = data.AngleBeta,
                AngleAlphaDeg = data.AngleAlpha * (180 / Math.PI),
                AngleBetaDeg = data.AngleBeta * (180 / Math.PI),
                AngleAlphaSin = Math.Sin(data.AngleAlpha),
                AngleAlphaCos = Math.Cos(data.AngleAlpha),
                AngleAlphaTan = Math.Tan(data.AngleAlpha),
                AngleAlphaCot = 1 / Math.Tan(data.AngleAlpha),
                AngleAlphaSec = 1 / Math.Cos(data.AngleAlpha),
                AngleAlphaCsc = 1 / Math.Sin(data.AngleAlpha),
                AngleBetaSin = Math.Sin(data.AngleBeta),
                AngleBetaCos = Math.Cos(data.AngleBeta),
                AngleBetaTan = Math.Tan(data.AngleBeta),
                AngleBetaCot = 1 / Math.Tan(data.AngleBeta),
                AngleBetaSec = 1 / Math.Cos(data.AngleBeta),
                AngleBetaCsc = 1 / Math.Sin(data.AngleBeta),
                Area = (data.AdjacentLeg * data.OppositeLeg) / 2,
                Perimeter = data.AdjacentLeg + data.OppositeLeg + data.Hypotenuse,
                Hypotenuse = data.Hypotenuse,
                AdjacentLeg = data.AdjacentLeg,
                OppositeLeg = data.OppositeLeg,
            };
            return additionalData;
        }
    }
}
