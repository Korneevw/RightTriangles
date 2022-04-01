namespace RightTriangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            RightTriangleData data = new RightTriangleData() // Правильный
            {
                Hypotenuse = 5,
                AdjacentLeg = 3,
                OppositeLeg = 4,
                AngleAlpha = Math.PI / 6,
                AngleBeta = Math.PI / 3,
            };
            RightTriangleData hypAngleData = new RightTriangleData() // Правильный
            {
                Hypotenuse = 5,
                AngleAlpha = 0.926,
            };
            RightTriangleData dataWrong = new RightTriangleData() // Неправильный
            {
                Hypotenuse = 7,
                AdjacentLeg = 3,
                OppositeLeg = 4,
                AngleAlpha = Math.PI / 6,
                AngleBeta = Math.PI / 3,
            };
            HypotenuseAngleBuildModeCondition condition = new HypotenuseAngleBuildModeCondition(hypAngleData);
            IBuildMode? mode = condition.CheckCondition();
            RightTriangleData? builtData = mode?.Build();
            RightTriangleDataValidator validator = new RightTriangleDataValidator(builtData);
            Label l = new Label()
            {
                Text = validator.Validate().ToString(),
            };
            Controls.Add(l);
            InitializeComponent();
        }
    }
}