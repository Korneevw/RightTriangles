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
                Drawer.DrawInRatios(Data, e.Graphics, new Point(100, 100));
            }
            base.OnPaint(e);
        }
        public DrawingForm(IRightTriangleDrawer drawer, RightTriangleData data, IRightTriangleValidator validator)
        {
            Button b = new Button();
            b.Click += (s, e) => { using (Bitmap bitmap = new Bitmap(Width, Height)) { DrawToBitmap(bitmap, new Rectangle(0, 0, Width, Height)); bitmap.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screen.png")); } };
            Controls.Add(b);
            Drawer = drawer;
            Data = data;
            Validator = validator;
            InitializeComponent();
            AutoSize = false;
            Size = new Size(500, 500);
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "Drawing";
        }
        public void ChangeSize()
        {
            if (Validator.Validate(Data) == false) return;
            Size drawingSize = Drawer.GetTriangleDrawingSizeRatios(Data);
            Size = new Size(150 + drawingSize.Width + 150, 150 + drawingSize.Height + 150);
        }
    }
}
