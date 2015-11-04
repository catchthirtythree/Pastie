using Pastie;
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
    class Imgur
    {
        private static string CLIENT_ID = "";
        private static string UPLOAD_URL = "https://api.imgur.com/3/upload.json";

        public ImgurResponse UploadImage(Image bmp)
        {
            using (var webclient = new WebClient())
            {
                try
                {
                    webclient.Headers.Add("Authorization", "Client-ID " + CLIENT_ID);

                    var values = new NameValueCollection
                    {
                        { "image", General.ImageToBase64(bmp, Pastie.Properties.Settings.Default.ImageFormat) }
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
    }

    public class ImgurResponse
    {
        public class Data
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int datetime { get; set; }
            public string type { get; set; }
            public bool animated { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int size { get; set; }
            public int views { get; set; }
            public int bandwidth { get; set; }
            public string vote { get; set; }
            public bool favorite { get; set; }
            public string nsfw { get; set; }
            public string section { get; set; }
            public string account_url { get; set; }
            public int account_id { get; set; }
            public string comment_preview { get; set; }
            public string deletehash { get; set; }
            public string name { get; set; }
            public string link { get; set; }

            public override string ToString()
            {
                return "[id = " + id
                    + ", title = " + title
                    + ", description = " + description
                    + ", datetime = " + datetime
                    + ", width = " + width
                    + ", height = " + height
                    + ", animated = " + animated
                    + ", name = " + name
                    + ", link = " + link
                    + "]";
            }
        }

        public Data data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }

        public override string ToString()
        {
            return "[data = " + data
                + ", success = " + success
                + ", status = " + status
                + "]";
        }
    }
}
