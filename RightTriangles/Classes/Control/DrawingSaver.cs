using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RightTriangles
{
    public class DrawingSaver : IDrawingSaver
    {
        public void Save(RightTriangleData data, IRightTriangleDrawer drawer)
        {
            using (Bitmap bmp = new Bitmap(150 + drawer.GetTriangleRatiosDrawingSize(data).Width + 150, 150 + drawer.GetTriangleRatiosDrawingSize(data).Height + 150))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    drawer.DrawInRatios(data, g, new Point(150, 150));
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Картинки|*.png";
                saveFileDialog.Title = "Выберите расположение файла";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    bmp.Save(Path.Combine(saveFileDialog.FileName));
                }
            }
        }
    }
}
