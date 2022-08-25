
namespace Saturn_Library_System
{
    partial class ReturnPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.headerLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.refreshButton = new Guna.UI2.WinForms.Guna2Button();
            this.thumbSortButton = new Guna.UI2.WinForms.Guna2Button();
            this.listSortButton = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.guna2HScrollBar1 = new Guna.UI2.WinForms.Guna2HScrollBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headerLabel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 38);
            this.panel1.TabIndex = 3;
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.headerLabel.Location = new System.Drawing.Point(7, 7);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(167, 25);
            this.headerLabel.TabIndex = 126;
            this.headerLabel.Text = "Emanet Kitaplar";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.refreshButton);
            this.panel3.Controls.Add(this.thumbSortButton);
            this.panel3.Controls.Add(this.listSortButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(545, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(126, 38);
            this.panel3.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Animated = true;
            this.refreshButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshButton.BorderRadius = 7;
            this.refreshButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.refreshButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.refreshButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.refreshButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.refreshButton.FillColor = System.Drawing.Color.Chocolate;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageSize = new System.Drawing.Size(25, 25);
            this.refreshButton.Location = new System.Drawing.Point(89, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.ShadowDecoration.BorderRadius = 10;
            this.refreshButton.ShadowDecoration.Depth = 22;
            this.refreshButton.Size = new System.Drawing.Size(34, 29);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // thumbSortButton
            // 
            this.thumbSortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbSortButton.Animated = true;
            this.thumbSortButton.BackColor = System.Drawing.Color.Transparent;
            this.thumbSortButton.BorderRadius = 7;
            this.thumbSortButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thumbSortButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thumbSortButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thumbSortButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thumbSortButton.FillColor = System.Drawing.Color.Chocolate;
            this.thumbSortButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.thumbSortButton.ForeColor = System.Drawing.Color.White;
            this.thumbSortButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbSortButton.Image")));
            this.thumbSortButton.ImageSize = new System.Drawing.Size(25, 25);
            this.thumbSortButton.Location = new System.Drawing.Point(9, 5);
            this.thumbSortButton.Name = "thumbSortButton";
            this.thumbSortButton.ShadowDecoration.BorderRadius = 10;
            this.thumbSortButton.ShadowDecoration.Depth = 22;
            this.thumbSortButton.ShadowDecoration.Enabled = true;
            this.thumbSortButton.Size = new System.Drawing.Size(34, 29);
            this.thumbSortButton.TabIndex = 4;
            this.thumbSortButton.Click += new System.EventHandler(this.thumbSortButton_Click);
            // 
            // listSortButton
            // 
            this.listSortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listSortButton.Animated = true;
            this.listSortButton.BackColor = System.Drawing.Color.Transparent;
            this.listSortButton.BorderRadius = 7;
            this.listSortButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.listSortButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.listSortButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.listSortButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.listSortButton.FillColor = System.Drawing.Color.Chocolate;
            this.listSortButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listSortButton.ForeColor = System.Drawing.Color.White;
            this.listSortButton.Image = ((System.Drawing.Image)(resources.GetObject("listSortButton.Image")));
            this.listSortButton.ImageSize = new System.Drawing.Size(25, 25);
            this.listSortButton.Location = new System.Drawing.Point(49, 5);
            this.listSortButton.Name = "listSortButton";
            this.listSortButton.ShadowDecoration.BorderRadius = 10;
            this.listSortButton.ShadowDecoration.Depth = 22;
            this.listSortButton.Size = new System.Drawing.Size(34, 29);
            this.listSortButton.TabIndex = 3;
            this.listSortButton.Click += new System.EventHandler(this.listSortButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(671, 523);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.BindingContainer = this.flowLayoutPanel1;
            this.guna2VScrollBar1.BorderRadius = 8;
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(653, 38);
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 18;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 523);
            this.guna2VScrollBar1.TabIndex = 0;
            this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
            // 
            // guna2HScrollBar1
            // 
            this.guna2HScrollBar1.BindingContainer = this.flowLayoutPanel1;
            this.guna2HScrollBar1.BorderRadius = 8;
            this.guna2HScrollBar1.InUpdate = false;
            this.guna2HScrollBar1.LargeChange = 10;
            this.guna2HScrollBar1.Location = new System.Drawing.Point(0, 543);
            this.guna2HScrollBar1.Name = "guna2HScrollBar1";
            this.guna2HScrollBar1.ScrollbarSize = 18;
            this.guna2HScrollBar1.Size = new System.Drawing.Size(671, 18);
            this.guna2HScrollBar1.TabIndex = 0;
            this.guna2HScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
            this.guna2HScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.guna2HScrollBar1_Scroll);
            // 
            // ReturnPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(671, 561);
            this.Controls.Add(this.guna2HScrollBar1);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReturnPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emanetler";
            this.Load += new System.EventHandler(this.ReturnPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button refreshButton;
        private Guna.UI2.WinForms.Guna2Button thumbSortButton;
        private Guna.UI2.WinForms.Guna2Button listSortButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel headerLabel;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Guna.UI2.WinForms.Guna2HScrollBar guna2HScrollBar1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}