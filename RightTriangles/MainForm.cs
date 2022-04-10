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
        private IRightTriangleDrawer _drawer;
        private RightTriangleData _currentData;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            _drawer?.Draw(_currentData, e.Graphics, new Point(100, 100));
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
                OppositeLeg = 200
            };
            RightTriangleData hypAngle = new RightTriangleData()
            {
                Hypotenuse = 300,
                AngleAlpha = Math.PI / 6
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

            BuildModeSelector modeSelector = new BuildModeSelector(buildModes);
            //for (int i = 0; i < rightTriangleDatas.Length; i++)
            //{
            //    RightTriangleData data = rightTriangleDatas[i];

            //    IBuildModeConditionContaining mode = modeSelector.CheckConditions(data);
            //    RightTriangleData builtData = mode.Build(data);
            //    validationsForDatas[i] = validator.Validate(builtData);

            //    Label l = new Label()
            //    {
            //        Text = validationsForDatas[i].ToString(),
            //        ForeColor = validationsForDatas[i] == true ? Color.Green : Color.Red,
            //        Font = new Font("Arial", 40),
            //        AutoSize = true,
            //        Location = new Point(0, 0 + 50 * i)
            //    };
            //    Controls.Add(l);
            //}

            //RightTriangleData currentData = hypOppositeLeg;
            //Label currentDataLabel = new Label()
            //{
            //    Location = new Point(0, 0),
            //    Text = $"Given Data:\nHypotenuse: {currentData.Hypotenuse}\nAdjacent Leg: {currentData.AdjacentLeg}\nOpposite Leg: {currentData.OppositeLeg}\nAngle Alpha: {currentData.AngleAlpha}\nAngle Beta: {currentData.AngleBeta}",
            //    AutoSize = true,
            //};

            //IBuildModeConditionContaining mode = modeSelector.CheckConditions(currentData);
            //Label currentModeLabel = new Label()
            //{
            //    Location = new Point(0, 100),
            //    Text = mode.GetType().Name,
            //    AutoSize = true,
            //};

            //RightTriangleData builtData = mode.Build(currentData);
            //Label builtDataLabel = new Label()
            //{
            //    Location = new Point(0, 130),
            //    Text = $"Built Data:\nHypotenuse: {builtData.Hypotenuse}\nAdjacent Leg: {builtData.AdjacentLeg}\nOpposite Leg: {builtData.OppositeLeg}\nAngle Alpha: {builtData.AngleAlpha}\nAngle Beta: {builtData.AngleBeta}",
            //    AutoSize = true,
            //};

            //bool validated = validator.Validate(builtData);
            //Label validatedLabel = new Label()
            //{
            //    Location = new Point(0, 230),
            //    Text = $"Built Data validated? " + (validated ? "Yes" : "No"),
            //    AutoSize = true,
            //};

            //Controls.AddRange(new Control[] { currentDataLabel, currentModeLabel, builtDataLabel, validatedLabel });

            _drawer = new ColoredRightTriangleDrawer(new Pen(Color.Red, 5), new Pen(Color.Green, 5), new Pen(Color.Blue, 5));
            _currentData = modeSelector.SelectMode(hypAngle).Build(hypAngle);
            InitializeComponent();
        }
    }
}
