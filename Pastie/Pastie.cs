using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using Utilities;

namespace Pastie
{
    class Pastie : ApplicationContext
    {
        private GlobalKeyboardHook _gkh;
        private SelectionForm _selectionForm;

        private IContainer _container;
        private ContextMenu _contextMenu;
        private MenuItem _aboutMenuItem;
        private MenuItem _settingsMenuItem;
        private MenuItem _closeMenuItem;
        private NotifyIcon _notifyIcon;

        public Pastie()
        {
            // Initialize variables
            _gkh = new GlobalKeyboardHook();
            _gkh.HookedKeys.Add(Keys.LControlKey);
            _gkh.HookedKeys.Add(Keys.LMenu);
            _gkh.HookedKeys.Add(Keys.D1);
            _gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);

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
            _notifyIcon.Text = "Pastie";
            _notifyIcon.Visible = true;

            // Set context menu
            _notifyIcon.ContextMenu = _contextMenu;
        }

        /* I can save keyChars and add them to the globalhotkey from properties thing using this
         * KeysConverter kc = new KeysConverter();
         * string keyChar = kc.ConvertToString(keyData);
         */
        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                /* There's probably a better way to do this but it works for now. */
                if (_selectionForm == null)
                {
                    _selectionForm = new SelectionForm();
                    _selectionForm.Show();
                }
                else
                {
                    _selectionForm.Close();
                    _selectionForm = null;
                }
            }

            e.Handled = true;
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
            base.ExitThreadCore();
        }
    }
}