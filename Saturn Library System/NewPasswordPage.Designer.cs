
namespace Saturn_Library_System
{
    partial class NewPasswordPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPasswordPage));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.newPasswordRepeatBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.newsPasswordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.panel1.SuspendLayout();
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
            this.closeButton.TabIndex = 88;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 23);
            this.label3.TabIndex = 91;
            this.label3.Text = "Yeni Şifre Oluşturun";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changeButton);
            this.panel1.Controls.Add(this.newPasswordRepeatBox);
            this.panel1.Controls.Add(this.guna2Separator1);
            this.panel1.Controls.Add(this.newsPasswordBox);
            this.panel1.Controls.Add(this.guna2Separator3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 230);
            this.panel1.TabIndex = 92;
            // 
            // changeButton
            // 
            this.changeButton.Animated = true;
            this.changeButton.AnimatedGIF = true;
            this.changeButton.BackColor = System.Drawing.Color.Transparent;
            this.changeButton.BorderRadius = 20;
            this.changeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.changeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.changeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.changeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.changeButton.FillColor = System.Drawing.Color.Chocolate;
            this.changeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.changeButton.ForeColor = System.Drawing.Color.White;
            this.changeButton.Location = new System.Drawing.Point(148, 141);
            this.changeButton.Name = "changeButton";
            this.changeButton.ShadowDecoration.BorderRadius = 22;
            this.changeButton.ShadowDecoration.Depth = 25;
            this.changeButton.ShadowDecoration.Enabled = true;
            this.changeButton.Size = new System.Drawing.Size(126, 39);
            this.changeButton.TabIndex = 103;
            this.changeButton.Text = "DEĞİŞTİR";
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // newPasswordRepeatBox
            // 
            this.newPasswordRepeatBox.BorderThickness = 0;
            this.newPasswordRepeatBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newPasswordRepeatBox.DefaultText = "";
            this.newPasswordRepeatBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.newPasswordRepeatBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.newPasswordRepeatBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.newPasswordRepeatBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.newPasswordRepeatBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.newPasswordRepeatBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.newPasswordRepeatBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newPasswordRepeatBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.newPasswordRepeatBox.Location = new System.Drawing.Point(111, 93);
            this.newPasswordRepeatBox.Name = "newPasswordRepeatBox";
            this.newPasswordRepeatBox.PasswordChar = '*';
            this.newPasswordRepeatBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.newPasswordRepeatBox.PlaceholderText = "Yeni Şifre Tekrar";
            this.newPasswordRepeatBox.SelectedText = "";
            this.newPasswordRepeatBox.Size = new System.Drawing.Size(200, 36);
            this.newPasswordRepeatBox.TabIndex = 101;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator1.Location = new System.Drawing.Point(111, 124);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator1.TabIndex = 102;
            // 
            // newsPasswordBox
            // 
            this.newsPasswordBox.BorderThickness = 0;
            this.newsPasswordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newsPasswordBox.DefaultText = "";
            this.newsPasswordBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.newsPasswordBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.newsPasswordBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.newsPasswordBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.newsPasswordBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.newsPasswordBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.newsPasswordBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newsPasswordBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.newsPasswordBox.Location = new System.Drawing.Point(111, 51);
            this.newsPasswordBox.Name = "newsPasswordBox";
            this.newsPasswordBox.PasswordChar = '*';
            this.newsPasswordBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.newsPasswordBox.PlaceholderText = "Yeni Şifre";
            this.newsPasswordBox.SelectedText = "";
            this.newsPasswordBox.Size = new System.Drawing.Size(200, 36);
            this.newsPasswordBox.TabIndex = 99;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Separator3.Location = new System.Drawing.Point(111, 82);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator3.TabIndex = 100;
            // 
            // NewPasswordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(423, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewPasswordPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Şifre";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        public Guna.UI2.WinForms.Guna2TileButton changeButton;
        public Guna.UI2.WinForms.Guna2TextBox newPasswordRepeatBox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2TextBox newsPasswordBox;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator3;
    }
}