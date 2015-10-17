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
        public static Image Take(int sourceX, int sourceY, int destX, int destY)
        {
            // Get the screen region size
            Size screenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Get the image size
            Size imageSize = new Size(destX - sourceX, destY - sourceY);

            // Create a new bitmap object
            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppArgb);

            // Create a new graphics object from the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Copy the screen into the bitmap
                g.CopyFromScreen(sourceX, sourceY, 0, 0, imageSize);

                // Save the image
                bmp.Save("test.png", ImageFormat.Png);
            }

            return bmp;
        }
    }
}