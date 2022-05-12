namespace RightTriangles
{
    public partial class DrawingForm : Form
    {
        public IRightTriangleDrawer Drawer;
        public RightTriangleData Data;
        public IRightTriangleValidator Validator;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Validator.Validate(Data) == true)
            {
                Drawer.DrawInRatios(Data, e.Graphics, new Point(150, 150));
                using (Bitmap bmp = new Bitmap(150 + Drawer.GetTriangleRatiosDrawingSize(Data).Width + 150, 150 + Drawer.GetTriangleRatiosDrawingSize(Data).Height + 150))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        Drawer.DrawInRatios(Data, g, new Point(150, 150));
                    }
                    bmp.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "iimage.png"));
                }
            }
            else
            {
                e.Graphics.Clear(BackColor);
            }
            base.OnPaint(e);
        }
        public DrawingForm(IRightTriangleDrawer drawer, RightTriangleData data, IRightTriangleValidator validator)
        {
            Drawer = drawer;
            Data = data;
            Validator = validator;
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
