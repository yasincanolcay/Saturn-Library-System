
namespace Saturn_Library_System
{
    partial class LoginCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginCard));
            this.pageViewerPanel = new System.Windows.Forms.Panel();
            this.loadingProgress = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.usernameTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.limitSecondLabel = new System.Windows.Forms.Label();
            this.limitTimer = new System.Windows.Forms.Timer(this.components);
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.forgetPasswordLabel = new System.Windows.Forms.LinkLabel();
            this.pageViewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pageViewerPanel
            // 
            this.pageViewerPanel.Controls.Add(this.forgetPasswordLabel);
            this.pageViewerPanel.Controls.Add(this.loadingProgress);
            this.pageViewerPanel.Controls.Add(this.pictureBox2);
            this.pageViewerPanel.Controls.Add(this.label1);
            this.pageViewerPanel.Controls.Add(this.label2);
            this.pageViewerPanel.Controls.Add(this.loginButton);
            this.pageViewerPanel.Controls.Add(this.label3);
            this.pageViewerPanel.Controls.Add(this.passwordTextbox);
            this.pageViewerPanel.Controls.Add(this.guna2Separator1);
            this.pageViewerPanel.Controls.Add(this.usernameTextbox);
            this.pageViewerPanel.Controls.Add(this.guna2Separator3);
            this.pageViewerPanel.Controls.Add(this.limitSecondLabel);
            this.pageViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewerPanel.Location = new System.Drawing.Point(0, 0);
            this.pageViewerPanel.Name = "pageViewerPanel";
            this.pageViewerPanel.Size = new System.Drawing.Size(383, 408);
            this.pageViewerPanel.TabIndex = 7;
            // 
            // loadingProgress
            // 
            this.loadingProgress.Location = new System.Drawing.Point(172, 317);
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.ProgressColor = System.Drawing.Color.Chocolate;
            this.loadingProgress.Size = new System.Drawing.Size(45, 45);
            this.loadingProgress.TabIndex = 101;
            this.loadingProgress.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(145, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 100;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(116, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 23);
            this.label1.TabIndex = 98;
            this.label1.Text = "Saturn Library";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(221, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 99;
            this.label2.Text = "system";
            // 
            // loginButton
            // 
            this.loginButton.Animated = true;
            this.loginButton.AnimatedGIF = true;
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.BorderRadius = 20;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginButton.FillColor = System.Drawing.Color.Chocolate;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(132, 318);
            this.loginButton.Name = "loginButton";
            this.loginButton.ShadowDecoration.BorderRadius = 22;
            this.loginButton.ShadowDecoration.Depth = 25;
            this.loginButton.ShadowDecoration.Enabled = true;
            this.loginButton.Size = new System.Drawing.Size(126, 39);
            this.loginButton.TabIndex = 97;
            this.loginButton.Text = "Giriş";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(141, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 86;
            this.label3.Text = "Giriş Yap";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BorderThickness = 0;
            this.passwordTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextbox.DefaultText = "";
            this.passwordTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTextbox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.passwordTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTextbox.Location = new System.Drawing.Point(95, 245);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.passwordTextbox.PlaceholderText = "Şifre";
            this.passwordTextbox.SelectedText = "";
            this.passwordTextbox.Size = new System.Drawing.Size(200, 36);
            this.passwordTextbox.TabIndex = 84;
            this.passwordTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextbox_KeyDown);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator1.Location = new System.Drawing.Point(95, 276);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator1.TabIndex = 85;
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
            this.usernameTextbox.Location = new System.Drawing.Point(95, 203);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.usernameTextbox.PlaceholderText = "Kullanıcı Adı";
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.Size = new System.Drawing.Size(200, 36);
            this.usernameTextbox.TabIndex = 82;
            this.usernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTextbox_KeyDown);
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator3.Location = new System.Drawing.Point(95, 234);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator3.TabIndex = 83;
            // 
            // limitSecondLabel
            // 
            this.limitSecondLabel.AutoSize = true;
            this.limitSecondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.limitSecondLabel.ForeColor = System.Drawing.Color.DimGray;
            this.limitSecondLabel.Location = new System.Drawing.Point(174, 331);
            this.limitSecondLabel.Name = "limitSecondLabel";
            this.limitSecondLabel.Size = new System.Drawing.Size(43, 15);
            this.limitSecondLabel.TabIndex = 8;
            this.limitSecondLabel.Text = "00:12";
            this.limitSecondLabel.Visible = false;
            // 
            // limitTimer
            // 
            this.limitTimer.Interval = 1000;
            this.limitTimer.Tick += new System.EventHandler(this.limitTimer_Tick);
            // 
            // loadingTimer
            // 
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // forgetPasswordLabel
            // 
            this.forgetPasswordLabel.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.forgetPasswordLabel.AutoSize = true;
            this.forgetPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetPasswordLabel.LinkColor = System.Drawing.Color.Chocolate;
            this.forgetPasswordLabel.Location = new System.Drawing.Point(135, 383);
            this.forgetPasswordLabel.Name = "forgetPasswordLabel";
            this.forgetPasswordLabel.Size = new System.Drawing.Size(112, 19);
            this.forgetPasswordLabel.TabIndex = 103;
            this.forgetPasswordLabel.TabStop = true;
            this.forgetPasswordLabel.Text = "Şifremi Unuttum";
            this.forgetPasswordLabel.VisitedLinkColor = System.Drawing.Color.Tomato;
            this.forgetPasswordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgetPasswordLabel_LinkClicked);
            // 
            // LoginCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(383, 408);
            this.Controls.Add(this.pageViewerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.pageViewerPanel.ResumeLayout(false);
            this.pageViewerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pageViewerPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TileButton loginButton;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox passwordTextbox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2TextBox usernameTextbox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private System.Windows.Forms.Timer limitTimer;
        private System.Windows.Forms.Timer loadingTimer;
        private System.Windows.Forms.Label limitSecondLabel;
        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingProgress;
        private System.Windows.Forms.LinkLabel forgetPasswordLabel;
    }
}