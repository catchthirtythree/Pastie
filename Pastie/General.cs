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

        public static System.Drawing.Image Base64ToString(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            using (MemoryStream stream = new MemoryStream())
            {
                // write the image bytes to the stream
                stream.Write(bytes, 0, bytes.Length);

                // get the image from stream
                Image image = Image.FromStream(stream, true);

                // return image
                return image;
            }
        }
    }
}
