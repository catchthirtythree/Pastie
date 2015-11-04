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
using System.Threading;
using System.Globalization;

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

        private Properties.Settings _settings = Properties.Settings.Default;

        public PastieForm()
        {
            InitializeComponent();

            _ghk = new GlobalHotkey(_settings.HotkeyModifier, _settings.HotkeyKey, this);
            _ghk.Register();

            _container = new Container();
            _contextMenu = new ContextMenu();   
            _aboutMenuItem = new MenuItem();
            _settingsMenuItem = new MenuItem();
            _closeMenuItem = new MenuItem();

            _contextMenu.MenuItems.AddRange(new MenuItem[] {
                _settingsMenuItem,
                _closeMenuItem
            });

            _settingsMenuItem.Text = "Settings";
            _settingsMenuItem.Click += new EventHandler(SettingsMenuItem_Click);

            _closeMenuItem.Text = "Close Pastie";
            _closeMenuItem.Click += new EventHandler(ExitMenuItem_Click);

            _notifyIcon = new NotifyIcon(_container);
            _notifyIcon.Icon = Properties.Resources.appicon;
            _notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            _notifyIcon.Text = "Pastie";
            _notifyIcon.Visible = _settings.ShowTaskIcon;

            _notifyIcon.ContextMenu = _contextMenu;

            _imgur = new Imgur();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.Visible && !this._moving && e.KeyCode == Keys.Enter)
            {
                this.Hide();

                ImgurResponse response = _imgur.UploadImage(Screenshot.Take(_init.X, _init.Y, _current.X, _current.Y));
                if (response.success)
                {
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
            if (this._moving)
            {
                this._current = new Point(e.X, e.Y);
                this.Refresh();
            }
        }

        private void SettingsMenuItem_Click(object Sender, EventArgs e)
        {
            new SettingsForm().Show();

            // Register the new key bind
            _ghk.Unregister();
            _ghk.Key = _settings.HotkeyKey;
            _ghk.Modifier = _settings.HotkeyModifier;
            _ghk.Register();
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