
namespace Saturn_Library_System
{
    partial class ForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
            this.usernameTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.nextButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.label3 = new System.Windows.Forms.Label();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BorderThickness = 0;
            this.usernameTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTextbox.DefaultText = "";
            this.usernameTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernameTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernameTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextbox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.usernameTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.usernameTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameTextbox.Location = new System.Drawing.Point(104, 81);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.usernameTextbox.PlaceholderText = "Kullanıcı Adı";
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.Size = new System.Drawing.Size(200, 36);
            this.usernameTextbox.TabIndex = 84;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator3.Location = new System.Drawing.Point(104, 112);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator3.TabIndex = 85;
            // 
            // nextButton
            // 
            this.nextButton.Animated = true;
            this.nextButton.AnimatedGIF = true;
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.BorderRadius = 20;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.nextButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.nextButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.nextButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.nextButton.FillColor = System.Drawing.Color.Chocolate;
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(141, 144);
            this.nextButton.Name = "nextButton";
            this.nextButton.ShadowDecoration.BorderRadius = 22;
            this.nextButton.ShadowDecoration.Depth = 25;
            this.nextButton.ShadowDecoration.Enabled = true;
            this.nextButton.Size = new System.Drawing.Size(126, 39);
            this.nextButton.TabIndex = 99;
            this.nextButton.Text = "İlerle";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(82, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 23);
            this.label3.TabIndex = 101;
            this.label3.Text = "Kullanıcı adınızı giriniz.";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 15;
            this.closeButton.CustomClick = true;
            this.closeButton.CustomIconSize = 20F;
            this.closeButton.FillColor = System.Drawing.Color.Bisque;
            this.closeButton.IconColor = System.Drawing.Color.Chocolate;
            this.closeButton.Location = new System.Drawing.Point(360, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 33);
            this.closeButton.TabIndex = 102;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(409, 203);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.guna2Separator3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi Unuttum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox usernameTextbox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        public Guna.UI2.WinForms.Guna2TileButton nextButton;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}