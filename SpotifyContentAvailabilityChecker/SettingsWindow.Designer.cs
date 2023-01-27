namespace SpotifyContentAvailabilityChecker
{
    partial class SettingsWindow
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
            this.GBX_SwitchingWindows = new System.Windows.Forms.GroupBox();
            this.CHK_EnableSearchSwitch = new System.Windows.Forms.CheckBox();
            this.GBX_ListColumns = new System.Windows.Forms.GroupBox();
            this.CHK_ShowGridlines = new System.Windows.Forms.CheckBox();
            this.BTN_SaveSettings = new System.Windows.Forms.Button();
            this.GBX_SwitchingWindows.SuspendLayout();
            this.GBX_ListColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBX_SwitchingWindows
            // 
            this.GBX_SwitchingWindows.Controls.Add(this.CHK_EnableSearchSwitch);
            this.GBX_SwitchingWindows.Location = new System.Drawing.Point(7, 2);
            this.GBX_SwitchingWindows.Name = "GBX_SwitchingWindows";
            this.GBX_SwitchingWindows.Size = new System.Drawing.Size(264, 49);
            this.GBX_SwitchingWindows.TabIndex = 0;
            this.GBX_SwitchingWindows.TabStop = false;
            this.GBX_SwitchingWindows.Text = "Switching Windows";
            // 
            // CHK_EnableSearchSwitch
            // 
            this.CHK_EnableSearchSwitch.AutoSize = true;
            this.CHK_EnableSearchSwitch.Location = new System.Drawing.Point(12, 19);
            this.CHK_EnableSearchSwitch.Name = "CHK_EnableSearchSwitch";
            this.CHK_EnableSearchSwitch.Size = new System.Drawing.Size(245, 19);
            this.CHK_EnableSearchSwitch.TabIndex = 1;
            this.CHK_EnableSearchSwitch.Text = "Enable switching when using search info?";
            this.CHK_EnableSearchSwitch.UseVisualStyleBackColor = true;
            // 
            // GBX_ListColumns
            // 
            this.GBX_ListColumns.Controls.Add(this.CHK_ShowGridlines);
            this.GBX_ListColumns.Location = new System.Drawing.Point(7, 55);
            this.GBX_ListColumns.Name = "GBX_ListColumns";
            this.GBX_ListColumns.Size = new System.Drawing.Size(264, 49);
            this.GBX_ListColumns.TabIndex = 2;
            this.GBX_ListColumns.TabStop = false;
            this.GBX_ListColumns.Text = "List Columns";
            // 
            // CHK_ShowGridlines
            // 
            this.CHK_ShowGridlines.AutoSize = true;
            this.CHK_ShowGridlines.Location = new System.Drawing.Point(12, 20);
            this.CHK_ShowGridlines.Name = "CHK_ShowGridlines";
            this.CHK_ShowGridlines.Size = new System.Drawing.Size(117, 19);
            this.CHK_ShowGridlines.TabIndex = 4;
            this.CHK_ShowGridlines.Text = "Enable grid lines?";
            this.CHK_ShowGridlines.UseVisualStyleBackColor = true;
            // 
            // BTN_SaveSettings
            // 
            this.BTN_SaveSettings.Location = new System.Drawing.Point(98, 118);
            this.BTN_SaveSettings.Name = "BTN_SaveSettings";
            this.BTN_SaveSettings.Size = new System.Drawing.Size(87, 23);
            this.BTN_SaveSettings.TabIndex = 7;
            this.BTN_SaveSettings.Text = "Save Settings";
            this.BTN_SaveSettings.UseVisualStyleBackColor = true;
            this.BTN_SaveSettings.Click += new System.EventHandler(this.BTN_SaveSettings_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 151);
            this.Controls.Add(this.BTN_SaveSettings);
            this.Controls.Add(this.GBX_ListColumns);
            this.Controls.Add(this.GBX_SwitchingWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(299, 264);
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.GBX_SwitchingWindows.ResumeLayout(false);
            this.GBX_SwitchingWindows.PerformLayout();
            this.GBX_ListColumns.ResumeLayout(false);
            this.GBX_ListColumns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GBX_SwitchingWindows;
        private CheckBox CHK_EnableSearchSwitch;
        private GroupBox GBX_ListColumns;
        private CheckBox CHK_ShowGridlines;
        private Button BTN_SaveSettings;
    }
}