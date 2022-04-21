using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace RightTriangles
{
    public partial class MainForm : Form
    {
        private BuildModeSelector _builtModeSelector;
        private IRightTriangleDrawer _drawer;
        private IRightTriangleDataInput _dataInput;
        private RightTriangleData _currentData = new RightTriangleData();
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            try
            {
                _drawer?.Draw(_currentData, e.Graphics, new Point(300, 100)/*, 300*/);
            }
            catch (ArgumentException) { }
            base.OnPaint(e);
        }
        public MainForm()
        {
            RightTriangleData adjacentLegAngle = new RightTriangleData()
            {
                AdjacentLeg = 350,
                AngleAlpha = Math.PI / 3
            };
            RightTriangleData oppositeLegAngle = new RightTriangleData()
            {
                OppositeLeg = 15,
                AngleAlpha = Math.PI / 6
            };
            RightTriangleData adjacentLegOppositeLeg = new RightTriangleData()
            {
                AdjacentLeg = 500,
                OppositeLeg = 500
            };
            RightTriangleData hypAngle = new RightTriangleData()
            {
                Hypotenuse = 1000,
                AngleAlpha = Math.PI / 3
            };
            RightTriangleData hypOppositeLeg = new RightTriangleData()
            {
                Hypotenuse = 40,
                OppositeLeg = 10
            };
            RightTriangleData hypAdjacentLeg = new RightTriangleData()
            {
                Hypotenuse = 200,
                AdjacentLeg = 100
            };

            RightTriangleData[] rightTriangleDatas = new RightTriangleData[]
            {
                adjacentLegAngle,
                oppositeLegAngle,
                adjacentLegOppositeLeg,
                hypAngle,
                hypOppositeLeg,
                hypAdjacentLeg
            };
            IBuildMode[] buildModes = new IBuildMode[]
            {
                new AdjacentLegAngleBuildMode(),
                new OppositeLegAngleBuildMode(),
                new AdjacentLegOppositeLegBuildMode(),
                new HypotenuseAngleBuildMode(),
                new HypotenuseOppositeLegBuildMode(),
                new HypotenuseAdjacentLegBuildMode()
            };

            bool[] validationsForDatas = new bool[rightTriangleDatas.Length];

            _builtModeSelector = new BuildModeSelector(buildModes);
            RightTriangleDrawerConfiguration configuration = new RightTriangleDrawerConfiguration()
            {
                AngleArcSize = 20,
                AngleLabelDistance = 20,
            };
            _drawer = new RightTriangleDrawer(configuration);
            _dataInput = new RightTriangleDataInput(Controls, new Point(0, 0));
            _dataInput.AnyValueChanged += OnValueChanged;
            //_currentData = modeSelector.SelectMode(_dataInput.InputData).Build(_dataInput.InputData);
            InitializeComponent();
        }

        private void OnValueChanged()
        {
            _currentData = _builtModeSelector.SelectMode(_dataInput.InputData).Build(_dataInput.InputData);
            this.Refresh();
        }
    }
}
