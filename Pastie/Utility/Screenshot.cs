using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
    static class Screenshot
    {
        private static Pastie.Properties.Settings _settings = Pastie.Properties.Settings.Default;
        public static Image Take(int sourceX, int sourceY, int destX, int destY, bool save = false)
        {
            Size screenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Size imageSize = new Size(destX - sourceX, destY - sourceY);

            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(sourceX, sourceY, 0, 0, imageSize);

                if (_settings.SaveScreenshots)
                {
                    ImageFormat format = _settings.ImageFormat;
                    bmp.Save(Pastie.Properties.Settings.Default.DateFormat + "." + format.ToString(), format);
                }
            }

            return bmp;
        }
    }
}