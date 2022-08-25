
namespace Saturn_Library_System
{
    partial class AddReturn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReturn));
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.headerLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pageViewerPanel = new System.Windows.Forms.Panel();
            this.formElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.clockPicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 15;
            this.closeButton.CustomClick = true;
            this.closeButton.CustomIconSize = 20F;
            this.closeButton.FillColor = System.Drawing.Color.Bisque;
            this.closeButton.IconColor = System.Drawing.Color.Chocolate;
            this.closeButton.Location = new System.Drawing.Point(708, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 33);
            this.closeButton.TabIndex = 123;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.headerLabel.Location = new System.Drawing.Point(3, 12);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(187, 25);
            this.headerLabel.TabIndex = 125;
            this.headerLabel.Text = "Kullanıcıları Seçin";
            // 
            // pageViewerPanel
            // 
            this.pageViewerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageViewerPanel.Location = new System.Drawing.Point(0, 51);
            this.pageViewerPanel.Name = "pageViewerPanel";
            this.pageViewerPanel.Size = new System.Drawing.Size(757, 431);
            this.pageViewerPanel.TabIndex = 126;
            // 
            // formElipse
            // 
            this.formElipse.BorderRadius = 15;
            this.formElipse.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BorderRadius = 15;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.CustomFormat = "";
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(377, 8);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.guna2DateTimePicker1.TabIndex = 127;
            this.guna2DateTimePicker1.Value = new System.DateTime(2022, 8, 9, 23, 31, 3, 481);
            this.guna2DateTimePicker1.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // clockPicker
            // 
            this.clockPicker.BorderRadius = 15;
            this.clockPicker.Checked = true;
            this.clockPicker.CustomFormat = "";
            this.clockPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clockPicker.ForeColor = System.Drawing.Color.White;
            this.clockPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.clockPicker.Location = new System.Drawing.Point(581, 8);
            this.clockPicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.clockPicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.clockPicker.Name = "clockPicker";
            this.clockPicker.Size = new System.Drawing.Size(120, 36);
            this.clockPicker.TabIndex = 128;
            this.clockPicker.Value = new System.DateTime(2022, 8, 9, 23, 31, 3, 481);
            this.clockPicker.ValueChanged += new System.EventHandler(this.guna2DateTimePicker2_ValueChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Chocolate;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(230, 13);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(143, 25);
            this.guna2HtmlLabel1.TabIndex = 129;
            this.guna2HtmlLabel1.Text = "Teslim Tarihi:";
            // 
            // AddReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(757, 482);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.clockPicker);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.pageViewerPanel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emanet Ekleyin";
            this.Load += new System.EventHandler(this.AddReturn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel headerLabel;
        private System.Windows.Forms.Panel pageViewerPanel;
        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker clockPicker;
    }
}