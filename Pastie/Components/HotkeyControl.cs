using System;
using System.Collections;
using System.Windows.Forms;

//
// Hotkey selection control, written by serenity@exscape.org, 2006-08-03
// Please mail me if you find a bug.
//

namespace Pastie
{
    /// <summary>
    /// A simple control that allows the user to select pretty much any valid hotkey combination
    /// </summary>
    public class HotkeyControl : TextBox
    {
        private Keys _hotkey = Keys.None;
        private ContextMenu dummy = new ContextMenu();

        /// <summary>
        /// Used to make sure that there is no right-click menu available
        /// </summary>
        public override ContextMenu ContextMenu
        {
            get
            {
                return dummy;
            }
            set
            {
                base.ContextMenu = dummy;
            }
        }

        /// <summary>
        /// Forces the control to be non-multiline
        /// </summary>
        public override bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                base.Multiline = false;
            }
        }

        /// <summary>
        /// Creates a new HotkeyControl
        /// </summary>
        public HotkeyControl()
        {
            this.ContextMenu = dummy;
            this.Text = "None";

            this.KeyPress += new KeyPressEventHandler(HotkeyControl_KeyPress);
            this.KeyUp += new KeyEventHandler(HotkeyControl_KeyUp);
            this.KeyDown += new KeyEventHandler(HotkeyControl_KeyDown);
        }

        /// <summary>
        /// Resets this hotkey control to None
        /// </summary>
        public new void Clear()
        {
            this.Hotkey = Keys.None;
        }

        /// <summary>
        /// Fires when a key is pushed down. Here, we'll want to update the text in the box
        /// to notify the user what combination is currently pressed.
        /// </summary>
        void HotkeyControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Clear the current hotkey
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                ResetHotkey();
                return;
            }
            else
            {
                this._hotkey = e.KeyCode;
                Redraw();
            }
        }

        /// <summary>
        /// Fires when all keys are released. If the current hotkey isn't valid, reset it.
        /// Otherwise, do nothing and keep the text and hotkey as it was.
        /// </summary>
        void HotkeyControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this._hotkey == Keys.None)
            {
                ResetHotkey();
                return;
            }
        }

        /// <summary>
        /// Prevents the letter/whatever entered to show up in the TextBox
        /// Without this, a "A" key press would appear as "aControl, Alt + A"
        /// </summary>
        void HotkeyControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Handles some misc keys, such as Ctrl+Delete and Shift+Insert
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.Delete))
            {
                ResetHotkey();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Insert)) // Paste
                return true; // Don't allow

            // Allow the rest
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Clears the current hotkey and resets the TextBox
        /// </summary>
        public void ResetHotkey()
        {
            this._hotkey = Keys.None;
            Redraw();
        }

        /// <summary>
        /// Used to get/set the hotkey (e.g. Keys.A)
        /// </summary>
        public Keys Hotkey
        {
            get
            {
                return this._hotkey;
            }
            set
            {
                this._hotkey = value;
                Redraw(true);
            }
        }

        /// <summary>
        /// Helper function
        /// </summary>
        private void Redraw()
        {
            Redraw(false);
        }

        /// <summary>
        /// Redraws the TextBox when necessary.
        /// </summary>
        /// <param name="bCalledProgramatically">Specifies whether this function was called by the Hotkey/HotkeyModifiers properties or by the user.</param>
        private void Redraw(bool bCalledProgramatically)
        {
            // No hotkey set
            if (this._hotkey == Keys.None)
            {
                this.Text = "None";
                return;
            }

            // LWin/RWin doesn't work as hotkeys (neither do they work as modifier keys in .NET 2.0)
            if (this._hotkey == Keys.LWin || this._hotkey == Keys.RWin)
            {
                this.Text = "None";
                return;
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (this._hotkey == Keys.Menu /* Alt */ || this._hotkey == Keys.ShiftKey || this._hotkey == Keys.ControlKey)
                this._hotkey = Keys.None;

            this.Text = this._hotkey.ToString();
        }
    }
}