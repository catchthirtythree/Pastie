using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Pastie
{
    public partial class SettingsForm : Form
    {
        private string _appname = System.AppDomain.CurrentDomain.FriendlyName;
        private RegistryKey _registry = Registry.CurrentUser.OpenSubKey(Properties.Settings.Default.RegistryKey, true);

        public SettingsForm()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
            base.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void LoadSettings()
        {
            CheckStartWithWindows.Checked = _registry.GetValue(_appname) != null;

            CheckUpdate.Checked = Properties.Settings.Default.UpdateAutomatically;
            CheckShowTaskIcon.Checked = Properties.Settings.Default.ShowTaskIcon;
            ComboFormat.Text = Properties.Settings.Default.ImageFormat.ToString();
            CheckSave.Checked = Properties.Settings.Default.SaveScreenshots;

            TextboxHotkey.Hotkey = Properties.Settings.Default.HotkeyKey;

            int modifier = Properties.Settings.Default.HotkeyModifier;
            CheckShift.Checked = (modifier & Constants.SHIFT) == Constants.SHIFT;
            CheckCtrl.Checked = (modifier & Constants.CTRL) == Constants.CTRL;
            CheckAlt.Checked = (modifier & Constants.ALT) == Constants.ALT;
        }

        private void SaveSettings()
        {            
            if (CheckStartWithWindows.Checked)
            {
                _registry.SetValue(_appname, Application.ExecutablePath.ToString());
            }
            else
            {
                _registry.DeleteValue(_appname, false);
            }

            Properties.Settings.Default.UpdateAutomatically = CheckUpdate.Checked;
            Properties.Settings.Default.ShowTaskIcon = CheckShowTaskIcon.Checked;
            Properties.Settings.Default.ImageFormat = General.GetImageFormatFromString(ComboFormat.SelectedItem.ToString());
            Properties.Settings.Default.SaveScreenshots = CheckSave.Checked;

            Properties.Settings.Default.HotkeyKey = TextboxHotkey.Hotkey;

            int modifier = Constants.NOMOD;
            modifier |= CheckCtrl.Checked ? Constants.CTRL : Constants.NOMOD;
            modifier |= CheckAlt.Checked ? Constants.ALT : Constants.NOMOD;
            modifier |= CheckShift.Checked ? Constants.SHIFT : Constants.NOMOD;
            Properties.Settings.Default.HotkeyModifier = modifier;

            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Save();
        }
    }
}