using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenCaptureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string imagesFolderPath = Path.Combine(desktopPath, "images");
            Directory.CreateDirectory(imagesFolderPath);
            int sscounter = 0;
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    sscounter++;
                    Rectangle bounds = Screen.GetBounds(Point.Empty);
                    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        }
                        string screenshotPath = Path.Combine(imagesFolderPath, $"screenshot_{sscounter}.png");
                        bitmap.Save(screenshotPath, ImageFormat.Png);
                    }
                }
            }
        }
    }
}
