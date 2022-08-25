
namespace Saturn_Library_System
{
    partial class ChangePasswordPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordPage));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.viewerPanel = new System.Windows.Forms.Panel();
            this.nextButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.askLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.askAnswerTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.label3 = new System.Windows.Forms.Label();
            this.viewerPanel.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 15;
            this.closeButton.CustomClick = true;
            this.closeButton.CustomIconSize = 20F;
            this.closeButton.FillColor = System.Drawing.Color.Bisque;
            this.closeButton.IconColor = System.Drawing.Color.Chocolate;
            this.closeButton.Location = new System.Drawing.Point(374, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 33);
            this.closeButton.TabIndex = 54;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // viewerPanel
            // 
            this.viewerPanel.Controls.Add(this.nextButton);
            this.viewerPanel.Controls.Add(this.guna2Panel1);
            this.viewerPanel.Controls.Add(this.passwordTextbox);
            this.viewerPanel.Controls.Add(this.guna2Separator1);
            this.viewerPanel.Controls.Add(this.askAnswerTextbox);
            this.viewerPanel.Controls.Add(this.guna2Separator3);
            this.viewerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.viewerPanel.Location = new System.Drawing.Point(0, 51);
            this.viewerPanel.Name = "viewerPanel";
            this.viewerPanel.Size = new System.Drawing.Size(423, 230);
            this.viewerPanel.TabIndex = 56;
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
            this.nextButton.Location = new System.Drawing.Point(148, 180);
            this.nextButton.Name = "nextButton";
            this.nextButton.ShadowDecoration.BorderRadius = 22;
            this.nextButton.ShadowDecoration.Depth = 25;
            this.nextButton.ShadowDecoration.Enabled = true;
            this.nextButton.Size = new System.Drawing.Size(126, 39);
            this.nextButton.TabIndex = 98;
            this.nextButton.Text = "İlerle";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.askLabel);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.guna2Panel1.Location = new System.Drawing.Point(35, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.ShadowDecoration.Depth = 25;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(351, 82);
            this.guna2Panel1.TabIndex = 90;
            // 
            // askLabel
            // 
            this.askLabel.AutoEllipsis = true;
            this.askLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.askLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.askLabel.Location = new System.Drawing.Point(4, 2);
            this.askLabel.Name = "askLabel";
            this.askLabel.Size = new System.Drawing.Size(344, 80);
            this.askLabel.TabIndex = 15;
            this.askLabel.Text = "devonesoftinfo@gmail.com";
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
            this.passwordTextbox.Location = new System.Drawing.Point(111, 133);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.passwordTextbox.PlaceholderText = "Şifre";
            this.passwordTextbox.SelectedText = "";
            this.passwordTextbox.Size = new System.Drawing.Size(200, 36);
            this.passwordTextbox.TabIndex = 88;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator1.Location = new System.Drawing.Point(111, 164);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator1.TabIndex = 89;
            // 
            // askAnswerTextbox
            // 
            this.askAnswerTextbox.BorderThickness = 0;
            this.askAnswerTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.askAnswerTextbox.DefaultText = "";
            this.askAnswerTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.askAnswerTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.askAnswerTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.askAnswerTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.askAnswerTextbox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.askAnswerTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.askAnswerTextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.askAnswerTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.askAnswerTextbox.Location = new System.Drawing.Point(111, 91);
            this.askAnswerTextbox.Name = "askAnswerTextbox";
            this.askAnswerTextbox.PasswordChar = '\0';
            this.askAnswerTextbox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.askAnswerTextbox.PlaceholderText = "Cevabınızı Yazınız...";
            this.askAnswerTextbox.SelectedText = "";
            this.askAnswerTextbox.Size = new System.Drawing.Size(200, 36);
            this.askAnswerTextbox.TabIndex = 86;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator3.Location = new System.Drawing.Point(111, 122);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator3.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 23);
            this.label3.TabIndex = 87;
            this.label3.Text = "Güvenlik Sorusu";
            // 
            // ChangePasswordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(423, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.viewerPanel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePasswordPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordPage";
            this.Load += new System.EventHandler(this.ChangePasswordPage_Load);
            this.viewerPanel.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private System.Windows.Forms.Panel viewerPanel;
        public Guna.UI2.WinForms.Guna2TextBox passwordTextbox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2TextBox askAnswerTextbox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label askLabel;
        public Guna.UI2.WinForms.Guna2TileButton nextButton;
    }
}