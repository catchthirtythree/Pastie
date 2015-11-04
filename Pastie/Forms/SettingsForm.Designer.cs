namespace Pastie
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckStartWithWindows = new System.Windows.Forms.CheckBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ComboFormat = new System.Windows.Forms.ComboBox();
            this.LabelFormat = new System.Windows.Forms.Label();
            this.CheckUpdate = new System.Windows.Forms.CheckBox();
            this.GroupPastie = new System.Windows.Forms.GroupBox();
            this.GroupScreenshots = new System.Windows.Forms.GroupBox();
            this.CheckSave = new System.Windows.Forms.CheckBox();
            this.LabelHotkey = new System.Windows.Forms.Label();
            this.CheckCtrl = new System.Windows.Forms.CheckBox();
            this.CheckShift = new System.Windows.Forms.CheckBox();
            this.CheckAlt = new System.Windows.Forms.CheckBox();
            this.LabelModifiers = new System.Windows.Forms.Label();
            this.GroupHotkey = new System.Windows.Forms.GroupBox();
            this.CheckShowTaskIcon = new System.Windows.Forms.CheckBox();
            this.TextboxHotkey = new Pastie.HotkeyControl();
            this.GroupPastie.SuspendLayout();
            this.GroupScreenshots.SuspendLayout();
            this.GroupHotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckStartWithWindows
            // 
            this.CheckStartWithWindows.AutoSize = true;
            this.CheckStartWithWindows.Location = new System.Drawing.Point(9, 19);
            this.CheckStartWithWindows.Name = "CheckStartWithWindows";
            this.CheckStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.CheckStartWithWindows.TabIndex = 1;
            this.CheckStartWithWindows.Text = "Start with Windows";
            this.CheckStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(69, 261);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 2;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(150, 261);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ComboFormat
            // 
            this.ComboFormat.FormattingEnabled = true;
            this.ComboFormat.Items.AddRange(new object[] {
            "Bmp",
            "Emf",
            "Exif",
            "Gif",
            "Icon",
            "Jpeg",
            "MemoryBmp",
            "Png",
            "Tiff",
            "Wmf"});
            this.ComboFormat.Location = new System.Drawing.Point(86, 19);
            this.ComboFormat.Name = "ComboFormat";
            this.ComboFormat.Size = new System.Drawing.Size(121, 21);
            this.ComboFormat.TabIndex = 4;
            // 
            // LabelFormat
            // 
            this.LabelFormat.AutoSize = true;
            this.LabelFormat.Location = new System.Drawing.Point(6, 22);
            this.LabelFormat.Name = "LabelFormat";
            this.LabelFormat.Size = new System.Drawing.Size(74, 13);
            this.LabelFormat.TabIndex = 5;
            this.LabelFormat.Text = "Image Format:";
            // 
            // CheckUpdate
            // 
            this.CheckUpdate.AutoSize = true;
            this.CheckUpdate.Location = new System.Drawing.Point(9, 42);
            this.CheckUpdate.Name = "CheckUpdate";
            this.CheckUpdate.Size = new System.Drawing.Size(158, 17);
            this.CheckUpdate.TabIndex = 6;
            this.CheckUpdate.Text = "Update Pastie Automatically";
            this.CheckUpdate.UseVisualStyleBackColor = true;
            // 
            // GroupPastie
            // 
            this.GroupPastie.Controls.Add(this.CheckShowTaskIcon);
            this.GroupPastie.Controls.Add(this.CheckStartWithWindows);
            this.GroupPastie.Controls.Add(this.CheckUpdate);
            this.GroupPastie.Location = new System.Drawing.Point(12, 12);
            this.GroupPastie.Name = "GroupPastie";
            this.GroupPastie.Size = new System.Drawing.Size(213, 89);
            this.GroupPastie.TabIndex = 7;
            this.GroupPastie.TabStop = false;
            this.GroupPastie.Text = "Pastie";
            // 
            // GroupScreenshots
            // 
            this.GroupScreenshots.Controls.Add(this.CheckSave);
            this.GroupScreenshots.Controls.Add(this.LabelFormat);
            this.GroupScreenshots.Controls.Add(this.ComboFormat);
            this.GroupScreenshots.Location = new System.Drawing.Point(12, 107);
            this.GroupScreenshots.Name = "GroupScreenshots";
            this.GroupScreenshots.Size = new System.Drawing.Size(213, 71);
            this.GroupScreenshots.TabIndex = 8;
            this.GroupScreenshots.TabStop = false;
            this.GroupScreenshots.Text = "Screenshots";
            // 
            // CheckSave
            // 
            this.CheckSave.AutoSize = true;
            this.CheckSave.Location = new System.Drawing.Point(9, 46);
            this.CheckSave.Name = "CheckSave";
            this.CheckSave.Size = new System.Drawing.Size(149, 17);
            this.CheckSave.TabIndex = 6;
            this.CheckSave.Text = "Save Screenshots to Disk";
            this.CheckSave.UseVisualStyleBackColor = true;
            // 
            // LabelHotkey
            // 
            this.LabelHotkey.AutoSize = true;
            this.LabelHotkey.Location = new System.Drawing.Point(6, 22);
            this.LabelHotkey.Name = "LabelHotkey";
            this.LabelHotkey.Size = new System.Drawing.Size(28, 13);
            this.LabelHotkey.TabIndex = 6;
            this.LabelHotkey.Text = "Key:";
            // 
            // CheckCtrl
            // 
            this.CheckCtrl.AutoSize = true;
            this.CheckCtrl.Location = new System.Drawing.Point(69, 45);
            this.CheckCtrl.Name = "CheckCtrl";
            this.CheckCtrl.Size = new System.Drawing.Size(41, 17);
            this.CheckCtrl.TabIndex = 8;
            this.CheckCtrl.Text = "Ctrl";
            this.CheckCtrl.UseVisualStyleBackColor = true;
            // 
            // CheckShift
            // 
            this.CheckShift.AutoSize = true;
            this.CheckShift.Location = new System.Drawing.Point(116, 45);
            this.CheckShift.Name = "CheckShift";
            this.CheckShift.Size = new System.Drawing.Size(47, 17);
            this.CheckShift.TabIndex = 9;
            this.CheckShift.Text = "Shift";
            this.CheckShift.UseVisualStyleBackColor = true;
            // 
            // CheckAlt
            // 
            this.CheckAlt.AutoSize = true;
            this.CheckAlt.Location = new System.Drawing.Point(169, 45);
            this.CheckAlt.Name = "CheckAlt";
            this.CheckAlt.Size = new System.Drawing.Size(38, 17);
            this.CheckAlt.TabIndex = 10;
            this.CheckAlt.Text = "Alt";
            this.CheckAlt.UseVisualStyleBackColor = true;
            // 
            // LabelModifiers
            // 
            this.LabelModifiers.AutoSize = true;
            this.LabelModifiers.Location = new System.Drawing.Point(6, 46);
            this.LabelModifiers.Name = "LabelModifiers";
            this.LabelModifiers.Size = new System.Drawing.Size(52, 13);
            this.LabelModifiers.TabIndex = 11;
            this.LabelModifiers.Text = "Modifiers:";
            // 
            // GroupHotkey
            // 
            this.GroupHotkey.Controls.Add(this.TextboxHotkey);
            this.GroupHotkey.Controls.Add(this.LabelModifiers);
            this.GroupHotkey.Controls.Add(this.LabelHotkey);
            this.GroupHotkey.Controls.Add(this.CheckAlt);
            this.GroupHotkey.Controls.Add(this.CheckCtrl);
            this.GroupHotkey.Controls.Add(this.CheckShift);
            this.GroupHotkey.Location = new System.Drawing.Point(12, 184);
            this.GroupHotkey.Name = "GroupHotkey";
            this.GroupHotkey.Size = new System.Drawing.Size(213, 71);
            this.GroupHotkey.TabIndex = 12;
            this.GroupHotkey.TabStop = false;
            this.GroupHotkey.Text = "Hotkey";
            // 
            // CheckShowTaskIcon
            // 
            this.CheckShowTaskIcon.AutoSize = true;
            this.CheckShowTaskIcon.Location = new System.Drawing.Point(9, 65);
            this.CheckShowTaskIcon.Name = "CheckShowTaskIcon";
            this.CheckShowTaskIcon.Size = new System.Drawing.Size(125, 17);
            this.CheckShowTaskIcon.TabIndex = 7;
            this.CheckShowTaskIcon.Text = "Show icon in taskbar";
            this.CheckShowTaskIcon.UseVisualStyleBackColor = true;
            // 
            // TextboxHotkey
            // 
            this.TextboxHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.TextboxHotkey.Location = new System.Drawing.Point(69, 19);
            this.TextboxHotkey.Name = "TextboxHotkey";
            this.TextboxHotkey.Size = new System.Drawing.Size(138, 20);
            this.TextboxHotkey.TabIndex = 7;
            this.TextboxHotkey.Text = "None";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 292);
            this.Controls.Add(this.GroupHotkey);
            this.Controls.Add(this.GroupScreenshots);
            this.Controls.Add(this.GroupPastie);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.GroupPastie.ResumeLayout(false);
            this.GroupPastie.PerformLayout();
            this.GroupScreenshots.ResumeLayout(false);
            this.GroupScreenshots.PerformLayout();
            this.GroupHotkey.ResumeLayout(false);
            this.GroupHotkey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckStartWithWindows;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ComboBox ComboFormat;
        private System.Windows.Forms.Label LabelFormat;
        private System.Windows.Forms.CheckBox CheckUpdate;
        private System.Windows.Forms.GroupBox GroupPastie;
        private System.Windows.Forms.GroupBox GroupScreenshots;
        private System.Windows.Forms.Label LabelHotkey;
        private HotkeyControl TextboxHotkey;
        private System.Windows.Forms.CheckBox CheckShift;
        private System.Windows.Forms.CheckBox CheckCtrl;
        private System.Windows.Forms.CheckBox CheckAlt;
        private System.Windows.Forms.Label LabelModifiers;
        private System.Windows.Forms.GroupBox GroupHotkey;
        private System.Windows.Forms.CheckBox CheckSave;
        private System.Windows.Forms.CheckBox CheckShowTaskIcon;


    }
}