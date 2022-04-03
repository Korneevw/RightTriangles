using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightTriangles
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            RightTriangleData adjacentLegAngle = new RightTriangleData()
            {
                AdjacentLeg = 15,
                AngleAlpha = Math.PI / 3
            };
            RightTriangleData oppositeLegAngle = new RightTriangleData()
            {
                OppositeLeg = 15,
                AngleAlpha = Math.PI / 6
            };
            RightTriangleData adjacentLegOppositeLeg = new RightTriangleData()
            {
                AdjacentLeg = 10,
                OppositeLeg = 10
            };
            RightTriangleData hypAngle = new RightTriangleData()
            {
                Hypotenuse = 100,
                AngleAlpha = Math.PI / 6
            };
            RightTriangleData hypOppositeLeg = new RightTriangleData()
            {
                Hypotenuse = 40,
                OppositeLeg = 10
            };
            RightTriangleData hypAdjacentLeg = new RightTriangleData()
            {
                Hypotenuse = 20,
                AdjacentLeg = 10
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
            IBuildModeConditionContaining[] buildModes = new IBuildModeConditionContaining[]
            {
                new AdjacentLegAngleBuildMode(),
                new OppositeLegAngleBuildMode(),
                new AdjacentLegOppositeLegBuildMode(),
                new HypotenuseAngleBuildMode(),
                new HypotenuseOppositeLegBuildMode(),
                new HypotenuseAdjacentLegBuildMode()
            };

            bool[] validationsForDatas = new bool[rightTriangleDatas.Length];

            RightTriangleValidator validator = new RightTriangleValidator();
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
            RightTriangleData currentData = oppositeLegAngle;
            Label currentDataLabel = new Label()
            {
                Location = new Point(0, 0),
                Text = $"Given Data:\nHypotenuse: {currentData.Hypotenuse}\nAdjacent Leg: {currentData.AdjacentLeg}\nOpposite Leg: {currentData.OppositeLeg}\nAngle Alpha: {currentData.AngleAlpha}\nAngle Beta: {currentData.AngleBeta}",
                AutoSize = true,
            };

            IBuildModeConditionContaining mode = modeSelector.CheckConditions(currentData);
            Label currentModeLabel = new Label()
            {
                Location = new Point(0, 100),
                Text = mode.GetType().Name,
                AutoSize = true,
            };

            RightTriangleData builtData = mode.Build(currentData);
            Label builtDataLabel = new Label()
            {
                Location = new Point(0, 130),
                Text = $"Built Data:\nHypotenuse: {builtData.Hypotenuse}\nAdjacent Leg: {builtData.AdjacentLeg}\nOpposite Leg: {builtData.OppositeLeg}\nAngle Alpha: {builtData.AngleAlpha}\nAngle Beta: {builtData.AngleBeta}",
                AutoSize = true,
            };

            bool validated = validator.Validate(builtData);
            Label validatedLabel = new Label()
            {
                Location = new Point(0, 230),
                Text = $"Built Data validated? " + (validated ? "Yes" : "No"),
                AutoSize = true,
            };

            Controls.AddRange(new Control[] { currentDataLabel, currentModeLabel, builtDataLabel, validatedLabel });
            InitializeComponent();
        }
    }
}
