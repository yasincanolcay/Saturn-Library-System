
namespace Saturn_Library_System
{
    partial class BookDetailCard
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
            Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookDetailCard));
            this.thumbShadowPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.numberLabel = new System.Windows.Forms.Label();
            this.thumbPicturebox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.openPicturebox = new System.Windows.Forms.PictureBox();
            this.writerNameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.detailsShortLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.bookNameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.loadingProgress = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.tagLabel = new System.Windows.Forms.Label();
            this.tagTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Chip1 = new Guna.UI2.WinForms.Guna2Chip();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.thumbShadowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbPicturebox)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openPicturebox)).BeginInit();
            this.tagTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // thumbShadowPanel
            // 
            this.thumbShadowPanel.BackColor = System.Drawing.Color.Transparent;
            this.thumbShadowPanel.Controls.Add(this.numberLabel);
            this.thumbShadowPanel.Controls.Add(this.thumbPicturebox);
            this.guna2Transition1.SetDecoration(this.thumbShadowPanel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.thumbShadowPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(181)))), ((int)(((byte)(71)))));
            this.thumbShadowPanel.Location = new System.Drawing.Point(7, 11);
            this.thumbShadowPanel.Margin = new System.Windows.Forms.Padding(20);
            this.thumbShadowPanel.Name = "thumbShadowPanel";
            this.thumbShadowPanel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.thumbShadowPanel.Radius = 6;
            this.thumbShadowPanel.ShadowColor = System.Drawing.Color.Black;
            this.thumbShadowPanel.ShadowDepth = 90;
            this.thumbShadowPanel.Size = new System.Drawing.Size(167, 229);
            this.thumbShadowPanel.TabIndex = 28;
            // 
            // numberLabel
            // 
            this.numberLabel.BackColor = System.Drawing.Color.Bisque;
            this.numberLabel.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.guna2Transition1.SetDecoration(this.numberLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.numberLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numberLabel.ForeColor = System.Drawing.Color.Black;
            this.numberLabel.Location = new System.Drawing.Point(8, 102);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(151, 45);
            this.numberLabel.TabIndex = 6;
            this.numberLabel.Text = "00";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numberLabel.Visible = false;
            this.numberLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numberLabel_MouseUp);
            // 
            // thumbPicturebox
            // 
            this.thumbPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.thumbPicturebox.BorderRadius = 6;
            this.thumbPicturebox.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.guna2Transition1.SetDecoration(this.thumbPicturebox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.thumbPicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbPicturebox.FillColor = System.Drawing.Color.Bisque;
            this.thumbPicturebox.ImageRotate = 0F;
            this.thumbPicturebox.Location = new System.Drawing.Point(5, 6);
            this.thumbPicturebox.Name = "thumbPicturebox";
            this.thumbPicturebox.Size = new System.Drawing.Size(157, 217);
            this.thumbPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thumbPicturebox.TabIndex = 0;
            this.thumbPicturebox.TabStop = false;
            this.thumbPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.thumbPicturebox_MouseUp);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.openPicturebox);
            this.guna2Panel1.Controls.Add(this.writerNameLabel);
            this.guna2Panel1.Controls.Add(this.detailsShortLabel);
            this.guna2Panel1.Controls.Add(this.bookNameLabel);
            this.guna2Panel1.Controls.Add(this.loadingProgress);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.guna2Panel1.Location = new System.Drawing.Point(190, 17);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 12;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(343, 217);
            this.guna2Panel1.TabIndex = 29;
            // 
            // openPicturebox
            // 
            this.guna2Transition1.SetDecoration(this.openPicturebox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.openPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("openPicturebox.Image")));
            this.openPicturebox.Location = new System.Drawing.Point(308, 185);
            this.openPicturebox.Name = "openPicturebox";
            this.openPicturebox.Size = new System.Drawing.Size(30, 30);
            this.openPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.openPicturebox.TabIndex = 3;
            this.openPicturebox.TabStop = false;
            this.openPicturebox.Click += new System.EventHandler(this.openPicturebox_Click);
            // 
            // writerNameLabel
            // 
            this.writerNameLabel.AutoSize = false;
            this.writerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.writerNameLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.writerNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.writerNameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.writerNameLabel.Location = new System.Drawing.Point(18, 190);
            this.writerNameLabel.Name = "writerNameLabel";
            this.writerNameLabel.Size = new System.Drawing.Size(211, 18);
            this.writerNameLabel.TabIndex = 2;
            this.writerNameLabel.Text = "Yazar İsmi";
            // 
            // detailsShortLabel
            // 
            this.detailsShortLabel.AutoSize = false;
            this.detailsShortLabel.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.detailsShortLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.detailsShortLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.detailsShortLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.detailsShortLabel.Location = new System.Drawing.Point(18, 38);
            this.detailsShortLabel.Name = "detailsShortLabel";
            this.detailsShortLabel.Size = new System.Drawing.Size(315, 143);
            this.detailsShortLabel.TabIndex = 1;
            this.detailsShortLabel.Text = "Kitap detayları...";
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = false;
            this.bookNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.bookNameLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.bookNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bookNameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.bookNameLabel.Location = new System.Drawing.Point(18, 5);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(315, 27);
            this.bookNameLabel.TabIndex = 0;
            this.bookNameLabel.Text = "KİTAP BAŞLIĞI";
            // 
            // loadingProgress
            // 
            this.guna2Transition1.SetDecoration(this.loadingProgress, Guna.UI2.AnimatorNS.DecorationType.None);
            this.loadingProgress.Location = new System.Drawing.Point(308, 185);
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.ProgressColor = System.Drawing.Color.Chocolate;
            this.loadingProgress.Size = new System.Drawing.Size(30, 30);
            this.loadingProgress.TabIndex = 30;
            this.loadingProgress.UseTransparentBackground = true;
            this.loadingProgress.Visible = false;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.tagLabel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tagLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tagLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.tagLabel.Location = new System.Drawing.Point(11, 251);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(50, 19);
            this.tagLabel.TabIndex = 30;
            this.tagLabel.Text = "Etiket:";
            // 
            // tagTablePanel
            // 
            this.tagTablePanel.BackColor = System.Drawing.Color.Transparent;
            this.tagTablePanel.ColumnCount = 4;
            this.tagTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.42719F));
            this.tagTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.57281F));
            this.tagTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tagTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tagTablePanel.Controls.Add(this.guna2Chip1, 0, 0);
            this.guna2Transition1.SetDecoration(this.tagTablePanel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.tagTablePanel.Location = new System.Drawing.Point(67, 245);
            this.tagTablePanel.Name = "tagTablePanel";
            this.tagTablePanel.RowCount = 1;
            this.tagTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tagTablePanel.Size = new System.Drawing.Size(466, 37);
            this.tagTablePanel.TabIndex = 31;
            // 
            // guna2Chip1
            // 
            this.guna2Chip1.AutoRoundedCorners = true;
            this.guna2Chip1.BorderColor = System.Drawing.Color.Chocolate;
            this.guna2Chip1.BorderRadius = 14;
            this.guna2Transition1.SetDecoration(this.guna2Chip1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Chip1.FillColor = System.Drawing.Color.Chocolate;
            this.guna2Chip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.guna2Chip1.ForeColor = System.Drawing.Color.White;
            this.guna2Chip1.IsClosable = false;
            this.guna2Chip1.Location = new System.Drawing.Point(3, 3);
            this.guna2Chip1.Name = "guna2Chip1";
            this.guna2Chip1.Size = new System.Drawing.Size(119, 31);
            this.guna2Chip1.TabIndex = 0;
            this.guna2Chip1.Text = "(boş)";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.DragOrientation = Guna.UI2.WinForms.Enums.DragOrientation.Vertical;
            this.guna2DragControl1.TargetControl = this.thumbPicturebox;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Scale;
            this.guna2Transition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation2;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 2000;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // BookDetailCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(545, 284);
            this.Controls.Add(this.tagTablePanel);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.thumbShadowPanel);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookDetailCard";
            this.Text = "BookDetailCard";
            this.Load += new System.EventHandler(this.BookDetailCard_Load);
            this.thumbShadowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thumbPicturebox)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openPicturebox)).EndInit();
            this.tagTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ShadowPanel thumbShadowPanel;
        public System.Windows.Forms.Label numberLabel;
        public Guna.UI2.WinForms.Guna2PictureBox thumbPicturebox;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label tagLabel;
        public System.Windows.Forms.TableLayoutPanel tagTablePanel;
        public Guna.UI2.WinForms.Guna2Chip guna2Chip1;
        public Guna.UI2.WinForms.Guna2HtmlLabel bookNameLabel;
        public Guna.UI2.WinForms.Guna2HtmlLabel detailsShortLabel;
        public Guna.UI2.WinForms.Guna2HtmlLabel writerNameLabel;
        public System.Windows.Forms.PictureBox openPicturebox;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private System.Windows.Forms.Timer loadingTimer;
        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingProgress;
    }
}