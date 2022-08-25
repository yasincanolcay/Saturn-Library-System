
namespace Saturn_Library_System
{
    partial class BooksCard
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
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BooksCard));
            this.guna2ShadowPanel6 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.numberLabel = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.openPicturebox = new System.Windows.Forms.PictureBox();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.loadingProgress = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.guna2ShadowPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel6
            // 
            this.guna2ShadowPanel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel6.Controls.Add(this.numberLabel);
            this.guna2ShadowPanel6.Controls.Add(this.guna2PictureBox1);
            this.guna2Transition1.SetDecoration(this.guna2ShadowPanel6, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ShadowPanel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(181)))), ((int)(((byte)(71)))));
            this.guna2ShadowPanel6.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel6.Margin = new System.Windows.Forms.Padding(20);
            this.guna2ShadowPanel6.Name = "guna2ShadowPanel6";
            this.guna2ShadowPanel6.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2ShadowPanel6.Radius = 6;
            this.guna2ShadowPanel6.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel6.ShadowDepth = 90;
            this.guna2ShadowPanel6.Size = new System.Drawing.Size(167, 229);
            this.guna2ShadowPanel6.TabIndex = 27;
            // 
            // numberLabel
            // 
            this.numberLabel.BackColor = System.Drawing.Color.Bisque;
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
            this.numberLabel.MouseLeave += new System.EventHandler(this.numberLabel_MouseLeave);
            this.numberLabel.MouseHover += new System.EventHandler(this.numberLabel_MouseHover);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 6;
            this.guna2PictureBox1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.guna2Transition1.SetDecoration(this.guna2PictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Bisque;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(5, 6);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(157, 217);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.MouseLeave += new System.EventHandler(this.guna2PictureBox1_MouseLeave);
            this.guna2PictureBox1.MouseHover += new System.EventHandler(this.guna2PictureBox1_MouseHover);
            this.guna2PictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guna2PictureBox1_MouseUp);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.DragOrientation = Guna.UI2.WinForms.Enums.DragOrientation.Vertical;
            this.guna2DragControl1.TargetControl = this.guna2PictureBox1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // openPicturebox
            // 
            this.guna2Transition1.SetDecoration(this.openPicturebox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.openPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("openPicturebox.Image")));
            this.openPicturebox.Location = new System.Drawing.Point(72, 234);
            this.openPicturebox.Name = "openPicturebox";
            this.openPicturebox.Size = new System.Drawing.Size(30, 30);
            this.openPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.openPicturebox.TabIndex = 28;
            this.openPicturebox.TabStop = false;
            this.openPicturebox.Visible = false;
            this.openPicturebox.Click += new System.EventHandler(this.openPicturebox_Click);
            this.openPicturebox.MouseLeave += new System.EventHandler(this.openPicturebox_MouseLeave);
            this.openPicturebox.MouseHover += new System.EventHandler(this.openPicturebox_MouseHover);
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Scale;
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // loadingProgress
            // 
            this.loadingProgress.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.loadingProgress, Guna.UI2.AnimatorNS.DecorationType.None);
            this.loadingProgress.Location = new System.Drawing.Point(72, 233);
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.ProgressColor = System.Drawing.Color.Chocolate;
            this.loadingProgress.Size = new System.Drawing.Size(30, 30);
            this.loadingProgress.TabIndex = 29;
            this.loadingProgress.UseTransparentBackground = true;
            this.loadingProgress.Visible = false;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 2000;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // BooksCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(171, 270);
            this.Controls.Add(this.openPicturebox);
            this.Controls.Add(this.guna2ShadowPanel6);
            this.Controls.Add(this.loadingProgress);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BooksCard";
            this.Text = "BooksCard";
            this.Load += new System.EventHandler(this.BooksCard_Load);
            this.MouseLeave += new System.EventHandler(this.BooksCard_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BooksCard_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BooksCard_MouseMove);
            this.guna2ShadowPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label numberLabel;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.PictureBox openPicturebox;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private System.Windows.Forms.Timer loadingTimer;
        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingProgress;
        public Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel6;
    }
}