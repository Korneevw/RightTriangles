using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightTriangles
{
    public class PropertiesInput : IPropertiesInput
    {
        private int _decimalAccuracy = Properties.DecimalAccuracy;
        private decimal _increment = Properties.Increment;
        private Size _totalControlSize;
        private GroupBox _groupBox;
        private Label _decimalAccuracyInputLabel;
        private NumericUpDown _decimalAccuracyInput;
        private Label _incrementInputLabel;
        private NumericUpDown _incrementInput;
        public int DecimalAccuracy { get { return _decimalAccuracy; } }
        public decimal Increment { get { return _increment;} }
        public Size TotalControlSize { get { return _totalControlSize; } }
        public event Action? AnyValueChanged;
        public PropertiesInput(Control.ControlCollection controlContainer, Point startingPoint)
        {
            _groupBox = new GroupBox()
            {
                Text = "Properties",
                Width = 120,
                Height = 130,
                Location = new Point(startingPoint.X, startingPoint.Y),
            };
            _decimalAccuracyInputLabel = new Label()
            {
                Text = "Fraction accuracy:",
                Width = 110,
                Height = 20,
                Location = new Point(10, 20)
            };
            _decimalAccuracyInput = new NumericUpDown()
            {
                DecimalPlaces = 0,
                Increment = 1,
                Value = Properties.DecimalAccuracy,
                Minimum = 0,
                Maximum = 8,
                Width = 100,
                Location = new Point(_decimalAccuracyInputLabel.Left, _decimalAccuracyInputLabel.Bottom)
            };
            _decimalAccuracyInput.ValueChanged += DecimalAccuracyValueChanged;

            _incrementInputLabel = new Label()
            {
                Text = "Value increment:",
                Width = 100,
                Height = 20,
                Location = new Point(_decimalAccuracyInputLabel.Left, _decimalAccuracyInput.Bottom + 10)
            };
            _incrementInput = new NumericUpDown()
            {
                DecimalPlaces = Properties.DecimalAccuracy,
                Increment = 1,
                Value = Properties.Increment,
                Minimum = 0 + (decimal)Math.Pow(0.1, Properties.DecimalAccuracy),
                Maximum = 500,
                Width = 100,
                Location = new Point(_decimalAccuracyInputLabel.Left, _incrementInputLabel.Bottom)
            };
            _incrementInput.ValueChanged += IncrementValueChanged;

            _groupBox.Controls.AddRange(new Control[] { _decimalAccuracyInputLabel, _decimalAccuracyInput, _incrementInputLabel, _incrementInput });
            controlContainer.Add(_groupBox);
            _totalControlSize = _groupBox.Size;
        }
        private void IncrementValueChanged(object? sender, EventArgs e)
        {
            _increment = _incrementInput.Value;
            AnyValueChanged?.Invoke();
        }
        private void DecimalAccuracyValueChanged(object? sender, EventArgs e)
        {
            _decimalAccuracy = (int)_decimalAccuracyInput.Value;
            AnyValueChanged?.Invoke();
        }
        public void UpdateDecimalAccuracy()
        {
            _incrementInput.DecimalPlaces = Properties.DecimalAccuracy;
            _incrementInput.Minimum = 0 + (decimal)Math.Pow(0.1, Properties.DecimalAccuracy);
        }
    }
}
