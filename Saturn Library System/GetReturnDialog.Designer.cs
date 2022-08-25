
namespace Saturn_Library_System
{
    partial class GetReturnDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetReturnDialog));
            this.pageViewerPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.SuspendLayout();
            // 
            // pageViewerPanel
            // 
            this.pageViewerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageViewerPanel.Location = new System.Drawing.Point(0, 51);
            this.pageViewerPanel.Name = "pageViewerPanel";
            this.pageViewerPanel.Size = new System.Drawing.Size(757, 431);
            this.pageViewerPanel.TabIndex = 127;
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.headerLabel.Location = new System.Drawing.Point(12, 12);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(160, 25);
            this.headerLabel.TabIndex = 128;
            this.headerLabel.Text = "Emanetleri Alın";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 15;
            this.closeButton.CustomClick = true;
            this.closeButton.CustomIconSize = 20F;
            this.closeButton.FillColor = System.Drawing.Color.Bisque;
            this.closeButton.IconColor = System.Drawing.Color.Chocolate;
            this.closeButton.Location = new System.Drawing.Point(708, 9);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 33);
            this.closeButton.TabIndex = 129;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
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
            // GetReturnDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(757, 482);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.pageViewerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetReturnDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetReturnDialog";
            this.Load += new System.EventHandler(this.GetReturnDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel headerLabel;
        public Guna.UI2.WinForms.Guna2ControlBox closeButton;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        public System.Windows.Forms.Panel pageViewerPanel;
    }
}