using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    internal class RightTriangleDataInput : IRightTriangleDataInput
    {
        public NumericUpDown HypotenuseInput { get; private set; }
        public NumericUpDown AdjacentLegInput { get; private set; }
        public NumericUpDown OppositeLegInput { get; private set; }
        public NumericUpDown AngleAlphaInput { get; private set; }
        private RightTriangleData _inputData;
        public RightTriangleData InputData { get { return _inputData; } }
        public event Action? AnyValueChanged;
        public RightTriangleDataInput(Control.ControlCollection controlContainer, Point startingPoint)
        {
            _inputData = new RightTriangleData();
            HypotenuseInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Minimum = 0,
                Size = new Size(100, 20),
                Location = new Point(startingPoint.X, startingPoint.Y)
            };
            HypotenuseInput.ValueChanged += HypotenuseValueChanged;
            AdjacentLegInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Minimum = 0,
                Size = new Size(100, 20),
                Location = new Point(HypotenuseInput.Location.X, HypotenuseInput.Bottom + 10)
            };
            AdjacentLegInput.ValueChanged += AdjacentLegValueChanged;
            OppositeLegInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Minimum = 0,
                Size = new Size(100, 20),
                Location = new Point(AdjacentLegInput.Location.X, AdjacentLegInput.Bottom + 10)
            };
            OppositeLegInput.ValueChanged += OppositeLegValueChanged;
            AngleAlphaInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Minimum = 0 + (decimal)Math.Pow(0.1, Properties.DecimalAccuracy),
                Size = new Size(100, 20),
                Location = new Point(OppositeLegInput.Location.X, OppositeLegInput.Bottom + 10)
            };
            AngleAlphaInput.ValueChanged += AngleAlphaValueChanged;
            controlContainer.AddRange(new Control[] { HypotenuseInput, AdjacentLegInput, OppositeLegInput, AngleAlphaInput });
        }

        private void HypotenuseValueChanged(object? sender, EventArgs e)
        {
            _inputData.Hypotenuse = (double)HypotenuseInput.Value;
            AnyValueChanged?.Invoke();
        }
        private void AdjacentLegValueChanged(object? sender, EventArgs e)
        {
            _inputData.AdjacentLeg = (double)AdjacentLegInput.Value;
            AnyValueChanged?.Invoke();
        }
        private void OppositeLegValueChanged(object? sender, EventArgs e)
        {
            _inputData.OppositeLeg = (double)OppositeLegInput.Value;
            AnyValueChanged?.Invoke();
        }
        private void AngleAlphaValueChanged(object? sender, EventArgs e)
        {
            _inputData.AngleAlpha = (double)AngleAlphaInput.Value * Math.PI / 180;
            AnyValueChanged?.Invoke();
        }
    }
}
