using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public class RightTriangleDataInput : IRightTriangleDataInput
    {
        private NumericUpDown[] _allInputControls;
        private RightTriangleData _inputData;
        public Size Size { get { return _groupBox.Size; } }
        public RightTriangleData InputData { get { return _inputData; } }
        private GroupBox _groupBox;
        private Label _hypotenuseInputLabel;
        private NumericUpDown _hypotenuseInput;
        private Label _adjacentLegInputLabel;
        private NumericUpDown _adjacentLegInput;
        private Label _oppositeLegInputLabel;
        private NumericUpDown _oppositeLegInput;
        private Label _angleAlphaInputLabel;
        private NumericUpDown _angleAlphaInput;
        public event Action? AnyValueChanged;
        public RightTriangleDataInput(Control.ControlCollection controlContainer, Point startingPoint)
        {
            _inputData = new RightTriangleData();

            _groupBox = new GroupBox()
            {
                Text = "Inputs",
                Location = new Point(startingPoint.X, startingPoint.Y),
                Width = 120,
                Height = 235,
            };

            _hypotenuseInputLabel = new Label()
            {
                Text = "Hypotenuse:",
                Width = 100,
                Height = 20,
                Location = new Point(10, 20),
            };
            _hypotenuseInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Increment = Properties.Increment,
                Minimum = 0,
                Maximum = 1000,
                Width = 100,
                Location = new Point(_hypotenuseInputLabel.Left, _hypotenuseInputLabel.Bottom)
            };
            _hypotenuseInput.ValueChanged += HypotenuseValueChanged;

            _adjacentLegInputLabel = new Label()
            {
                Text = "Adjacent leg:",
                Width = 100,
                Height = 20,
                Location = new Point(_hypotenuseInputLabel.Left, _hypotenuseInput.Bottom + 10),
            };
            _adjacentLegInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Increment = Properties.Increment,
                Minimum = 0,
                Maximum = 1000,
                Width = 100,
                Location = new Point(_hypotenuseInputLabel.Left, _adjacentLegInputLabel.Bottom)
            };
            _adjacentLegInput.ValueChanged += AdjacentLegValueChanged;

            _oppositeLegInputLabel = new Label()
            {
                Text = "Opposite leg:",
                Width = 100,
                Height = 20,
                Location = new Point(_hypotenuseInputLabel.Left, _adjacentLegInput.Bottom + 10),
            };
            _oppositeLegInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Increment = Properties.Increment,
                Minimum = 0,
                Maximum = 1000,
                Width = 100,
                Location = new Point(_hypotenuseInputLabel.Left, _oppositeLegInputLabel.Bottom)
            };
            _oppositeLegInput.ValueChanged += OppositeLegValueChanged;

            _angleAlphaInputLabel = new Label()
            {
                Text = "Angle:",
                Width = 100,
                Height = 20,
                Location = new Point(_hypotenuseInputLabel.Left, _oppositeLegInput.Bottom + 10),
            };
            _angleAlphaInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Increment = Properties.Increment,
                Minimum = 0,
                Maximum = 90 - (decimal)Math.Pow(0.1, Properties.DecimalAccuracy),
                Width = 100,
                Location = new Point(_hypotenuseInputLabel.Left, _angleAlphaInputLabel.Bottom)
            };
            _angleAlphaInput.ValueChanged += AngleAlphaValueChanged;

            _groupBox.Controls.AddRange(new Control[] { _hypotenuseInput, _adjacentLegInput, _oppositeLegInput, _angleAlphaInput, _hypotenuseInputLabel, _adjacentLegInputLabel, _oppositeLegInputLabel, _angleAlphaInputLabel });
            controlContainer.Add(_groupBox);
            _allInputControls = new NumericUpDown[] { _hypotenuseInput, _adjacentLegInput, _oppositeLegInput, _angleAlphaInput };
        }
        private void HypotenuseValueChanged(object? sender, EventArgs e)
        {
            _inputData.Hypotenuse = (double)_hypotenuseInput.Value;
            CheckTwoInputs();
            AnyValueChanged?.Invoke();
        }
        private void AdjacentLegValueChanged(object? sender, EventArgs e)
        {
            _inputData.AdjacentLeg = (double)_adjacentLegInput.Value;
            CheckTwoInputs();
            AnyValueChanged?.Invoke();
        }
        private void OppositeLegValueChanged(object? sender, EventArgs e)
        {
            _inputData.OppositeLeg = (double)_oppositeLegInput.Value;
            CheckTwoInputs();
            AnyValueChanged?.Invoke();
        }
        private void AngleAlphaValueChanged(object? sender, EventArgs e)
        {
            _inputData.AngleAlpha = (double)_angleAlphaInput.Value * Math.PI / 180;
            CheckTwoInputs();
            AnyValueChanged?.Invoke();
        }
        private void CheckTwoInputs()
        {
            if (_allInputControls.Where(n => n.Value > n.Minimum).Count() == 2)
            {
                _allInputControls.Where(n => n.Value == n.Minimum).ToList().ForEach(n => n.Enabled = false);
            }
        }
        public void UpdateDecimalAccuracy()
        {
            _hypotenuseInput.DecimalPlaces = Properties.DecimalAccuracy;
            _adjacentLegInput.DecimalPlaces = Properties.DecimalAccuracy;
            _oppositeLegInput.DecimalPlaces = Properties.DecimalAccuracy;
            _angleAlphaInput.DecimalPlaces = Properties.DecimalAccuracy;
            _angleAlphaInput.Maximum = 90 - (decimal)Math.Pow(0.1, Properties.DecimalAccuracy);
        }
        public void UpdateIncrement()
        {
            _hypotenuseInput.Increment = Properties.Increment;
            _adjacentLegInput.Increment = Properties.Increment;
            _oppositeLegInput.Increment = Properties.Increment;
            _angleAlphaInput.Increment = Properties.Increment;
        }
    }
}
