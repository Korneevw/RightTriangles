namespace RightTriangles
{
    public class DrawerConfigurationInput : IDrawerConfigurationInput
    {
        public DrawerConfiguration Configuration { get; set; }
        public event Action? AnyValueChanged;
        public event Action? ResetButtonClick;
        public Point Location { get { return _groupBox.Location; } set { _groupBox.Location = value; } }
        public Size Size { get { return _groupBox.Size; } }
        private GroupBox _groupBox;
        private Label _angleArcSizeLabel;
        private NumericUpDown _angleArcSizeInput;
        private Label _angleLabelDistanceLabel;
        private NumericUpDown _angleLabelDistanceInput;
        private Label _angleAlphaArcLabel;
        private CheckBox _angleAlphaArcInput;
        private Label _angleAlphaLabelLabel;
        private TextBox _angleAlphaLabelInput;
        private Label _angleBetaArcLabel;
        private CheckBox _angleBetaArcInput;
        private Label _angleBetaLabelLabel;
        private TextBox _angleBetaLabelInput;
        private Label _rightAngleRectLabel;
        private CheckBox _rightAngleRectInput;
        private Label _rightAngleLabelLabel;
        private TextBox _rightAngleLabelInput;
        private Label _adjacentLegLabelLabel;
        private TextBox _adjacentLegLabelInput;
        private Label _oppositeLegLabelLabel;
        private TextBox _oppositeLegLabelInput;
        private Label _hypotenuseLabelLabel;
        private TextBox _hypotenuseLabelInput;
        private Label _hypotenuseAdjacentLegVertexLabelLabel;
        private TextBox _hypotenuseAdjacentLegVertexLabelInput;
        private Label _hypotenuseOppositeLegVertexLabelLabel;
        private TextBox _hypotenuseOppositeLegVertexLabelInput;
        private Label _adjacentLegOppositeLegVertexLabelLabel;
        private TextBox _adjacentLegOppositeLegVertexLabelInput;
        private Label _labelFontLabel;
        private Button _labelFontInput;
        private Label _lineThicknessLabel;
        private NumericUpDown _lineThicknessInput;
        private Label _sizeLabel;
        private NumericUpDown _sizeInput;
        private Button _resetButton;
        public DrawerConfigurationInput(Control.ControlCollection controlContainer, Point location, DrawerConfiguration defaultConfiguration)
        {
            Configuration = defaultConfiguration;
            _groupBox = new GroupBox()
            {
                Text = "Редактирование чертежа",
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = location,
                Size = new Size(1000, 1000),
            };

            _angleArcSizeLabel = new Label()
            {
                Text = "Размер дуг углов:",
                AutoSize = true,
                Location = new Point(10, 20)
            };
            _angleArcSizeInput = new NumericUpDown()
            {
                Value = Configuration.AngleArcSize,
                Maximum = 100,
                Minimum = 1,
                Increment = 1,
                Location = new Point(10, _angleArcSizeLabel.Bottom)
            };
            _angleArcSizeInput.ValueChanged += (s, e) => { Configuration.AngleArcSize = (int)_angleArcSizeInput.Value; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleArcSizeLabel);
            _groupBox.Controls.Add(_angleArcSizeInput);

            _angleLabelDistanceLabel = new Label()
            {
                Text = "Удалённость назв. углов:",
                AutoSize = true,
                Location = new Point(10, _angleArcSizeInput.Bottom + 10)
            };
            _angleLabelDistanceInput = new NumericUpDown()
            {
                Value = Configuration.AngleLabelDistance,
                Maximum = 100,
                Minimum = 1,
                Increment = 1,
                Location = new Point(10, _angleLabelDistanceLabel.Bottom)
            };
            _angleLabelDistanceInput.ValueChanged += (s, e) => { Configuration.AngleLabelDistance = (int)_angleLabelDistanceInput.Value; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleLabelDistanceLabel);
            _groupBox.Controls.Add(_angleLabelDistanceInput);

            _angleAlphaArcLabel = new Label()
            {
                Text = "Дуга угла альфа:",
                AutoSize = true,
                Location = new Point(10, _angleLabelDistanceInput.Bottom + 10)
            };
            _angleAlphaArcInput = new CheckBox()
            {
                Checked = Configuration.AngleAlphaArc,
                Size = new Size(20, 20),
                Location = new Point(_angleAlphaArcLabel.Location.X + _angleAlphaArcLabel.PreferredWidth, _angleAlphaArcLabel.Location.Y)
            };
            _angleAlphaArcInput.CheckedChanged += (s, e) => { Configuration.AngleAlphaArc = _angleAlphaArcInput.Checked; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleAlphaArcLabel);
            _groupBox.Controls.Add(_angleAlphaArcInput);

            _angleAlphaLabelLabel = new Label()
            {
                Text = "Назв. угла альфа:",
                AutoSize = true,
                Location = new Point(10, _angleAlphaArcLabel.Bottom + 10)
            };
            _angleAlphaLabelInput = new TextBox()
            {
                Text = Configuration.AngleAlphaLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(10, _angleAlphaLabelLabel.Bottom)
            };
            _angleAlphaLabelInput.TextChanged += (s, e) => { Configuration.AngleAlphaLabel = _angleAlphaLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleAlphaLabelLabel);
            _groupBox.Controls.Add(_angleAlphaLabelInput);

            _angleBetaArcLabel = new Label()
            {
                Text = "Дуга угла бета:",
                AutoSize = true,
                Location = new Point(10, _angleAlphaLabelInput.Bottom + 10)
            };
            _angleBetaArcInput = new CheckBox()
            {
                Checked = Configuration.AngleBetaArc,
                Size = new Size(20, 20),
                Location = new Point(_angleBetaArcLabel.Location.X + _angleBetaArcLabel.PreferredWidth, _angleBetaArcLabel.Location.Y)
            };
            _angleBetaArcInput.CheckedChanged += (s, e) => { Configuration.AngleBetaArc = _angleBetaArcInput.Checked; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleBetaArcLabel);
            _groupBox.Controls.Add(_angleBetaArcInput);

            _angleBetaLabelLabel = new Label()
            {
                Text = "Назв. угла бета:",
                AutoSize = true,
                Location = new Point(10, _angleBetaArcLabel.Bottom + 10)
            };
            _angleBetaLabelInput = new TextBox()
            {
                Text = Configuration.AngleBetaLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(10, _angleBetaLabelLabel.Bottom)
            };
            _angleBetaLabelInput.TextChanged += (s, e) => { Configuration.AngleBetaLabel = _angleBetaLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_angleBetaLabelLabel);
            _groupBox.Controls.Add(_angleBetaLabelInput);

            _rightAngleRectLabel = new Label()
            {
                Text = "Прямой угол:",
                AutoSize = true,
                Location = new Point(10, _angleBetaLabelInput.Bottom + 10)
            };
            _rightAngleRectInput = new CheckBox()
            {
                Checked = Configuration.RightAngleRect,
                Size = new Size(20, 20),
                Location = new Point(_rightAngleRectLabel.Location.X + _rightAngleRectLabel.PreferredWidth, _rightAngleRectLabel.Location.Y)
            };
            _rightAngleRectInput.CheckedChanged += (s, e) => { Configuration.RightAngleRect = _rightAngleRectInput.Checked; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_rightAngleRectLabel);
            _groupBox.Controls.Add(_rightAngleRectInput);

            _rightAngleLabelLabel = new Label()
            {
                Text = "Назв. прямого угла:",
                AutoSize = true,
                Location = new Point(10, _rightAngleRectLabel.Bottom + 10)
            };
            _rightAngleLabelInput = new TextBox()
            {
                Text = Configuration.RightAngleLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(10, _rightAngleLabelLabel.Bottom)
            };
            _rightAngleLabelInput.TextChanged += (s, e) => { Configuration.RightAngleLabel = _rightAngleLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_rightAngleLabelLabel);
            _groupBox.Controls.Add(_rightAngleLabelInput);

            _adjacentLegLabelLabel = new Label()
            {
                Text = "Назв. прил. катета:",
                AutoSize = true,
                Location = new Point(150, 20)
            };
            _adjacentLegLabelInput = new TextBox()
            {
                Text = Configuration.AdjacentLegLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _adjacentLegLabelLabel.Bottom)
            };
            _adjacentLegLabelInput.TextChanged += (s, e) => { Configuration.AdjacentLegLabel = _adjacentLegLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_adjacentLegLabelLabel);
            _groupBox.Controls.Add(_adjacentLegLabelInput);

            _oppositeLegLabelLabel = new Label()
            {
                Text = "Назв. прот. катета:",
                AutoSize = true,
                Location = new Point(150, _adjacentLegLabelInput.Bottom + 10)
            };
            _oppositeLegLabelInput = new TextBox()
            {
                Text = Configuration.OppositeLegLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _oppositeLegLabelLabel.Bottom)
            };
            _oppositeLegLabelInput.TextChanged += (s, e) => { Configuration.OppositeLegLabel = _oppositeLegLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_oppositeLegLabelLabel);
            _groupBox.Controls.Add(_oppositeLegLabelInput);

            _hypotenuseLabelLabel = new Label()
            {
                Text = "Назв. гипотенузы:",
                AutoSize = true,
                Location = new Point(150, _oppositeLegLabelInput.Bottom + 10)
            };
            _hypotenuseLabelInput = new TextBox()
            {
                Text = Configuration.HypotenuseLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _hypotenuseLabelLabel.Bottom)
            };
            _hypotenuseLabelInput.TextChanged += (s, e) => { Configuration.HypotenuseLabel = _hypotenuseLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_hypotenuseLabelLabel);
            _groupBox.Controls.Add(_hypotenuseLabelInput);

            _hypotenuseAdjacentLegVertexLabelLabel = new Label()
            {
                Text = "Назв. вершины угла альфа:",
                AutoSize = true,
                Location = new Point(150, _hypotenuseLabelInput.Bottom + 10)
            };
            _hypotenuseAdjacentLegVertexLabelInput = new TextBox()
            {
                Text = Configuration.HypotenuseAdjacentLegVertexLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _hypotenuseAdjacentLegVertexLabelLabel.Bottom)
            };
            _hypotenuseAdjacentLegVertexLabelInput.TextChanged += (s, e) => { Configuration.HypotenuseAdjacentLegVertexLabel = _hypotenuseAdjacentLegVertexLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_hypotenuseAdjacentLegVertexLabelLabel);
            _groupBox.Controls.Add(_hypotenuseAdjacentLegVertexLabelInput);

            _hypotenuseOppositeLegVertexLabelLabel = new Label()
            {
                Text = "Назв. вершины угла бета:",
                AutoSize = true,
                Location = new Point(150, _hypotenuseAdjacentLegVertexLabelInput.Bottom + 10)
            };
            _hypotenuseOppositeLegVertexLabelInput = new TextBox()
            {
                Text = Configuration.HypotenuseOppositeLegVertexLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _hypotenuseOppositeLegVertexLabelLabel.Bottom)
            };
            _hypotenuseOppositeLegVertexLabelInput.TextChanged += (s, e) => { Configuration.HypotenuseOppositeLegVertexLabel = _hypotenuseOppositeLegVertexLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_hypotenuseOppositeLegVertexLabelLabel);
            _groupBox.Controls.Add(_hypotenuseOppositeLegVertexLabelInput);

            _adjacentLegOppositeLegVertexLabelLabel = new Label()
            {
                Text = "Назв. вершины прямого угла:",
                AutoSize = true,
                Location = new Point(150, _hypotenuseOppositeLegVertexLabelInput.Bottom + 10)
            };
            _adjacentLegOppositeLegVertexLabelInput = new TextBox()
            {
                Text = Configuration.AdjacentLegOppositeLegVertexLabel,
                Multiline = false,
                MaxLength = 10,
                Location = new Point(150, _adjacentLegOppositeLegVertexLabelLabel.Bottom)
            };
            _adjacentLegOppositeLegVertexLabelInput.TextChanged += (s, e) => { Configuration.AdjacentLegOppositeLegVertexLabel = _adjacentLegOppositeLegVertexLabelInput.Text; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_adjacentLegOppositeLegVertexLabelLabel);
            _groupBox.Controls.Add(_adjacentLegOppositeLegVertexLabelInput);

            _labelFontLabel = new Label()
            {
                Text = "Шрифт надписей:",
                AutoSize = true,
                Location = new Point(270, 20)
            };
            _labelFontInput = new Button()
            {
                Text = "Выбрать",
                AutoSize = true,
                Location = new Point(270, _labelFontLabel.Bottom)
            };
            _labelFontInput.Click += SelectFontClick;
            _groupBox.Controls.Add(_labelFontLabel);
            _groupBox.Controls.Add(_labelFontInput);

            _lineThicknessLabel = new Label()
            {
                Text = "Толщина линий:",
                AutoSize = true,
                Location = new Point(270, _labelFontInput.Bottom)
            };
            _lineThicknessInput = new NumericUpDown()
            {
                Value = Configuration.LineThickness,
                Maximum = 20,
                Minimum = 1,
                Increment = 1,
                Location = new Point(270, _lineThicknessLabel.Bottom)
            };
            _lineThicknessInput.ValueChanged += (s, e) => { Configuration.LineThickness = (int)_lineThicknessInput.Value; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_lineThicknessLabel);
            _groupBox.Controls.Add(_lineThicknessInput);

            _sizeLabel = new Label()
            {
                Text = "Размер чертежа:",
                AutoSize = true,
                Location = new Point(270, _lineThicknessInput.Bottom)
            };
            _sizeInput = new NumericUpDown()
            {
                Value = Configuration.Size,
                Maximum = 20,
                Minimum = 1,
                Increment = 1,
                Location = new Point(270, _sizeLabel.Bottom)
            };
            _sizeInput.ValueChanged += (s, e) => { Configuration.Size = (int)_sizeInput.Value; AnyValueChanged?.Invoke(); };
            _groupBox.Controls.Add(_sizeLabel);
            _groupBox.Controls.Add(_sizeInput);

            _resetButton = new Button()
            {
                Text = "Настройки по-умолчанию",
                AutoSize = true,
                Location = new Point(270, _sizeInput.Bottom)
            };
            _resetButton.Click += ResetClick;
            _groupBox.Controls.Add(_resetButton);

            _groupBox.Size = _groupBox.PreferredSize;
            controlContainer.Add(_groupBox);
        }
        private void SelectFontClick(object? sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            Configuration.LabelFont = fontDialog.Font;
            AnyValueChanged?.Invoke();
        }
        private void ResetClick(object? sender, EventArgs e)
        {
            Configuration = new DrawerConfiguration();
            UpdateInputFieldValues();
            ResetButtonClick?.Invoke();
        }
        public void UpdateInputFieldValues()
        {
            _angleArcSizeInput.Value = Configuration.AngleArcSize;
            _angleLabelDistanceInput.Value = Configuration.AngleLabelDistance;
            _angleAlphaArcInput.Checked = Configuration.AngleAlphaArc;
            _angleAlphaLabelInput.Text = Configuration.AngleAlphaLabel;
            _angleBetaArcInput.Checked = Configuration.AngleBetaArc;
            _angleBetaLabelInput.Text = Configuration.AngleBetaLabel;
            _rightAngleRectInput.Checked = Configuration.RightAngleRect;
            _rightAngleLabelInput.Text = Configuration.RightAngleLabel;
            _adjacentLegLabelInput.Text = Configuration.AdjacentLegLabel;
            _oppositeLegLabelInput.Text = Configuration.OppositeLegLabel;
            _hypotenuseLabelInput.Text = Configuration.HypotenuseLabel;
            _hypotenuseAdjacentLegVertexLabelInput.Text = Configuration.HypotenuseAdjacentLegVertexLabel;
            _hypotenuseOppositeLegVertexLabelInput.Text = Configuration.HypotenuseOppositeLegVertexLabel;
            _adjacentLegOppositeLegVertexLabelInput.Text = Configuration.AdjacentLegOppositeLegVertexLabel;
            _lineThicknessInput.Value = Configuration.LineThickness;
            _sizeInput.Value = Configuration.LineThickness;
        }
    }
}
