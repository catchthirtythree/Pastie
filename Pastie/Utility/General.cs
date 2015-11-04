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
        public static ImageFormat GetImageFormatFromString(string format)
        {
            switch (format)
            {
                case "Bmp": return ImageFormat.Bmp;
                case "Emf": return ImageFormat.Emf;
                case "Exif": return ImageFormat.Exif;
                case "Gif": return ImageFormat.Gif;
                case "Icon": return ImageFormat.Icon;
                case "Jpeg": return ImageFormat.Jpeg;
                case "MemoryBmp": return ImageFormat.MemoryBmp;
                case "Png": return ImageFormat.Png;
                case "Tiff": return ImageFormat.Tiff;
                case "Wmf": return ImageFormat.Wmf;
                default: return ImageFormat.Png;
            }
        }

        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, format);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static System.Drawing.Image Base64ToString(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                return Image.FromStream(stream, true);
            }
        }
    }
}
