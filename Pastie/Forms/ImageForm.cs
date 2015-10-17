using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
    public partial class ImageForm : Form
    {
        public ImageForm(Image img)
        {
            InitializeComponent();

            Width = img.Width + 9;
            Height = img.Height + 32;
            image.Image = img;
        }
    }
}
