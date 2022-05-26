using System.Windows.Forms;
using System.Drawing;
using System;

namespace RightTriangles
{
    internal class AdditionalDataDisplayer : IAdditionalDataDisplayer
    {
        public Size Size { get { return _groupBox.Size; } }
        public DrawerConfiguration? Configuration { get; set; }
        public RightTriangleAdditionalData? CurrentAdditionalData { get; set; }
        private GroupBox _groupBox;
        private Label _angleAlphaRadLabel;
        private Label _angleBetaRadLabel;
        private Label _angleAlphaDegLabel;
        private Label _angleBetaDegLabel;
        private Label _angleAlphaSinLabel;
        private Label _angleAlphaCosLabel;
        private Label _angleAlphaTanLabel;
        private Label _angleAlphaCotLabel;
        private Label _angleAlphaSecLabel;
        private Label _angleAlphaCscLabel;
        private Label _angleBetaSinLabel;
        private Label _angleBetaCosLabel;
        private Label _angleBetaTanLabel;
        private Label _angleBetaCotLabel;
        private Label _angleBetaSecLabel;
        private Label _angleBetaCscLabel;
        private Label _areaLabel;
        private Label _perimeterLabel;
        private Label _hypotenuseLabel;
        private Label _adjacentLegLabel;
        private Label _oppositeLegLabel;
        public AdditionalDataDisplayer(Control.ControlCollection controlContainer, Point startingPoint, DrawerConfiguration configuration)
        {
            _groupBox = new GroupBox()
            {
                Text = "Информация о прямоугольном треугольнике:",
                Location = startingPoint,
            };
            _angleAlphaRadLabel = new Label()
            {
                Text = $"{configuration.AngleAlphaLabel} (рад.):",
                Location = new Point(10, 30)
            };
            _angleAlphaRadLabel.Width = _angleAlphaRadLabel.PreferredWidth;
            _angleBetaRadLabel = new Label()
            {
                Text = $"{configuration.AngleBetaLabel} (рад.):",
                Location = new Point(_angleAlphaRadLabel.Right + 10, 30)
            };
            _angleBetaRadLabel.Width = _angleBetaRadLabel.PreferredWidth;
            _angleAlphaDegLabel = new Label()
            {
                Text = $"{configuration.AngleAlphaLabel} (град.):",
                Location = new Point(_angleBetaRadLabel.Right + 10, 30)
            };
            _angleAlphaDegLabel.Width = _angleAlphaDegLabel.PreferredWidth;
            _angleBetaDegLabel = new Label()
            {
                Text = $"{configuration.AngleBetaLabel} (град.):",
                Location = new Point(_angleAlphaDegLabel.Right + 10, 30)
            };
            _angleBetaDegLabel.Width = _angleBetaDegLabel.PreferredWidth;
            _hypotenuseLabel = new Label()
            {
                Text = $"{configuration.HypotenuseLabel}:",
                Location = new Point(_angleBetaDegLabel.Right + 10, 30)
            };
            _hypotenuseLabel.Width = _hypotenuseLabel.PreferredWidth;
            _adjacentLegLabel = new Label()
            {
                Text = $"{configuration.AdjacentLegLabel}:",
                Location = new Point(_hypotenuseLabel.Right + 10, 30)
            };
            _adjacentLegLabel.Width = _adjacentLegLabel.PreferredWidth;
            _oppositeLegLabel = new Label()
            {
                Text = $"{configuration.OppositeLegLabel}:",
                Location = new Point(_adjacentLegLabel.Right + 10, 30)
            };
            _oppositeLegLabel.Width = _oppositeLegLabel.PreferredWidth;
            _areaLabel = new Label()
            {
                Text = $"S: ",
                Location = new Point(_oppositeLegLabel.Right + 10, 30)
            };
            _areaLabel.Width = _areaLabel.PreferredWidth;
            _perimeterLabel = new Label()
            {
                Text = $"P: ",
                Location = new Point(_areaLabel.Right + 10, 30)
            };
            _perimeterLabel.Width = _perimeterLabel.PreferredWidth;
            _groupBox.Controls.Add(_angleAlphaRadLabel);
            _groupBox.Controls.Add(_angleBetaRadLabel);
            _groupBox.Controls.Add(_angleAlphaDegLabel);
            _groupBox.Controls.Add(_angleBetaDegLabel);
            _groupBox.Controls.Add(_hypotenuseLabel);
            _groupBox.Controls.Add(_adjacentLegLabel);
            _groupBox.Controls.Add(_oppositeLegLabel);
            _groupBox.Controls.Add(_areaLabel);
            _groupBox.Controls.Add(_perimeterLabel);

            _angleAlphaSinLabel = new Label()
            {
                Text = $"sin {configuration.AngleAlphaLabel}: ",
                Location = new Point(10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaSinLabel.Width = _angleAlphaSinLabel.PreferredWidth;
            _angleAlphaCosLabel = new Label()
            {
                Text = $"cos {configuration.AngleAlphaLabel}: ",
                Location = new Point(_angleAlphaSinLabel.Right + 10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaCosLabel.Width = _angleAlphaCosLabel.PreferredWidth;
            _angleAlphaTanLabel = new Label()
            {
                Text = $"tan {configuration.AngleAlphaLabel}: ",
                Location = new Point( _angleAlphaCosLabel.Right + 10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaTanLabel.Width = _angleAlphaTanLabel.PreferredWidth;
            _angleAlphaCotLabel = new Label()
            {
                Text = $"cot {configuration.AngleAlphaLabel}: ",
                Location = new Point(_angleAlphaTanLabel.Right + 10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaCotLabel.Width = _angleAlphaCotLabel.PreferredWidth;
            _angleAlphaSecLabel = new Label()
            {
                Text = $"sec {configuration.AngleAlphaLabel}: ",
                Location = new Point(_angleAlphaCotLabel.Right + 10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaSecLabel.Width = _angleAlphaSecLabel.PreferredWidth;
            _angleAlphaCscLabel = new Label()
            {
                Text = $"csc {configuration.AngleAlphaLabel}: ",
                Location = new Point(_angleAlphaSecLabel.Right + 10, _angleAlphaRadLabel.Bottom),
            };
            _angleAlphaCscLabel.Width = _angleAlphaCscLabel.PreferredWidth;
            _groupBox.Controls.Add(_angleAlphaSinLabel);
            _groupBox.Controls.Add(_angleAlphaCosLabel);
            _groupBox.Controls.Add(_angleAlphaTanLabel);
            _groupBox.Controls.Add(_angleAlphaCotLabel);
            _groupBox.Controls.Add(_angleAlphaSecLabel);
            _groupBox.Controls.Add(_angleAlphaCscLabel);
            _angleBetaSinLabel = new Label()
            {
                Text = $"sin {configuration.AngleBetaLabel}: ",
                Location = new Point(10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaSinLabel.Width = _angleBetaSinLabel.PreferredWidth;
            _angleBetaCosLabel = new Label()
            {
                Text = $"cos {configuration.AngleBetaLabel}: ",
                Location = new Point(_angleBetaSinLabel.Right + 10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaCosLabel.Width = _angleBetaCosLabel.PreferredWidth;
            _angleBetaTanLabel = new Label()
            {
                Text = $"tan {configuration.AngleBetaLabel}: ",
                Location = new Point(_angleBetaCosLabel.Right + 10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaTanLabel.Width = _angleBetaTanLabel.PreferredWidth;
            _angleBetaCotLabel = new Label()
            {
                Text = $"cot {configuration.AngleBetaLabel}: ",
                Location = new Point( _angleBetaTanLabel.Right + 10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaCotLabel.Width = _angleBetaCotLabel.PreferredWidth;
            _angleBetaSecLabel = new Label()
            {
                Text = $"sec {configuration.AngleBetaLabel}: ",
                Location = new Point(_angleBetaCotLabel.Right + 10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaSecLabel.Width = _angleBetaSecLabel.PreferredWidth;
            _angleBetaCscLabel = new Label()
            {
                Text = $"csc {configuration.AngleBetaLabel}: ",
                Location = new Point(_angleBetaSecLabel.Right + 10, _angleAlphaSinLabel.Bottom),
            };
            _angleBetaCscLabel.Width = _angleBetaCscLabel.PreferredWidth;
            _groupBox.Controls.Add(_angleBetaSinLabel);
            _groupBox.Controls.Add(_angleBetaCosLabel);
            _groupBox.Controls.Add(_angleBetaTanLabel);
            _groupBox.Controls.Add(_angleBetaCotLabel);
            _groupBox.Controls.Add(_angleBetaSecLabel);
            _groupBox.Controls.Add(_angleBetaCscLabel);

            _groupBox.Size = _groupBox.PreferredSize;
            controlContainer.Add(_groupBox);
        }
        public void UpdateLabels()
        {
            if (Configuration is null || CurrentAdditionalData is null) throw new ArgumentException("Configuration or additional data is null.");
            _angleAlphaRadLabel.Text = $"{Configuration.AngleAlphaLabel} (рад.): {Math.Round(CurrentAdditionalData.AngleAlphaRad, Properties.DecimalAccuracy)}";
            _angleAlphaRadLabel.Width = _angleAlphaRadLabel.PreferredWidth;
            _angleAlphaRadLabel.Location = new Point(10, 30);

            _angleBetaRadLabel.Text = $"{Configuration.AngleBetaLabel} (рад.): {Math.Round(CurrentAdditionalData.AngleBetaRad, Properties.DecimalAccuracy)}";
            _angleBetaRadLabel.Width = _angleBetaRadLabel.PreferredWidth;
            _angleBetaRadLabel.Location = new Point(_angleAlphaRadLabel.Right + 10, 30);

            _angleAlphaDegLabel.Text = $"{Configuration.AngleAlphaLabel} (град.): {Math.Round(CurrentAdditionalData.AngleAlphaDeg, Properties.DecimalAccuracy)}";
            _angleAlphaDegLabel.Width = _angleAlphaDegLabel.PreferredWidth;
            _angleAlphaDegLabel.Location = new Point(_angleBetaRadLabel.Right + 10, 30);

            _angleBetaDegLabel.Text = $"{Configuration.AngleBetaLabel} (град.): {Math.Round(CurrentAdditionalData.AngleBetaDeg, Properties.DecimalAccuracy)}";
            _angleBetaDegLabel.Width = _angleBetaDegLabel.PreferredWidth;
            _angleBetaDegLabel.Location = new Point(_angleAlphaDegLabel.Right + 10, 30);

            _hypotenuseLabel.Text = $"{Configuration.HypotenuseLabel}: {Math.Round(CurrentAdditionalData.Hypotenuse, Properties.DecimalAccuracy)}";
            _hypotenuseLabel.Width = _hypotenuseLabel.PreferredWidth;
            _hypotenuseLabel.Location = new Point(_angleBetaDegLabel.Right + 10, 30);

            _adjacentLegLabel.Text = $"{Configuration.AdjacentLegLabel}: {Math.Round(CurrentAdditionalData.AdjacentLeg, Properties.DecimalAccuracy)}";
            _adjacentLegLabel.Width = _adjacentLegLabel.PreferredWidth;
            _adjacentLegLabel.Location = new Point(_hypotenuseLabel.Right + 10, 30);

            _oppositeLegLabel.Text = $"{Configuration.OppositeLegLabel}: {Math.Round(CurrentAdditionalData.OppositeLeg, Properties.DecimalAccuracy)}";
            _oppositeLegLabel.Width = _oppositeLegLabel.PreferredWidth;
            _oppositeLegLabel.Location = new Point(_adjacentLegLabel.Right + 10, 30);

            _areaLabel.Text = $"S: {Math.Round(CurrentAdditionalData.Area, Properties.DecimalAccuracy)}";
            _areaLabel.Width = _areaLabel.PreferredWidth;
            _areaLabel.Location = new Point(_oppositeLegLabel.Right + 10, 30);

            _perimeterLabel.Text = $"P: {Math.Round(CurrentAdditionalData.Perimeter, Properties.DecimalAccuracy)}";
            _perimeterLabel.Width = _perimeterLabel.PreferredWidth;
            _perimeterLabel.Location = new Point(_areaLabel.Right + 10, 30);

            _angleAlphaSinLabel.Text = $"sin {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaSin, Properties.DecimalAccuracy)};";
            _angleAlphaSinLabel.Width = _angleAlphaSinLabel.PreferredWidth;

            _angleAlphaCosLabel.Text = $"cos {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaCos, Properties.DecimalAccuracy)};";
            _angleAlphaCosLabel.Width = _angleAlphaCosLabel.PreferredWidth;
            _angleAlphaCosLabel.Location = new Point(_angleAlphaSinLabel.Right + 10, _angleAlphaRadLabel.Bottom);

            _angleAlphaTanLabel.Text = $"tan {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaTan, Properties.DecimalAccuracy)};";
            _angleAlphaTanLabel.Width = _angleAlphaTanLabel.PreferredWidth;
            _angleAlphaTanLabel.Location = new Point(_angleAlphaCosLabel.Right + 10, _angleAlphaRadLabel.Bottom);

            _angleAlphaCotLabel.Text = $"cot {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaCot, Properties.DecimalAccuracy)};";
            _angleAlphaCotLabel.Width = _angleAlphaCotLabel.PreferredWidth;
            _angleAlphaCotLabel.Location = new Point(_angleAlphaTanLabel.Right + 10, _angleAlphaRadLabel.Bottom);

            _angleAlphaSecLabel.Text = $"sec {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaSec, Properties.DecimalAccuracy)};";
            _angleAlphaSecLabel.Width = _angleAlphaSecLabel.PreferredWidth;
            _angleAlphaSecLabel.Location = new Point(_angleAlphaCotLabel.Right + 10, _angleAlphaRadLabel.Bottom);

            _angleAlphaCscLabel.Text = $"csc {Configuration.AngleAlphaLabel}: {Math.Round(CurrentAdditionalData.AngleAlphaCsc, Properties.DecimalAccuracy)};";
            _angleAlphaCscLabel.Width = _angleAlphaCscLabel.PreferredWidth;
            _angleAlphaCscLabel.Location = new Point(_angleAlphaSecLabel.Right + 10, _angleAlphaRadLabel.Bottom);

            _angleBetaSinLabel.Text = $"sin {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaSin, Properties.DecimalAccuracy)};";
            _angleBetaSinLabel.Width = _angleBetaSinLabel.PreferredWidth;
            _angleBetaSinLabel.Location = new Point(10, _angleAlphaSinLabel.Bottom);

            _angleBetaCosLabel.Text = $"cos {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaCos, Properties.DecimalAccuracy)};";
            _angleBetaCosLabel.Width = _angleBetaCosLabel.PreferredWidth;
            _angleBetaCosLabel.Location = new Point(_angleBetaSinLabel.Right + 10, _angleAlphaSinLabel.Bottom);

            _angleBetaTanLabel.Text = $"tan {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaTan, Properties.DecimalAccuracy)};";
            _angleBetaTanLabel.Width = _angleBetaTanLabel.PreferredWidth;
            _angleBetaTanLabel.Location = new Point(_angleBetaCosLabel.Right + 10, _angleAlphaSinLabel.Bottom);

            _angleBetaCotLabel.Text = $"cot {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaCot, Properties.DecimalAccuracy)};";
            _angleBetaCotLabel.Width = _angleBetaCotLabel.PreferredWidth;
            _angleBetaCotLabel.Location = new Point(_angleBetaTanLabel.Right + 10, _angleAlphaSinLabel.Bottom);

            _angleBetaSecLabel.Text = $"sec {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaSec, Properties.DecimalAccuracy)};";
            _angleBetaSecLabel.Width = _angleBetaSecLabel.PreferredWidth;
            _angleBetaSecLabel.Location = new Point(_angleBetaCotLabel.Right + 10, _angleAlphaSinLabel.Bottom);

            _angleBetaCscLabel.Text = $"csc {Configuration.AngleBetaLabel}: {Math.Round(CurrentAdditionalData.AngleBetaCsc, Properties.DecimalAccuracy)};";
            _angleBetaCscLabel.Width = _angleBetaCscLabel.PreferredWidth;
            _angleBetaCscLabel.Location = new Point(_angleBetaSecLabel.Right + 10, _angleAlphaSinLabel.Bottom);

            _groupBox.Size = _groupBox.PreferredSize;
        }
    }
}
