using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Utilities
{
    class SelectionForm : Form
    {
        private Point _init, _current;
        private bool _moving = false;

        public SelectionForm()
        {
            InitializeComponent();

            //Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void SelectionForm_Paint(object sender, PaintEventArgs e)
        {
            if (this._moving)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), _init.X, _init.Y, _current.X - _init.X, _current.Y - _init.Y);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!this._moving && e.KeyCode == Keys.Enter)
            {
                this.Dispose();

                Form showImage = new ImageForm(Screenshot.Take(_init.X, _init.Y, _current.X, _current.Y));
                showImage.Show();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this._moving = true;
            this._init = MousePosition;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this._moving)
            {
                //this.Location = _init;
                this._current = new Point(e.X, e.Y);
                //this.Bounds = new Rectangle(_init, new Size(_current);
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this._moving = false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Opacity = 0.4D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Auto;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SelectionForm_Paint);
            this.ResumeLayout(false);
        }
    }
}