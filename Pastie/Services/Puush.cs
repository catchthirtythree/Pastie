using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Utilities
{
    class Puush
    {

        // https://github.com/sgoo/puush-linux/blob/master/src/multipart.py 
        // https://github.com/sgoo/puush-linux/blob/master/src/puush.py 
        // https://github.com/blha303/puush-linux/blob/master/apiDocumentation.md

        private static readonly string CLIENT_AUTH = "2290d9d2b77a53d7:f026e4b870137d00";
        private static readonly string CLIENT_ID = "2290D9D2B77A53D7F026E4B870137D00";
        private static readonly string UPLOAD_URL = "https://puush.me/api/up";

        public ImgurResponse UploadImage(Image bmp, ImageFormat format)
        {
            using (var webclient = new WebClient())
            {
                try
                {
                    webclient.Headers.Add("Authorization", "Basic " + CLIENT_AUTH);

                    var values = new NameValueCollection
                    {
                        { "k", CLIENT_ID },
                        { "media", General.ImageToBase64(bmp, format) }
                    };

                    var response = System.Text.Encoding.Default.GetString(webclient.UploadValues(UPLOAD_URL, values));

                    return new JavaScriptSerializer().Deserialize<ImgurResponse>(response);
                }
                catch (WebException)
                {
                    return new ImgurResponse() { success = false };
                }
            }
        }

        public string GetContentType(string fname)
        {
            // set a default mimetype if not found.
            string contentType = "application/octet-stream";

            try
            {
                // get the registry classes root
                RegistryKey classes = Registry.ClassesRoot;

                // find the sub key based on the file extension
                RegistryKey fileClass = classes.OpenSubKey(Path.GetExtension(fname));
                contentType = fileClass.GetValue("Content Type").ToString();
            }
            catch { }

            return contentType;
        }
    }
}