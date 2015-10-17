using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;

namespace Utilities
{
    class General
    {
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // save image to memory stream
                image.Save(stream, format);

                // get array of bytes from stream
                byte[] bytes = stream.ToArray();

                // convert byte array to Base64String
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
