using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Utilities;

namespace Pastie
{
    public partial class PastieForm : Form
    {
        private GlobalHotkey _ghk;

        private IContainer _container;
        private ContextMenu _contextMenu;
        private MenuItem _aboutMenuItem;
        private MenuItem _settingsMenuItem;
        private MenuItem _closeMenuItem;
        private NotifyIcon _notifyIcon;

        private Imgur _imgur;

        private Point _init, _current;
        private bool _moving = false;

        public PastieForm()
        {
            InitializeComponent();

            // Initialize variables
            _ghk = new GlobalHotkey(Constants.NOMOD, Keys.D1, this);
            _ghk.Register();

            _container = new Container();
            _contextMenu = new ContextMenu();
            _aboutMenuItem = new MenuItem();
            _settingsMenuItem = new MenuItem();
            _closeMenuItem = new MenuItem();

            // Initialize context menu
            _contextMenu.MenuItems.AddRange(new MenuItem[] { 
                _aboutMenuItem,
                _settingsMenuItem,
                _closeMenuItem
            });

            // Initialize _menuItems
            _aboutMenuItem.Text = "About Pastie";
            _aboutMenuItem.Click += new EventHandler(AboutMenuItem_Click);

            _settingsMenuItem.Text = "Settings";
            _settingsMenuItem.Click += new EventHandler(SettingsMenuItem_Click);

            _closeMenuItem.Text = "Close Pastie";
            _closeMenuItem.Click += new EventHandler(ExitMenuItem_Click);

            // Initialize notify icon
            _notifyIcon = new NotifyIcon(_container);
            _notifyIcon.Icon = Utilities.Properties.Resources.appicon;
            _notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            _notifyIcon.Text = "Pastie";
            _notifyIcon.Visible = true;

            // Set context menu
            _notifyIcon.ContextMenu = _contextMenu;

            // Initialize imgur
            _imgur = new Imgur();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.Visible && !this._moving && e.KeyCode == Keys.Enter)
            {
                this.Hide();

                ImgurResponse response = _imgur.UploadImage(Screenshot.Take(_init.X, _init.Y, _current.X, _current.Y), ImageFormat.Png);
                if (response.success)
                {
                    Console.WriteLine((response.data.size / 1000) + "kb");
                    Clipboard.SetText(response.data.link);
                    _notifyIcon.BalloonTipText = "Link copied to clipboard.";
                }
                else
                {
                    _notifyIcon.BalloonTipText = "Upload failed.";
                }

                _notifyIcon.ShowBalloonTip(3000);
            }

            if (this.Visible && !this._moving && e.KeyCode == Keys.Escape)
            {
                this.Hide();
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

        private void AboutMenuItem_Click(object Sender, EventArgs e)
        {
            // Show about form
        }

        private void SettingsMenuItem_Click(object Sender, EventArgs e)
        {
            // Show settings
        }

        private void ExitMenuItem_Click(object Sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PastieForm_Paint(object sender, PaintEventArgs e)
        {
            if (this._moving)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), _init.X, _init.Y, _current.X - _init.X, _current.Y - _init.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this._moving = false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                if (this.Visible)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }
    }
}