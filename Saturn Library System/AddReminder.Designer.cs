
namespace Saturn_Library_System
{
    partial class AddReminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReminder));
            this.minimizeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.datePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.timePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.noteBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.createButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.clearPicturebox = new System.Windows.Forms.PictureBox();
            this.clearPictureboxElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.undoPicturebox = new System.Windows.Forms.PictureBox();
            this.undoPictureboxElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.headerBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.loadingProgress = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clearPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.undoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BorderRadius = 15;
            this.minimizeButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimizeButton.CustomIconSize = 20F;
            this.minimizeButton.FillColor = System.Drawing.Color.Bisque;
            this.minimizeButton.IconColor = System.Drawing.Color.Chocolate;
            this.minimizeButton.Location = new System.Drawing.Point(340, 12);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(37, 33);
            this.minimizeButton.TabIndex = 53;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 15;
            this.closeButton.CustomIconSize = 20F;
            this.closeButton.FillColor = System.Drawing.Color.Bisque;
            this.closeButton.IconColor = System.Drawing.Color.Chocolate;
            this.closeButton.Location = new System.Drawing.Point(383, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 33);
            this.closeButton.TabIndex = 52;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            // 
            // datePicker
            // 
            this.datePicker.BorderRadius = 20;
            this.datePicker.Checked = true;
            this.datePicker.FillColor = System.Drawing.Color.Chocolate;
            this.datePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(12, 56);
            this.datePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowUpDown = true;
            this.datePicker.Size = new System.Drawing.Size(200, 50);
            this.datePicker.TabIndex = 55;
            this.datePicker.Value = new System.DateTime(2022, 8, 15, 21, 22, 32, 2);
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // timePicker
            // 
            this.timePicker.BorderRadius = 20;
            this.timePicker.Checked = true;
            this.timePicker.FillColor = System.Drawing.Color.Chocolate;
            this.timePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(218, 56);
            this.timePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.timePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(200, 50);
            this.timePicker.TabIndex = 56;
            this.timePicker.Value = new System.DateTime(2022, 8, 15, 21, 22, 32, 2);
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // noteBox
            // 
            this.noteBox.BorderRadius = 20;
            this.noteBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.noteBox.DefaultText = "";
            this.noteBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.noteBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.noteBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.noteBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.noteBox.FillColor = System.Drawing.Color.Chocolate;
            this.noteBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.noteBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.noteBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.noteBox.Location = new System.Drawing.Point(12, 157);
            this.noteBox.Multiline = true;
            this.noteBox.Name = "noteBox";
            this.noteBox.PasswordChar = '\0';
            this.noteBox.PlaceholderText = "Bir Not Yazın...";
            this.noteBox.SelectedText = "";
            this.noteBox.Size = new System.Drawing.Size(406, 163);
            this.noteBox.TabIndex = 57;
            this.noteBox.TextChanged += new System.EventHandler(this.noteBox_TextChanged);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.headerLabel.Location = new System.Drawing.Point(13, 18);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(221, 22);
            this.headerLabel.TabIndex = 58;
            this.headerLabel.Text = "HATIRLATICI OLUŞTURUN";
            // 
            // createButton
            // 
            this.createButton.Animated = true;
            this.createButton.AnimatedGIF = true;
            this.createButton.BackColor = System.Drawing.Color.Transparent;
            this.createButton.BorderRadius = 20;
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createButton.FillColor = System.Drawing.Color.Chocolate;
            this.createButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.createButton.ForeColor = System.Drawing.Color.White;
            this.createButton.Location = new System.Drawing.Point(274, 332);
            this.createButton.Name = "createButton";
            this.createButton.ShadowDecoration.BorderRadius = 22;
            this.createButton.ShadowDecoration.Depth = 25;
            this.createButton.ShadowDecoration.Enabled = true;
            this.createButton.Size = new System.Drawing.Size(144, 54);
            this.createButton.TabIndex = 59;
            this.createButton.Text = "OLUŞTUR";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // clearPicturebox
            // 
            this.clearPicturebox.BackColor = System.Drawing.Color.Chocolate;
            this.clearPicturebox.ErrorImage = null;
            this.clearPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("clearPicturebox.Image")));
            this.clearPicturebox.ImageLocation = "";
            this.clearPicturebox.Location = new System.Drawing.Point(-11, 349);
            this.clearPicturebox.Name = "clearPicturebox";
            this.clearPicturebox.Size = new System.Drawing.Size(60, 60);
            this.clearPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.clearPicturebox.TabIndex = 60;
            this.clearPicturebox.TabStop = false;
            this.clearPicturebox.Visible = false;
            this.clearPicturebox.Click += new System.EventHandler(this.clearPicturebox_Click);
            // 
            // clearPictureboxElipse
            // 
            this.clearPictureboxElipse.BorderRadius = 60;
            this.clearPictureboxElipse.TargetControl = this.clearPicturebox;
            // 
            // undoPicturebox
            // 
            this.undoPicturebox.BackColor = System.Drawing.Color.SaddleBrown;
            this.undoPicturebox.ErrorImage = null;
            this.undoPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("undoPicturebox.Image")));
            this.undoPicturebox.ImageLocation = "";
            this.undoPicturebox.Location = new System.Drawing.Point(36, 354);
            this.undoPicturebox.Name = "undoPicturebox";
            this.undoPicturebox.Size = new System.Drawing.Size(60, 60);
            this.undoPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.undoPicturebox.TabIndex = 61;
            this.undoPicturebox.TabStop = false;
            this.undoPicturebox.Visible = false;
            this.undoPicturebox.Click += new System.EventHandler(this.undoPicturebox_Click);
            // 
            // undoPictureboxElipse
            // 
            this.undoPictureboxElipse.BorderRadius = 60;
            this.undoPictureboxElipse.TargetControl = this.undoPicturebox;
            // 
            // headerBox
            // 
            this.headerBox.BorderRadius = 15;
            this.headerBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.headerBox.DefaultText = "";
            this.headerBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.headerBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.headerBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.headerBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.headerBox.FillColor = System.Drawing.Color.Chocolate;
            this.headerBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.headerBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.headerBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.headerBox.Location = new System.Drawing.Point(13, 117);
            this.headerBox.Multiline = true;
            this.headerBox.Name = "headerBox";
            this.headerBox.PasswordChar = '\0';
            this.headerBox.PlaceholderText = "Başlık...";
            this.headerBox.SelectedText = "";
            this.headerBox.Size = new System.Drawing.Size(406, 33);
            this.headerBox.TabIndex = 62;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 2000;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // loadingProgress
            // 
            this.loadingProgress.BackColor = System.Drawing.Color.Transparent;
            this.loadingProgress.Location = new System.Drawing.Point(321, 334);
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.ProgressColor = System.Drawing.Color.Chocolate;
            this.loadingProgress.Size = new System.Drawing.Size(50, 50);
            this.loadingProgress.TabIndex = 63;
            this.loadingProgress.UseTransparentBackground = true;
            this.loadingProgress.Visible = false;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // AddReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(432, 398);
            this.Controls.Add(this.loadingProgress);
            this.Controls.Add(this.headerBox);
            this.Controls.Add(this.clearPicturebox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.noteBox);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.undoPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddReminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatırlatıcı Ekle";
            this.Load += new System.EventHandler(this.AddReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clearPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.undoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ControlBox minimizeButton;
        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        public System.Windows.Forms.Label headerLabel;
        public Guna.UI2.WinForms.Guna2TileButton createButton;
        private System.Windows.Forms.PictureBox clearPicturebox;
        private Guna.UI2.WinForms.Guna2Elipse clearPictureboxElipse;
        private System.Windows.Forms.PictureBox undoPicturebox;
        private Guna.UI2.WinForms.Guna2Elipse undoPictureboxElipse;
        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingProgress;
        private System.Windows.Forms.Timer loadingTimer;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public Guna.UI2.WinForms.Guna2DateTimePicker datePicker;
        public Guna.UI2.WinForms.Guna2DateTimePicker timePicker;
        public Guna.UI2.WinForms.Guna2TextBox noteBox;
        public Guna.UI2.WinForms.Guna2TextBox headerBox;
    }
}