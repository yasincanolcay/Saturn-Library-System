
namespace Saturn_Library_System
{
    partial class UserInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoDialog));
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.infoNameLabel = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.editPicturebox = new System.Windows.Forms.PictureBox();
            this.infoDetailBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.editPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.CustomClick = true;
            this.guna2ControlBox1.CustomIconSize = 20F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Bisque;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Chocolate;
            this.guna2ControlBox1.Location = new System.Drawing.Point(313, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 33);
            this.guna2ControlBox1.TabIndex = 13;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
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
            // infoNameLabel
            // 
            this.infoNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infoNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(181)))), ((int)(((byte)(71)))));
            this.infoNameLabel.Location = new System.Drawing.Point(12, 56);
            this.infoNameLabel.Name = "infoNameLabel";
            this.infoNameLabel.Size = new System.Drawing.Size(206, 22);
            this.infoNameLabel.TabIndex = 14;
            this.infoNameLabel.Text = "Email Adresi";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoEllipsis = true;
            this.fullNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fullNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(181)))), ((int)(((byte)(71)))));
            this.fullNameLabel.Location = new System.Drawing.Point(13, 23);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(274, 22);
            this.fullNameLabel.TabIndex = 16;
            this.fullNameLabel.Text = "Yasincan Olcay";
            // 
            // editPicturebox
            // 
            this.editPicturebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("editPicturebox.Image")));
            this.editPicturebox.Location = new System.Drawing.Point(166, 147);
            this.editPicturebox.Name = "editPicturebox";
            this.editPicturebox.Size = new System.Drawing.Size(30, 30);
            this.editPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editPicturebox.TabIndex = 17;
            this.editPicturebox.TabStop = false;
            this.editPicturebox.Click += new System.EventHandler(this.editPicturebox_Click);
            // 
            // infoDetailBox
            // 
            this.infoDetailBox.BorderThickness = 0;
            this.infoDetailBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.infoDetailBox.DefaultText = "olcayyasincan@gmail.com";
            this.infoDetailBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.infoDetailBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.infoDetailBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.infoDetailBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.infoDetailBox.FillColor = System.Drawing.Color.Chocolate;
            this.infoDetailBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.infoDetailBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infoDetailBox.ForeColor = System.Drawing.Color.SaddleBrown;
            this.infoDetailBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.infoDetailBox.Location = new System.Drawing.Point(3, 78);
            this.infoDetailBox.Margin = new System.Windows.Forms.Padding(0);
            this.infoDetailBox.Multiline = true;
            this.infoDetailBox.Name = "infoDetailBox";
            this.infoDetailBox.PasswordChar = '\0';
            this.infoDetailBox.PlaceholderText = "";
            this.infoDetailBox.ReadOnly = true;
            this.infoDetailBox.SelectedText = "";
            this.infoDetailBox.Size = new System.Drawing.Size(336, 68);
            this.infoDetailBox.TabIndex = 18;
            // 
            // UserInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(362, 179);
            this.Controls.Add(this.infoDetailBox);
            this.Controls.Add(this.editPicturebox);
            this.Controls.Add(this.fullNameLabel);
            this.Controls.Add(this.infoNameLabel);
            this.Controls.Add(this.guna2ControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Bilgileri";
            this.Load += new System.EventHandler(this.UserInfoDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.PictureBox editPicturebox;
        public System.Windows.Forms.Label infoNameLabel;
        public System.Windows.Forms.Label fullNameLabel;
        public Guna.UI2.WinForms.Guna2TextBox infoDetailBox;
    }
}