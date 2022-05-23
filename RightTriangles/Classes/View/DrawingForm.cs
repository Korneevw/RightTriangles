namespace RightTriangles
{
    public partial class DrawingForm : Form
    {
        public IRightTriangleDrawer Drawer;
        public RightTriangleData Data;
        public IRightTriangleValidator Validator;
        public IDrawingSaver Saver;
        private Button _saveButton;
        // Test comment
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Validator.Validate(Data) == true)
            {
                Drawer.DrawInRatios(Data, e.Graphics, new Point(150, 150));
            }
            else
            {
                e.Graphics.Clear(BackColor);
            }
            base.OnPaint(e);
        }
        public DrawingForm(IRightTriangleDrawer drawer, RightTriangleData data, IRightTriangleValidator validator, IDrawingSaver saver)
        {
            Drawer = drawer;
            Data = data;
            Validator = validator;
            Saver = saver;
            _saveButton = new Button()
            {
                Width = 100,
                Height = 25,
                Text = "Save drawing"
            };
            _saveButton.Click += (s, e) => { if (Validator.Validate(Data) == true) Saver.Save(Data, Drawer); };
            Controls.Add(_saveButton);
            InitializeComponent();
            AutoSize = false;
            Size = new Size(150, 150);
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Drawing";
        }
        public void ChangeSize()
        {
            if (Validator.Validate(Data) == false)
            {
                Size = new Size(150, 150);
                return;
            }
            Size drawingSize = Drawer.GetTriangleRatiosDrawingSize(Data);
            Size = new Size(150 + drawingSize.Width + 150, 150 + drawingSize.Height + 150);
        }
    }
}
