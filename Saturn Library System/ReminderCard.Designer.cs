
namespace Saturn_Library_System
{
    partial class ReminderCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderCard));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.statuLabel = new System.Windows.Forms.Label();
            this.deletePicturebox = new System.Windows.Forms.PictureBox();
            this.editPicturebox = new System.Windows.Forms.PictureBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.timeChip = new Guna.UI2.WinForms.Guna2Chip();
            this.dateChip = new Guna.UI2.WinForms.Guna2Chip();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletePicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.statuLabel);
            this.guna2Panel1.Controls.Add(this.deletePicturebox);
            this.guna2Panel1.Controls.Add(this.editPicturebox);
            this.guna2Panel1.Controls.Add(this.noteLabel);
            this.guna2Panel1.Controls.Add(this.headerLabel);
            this.guna2Panel1.Controls.Add(this.timeChip);
            this.guna2Panel1.Controls.Add(this.dateChip);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.guna2Panel1.Location = new System.Drawing.Point(8, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.ShadowDecoration.Depth = 25;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(295, 240);
            this.guna2Panel1.TabIndex = 2;
            // 
            // statuLabel
            // 
            this.statuLabel.AutoEllipsis = true;
            this.statuLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statuLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.statuLabel.Location = new System.Drawing.Point(11, 216);
            this.statuLabel.Name = "statuLabel";
            this.statuLabel.Size = new System.Drawing.Size(94, 24);
            this.statuLabel.TabIndex = 24;
            this.statuLabel.Text = "Okundu";
            // 
            // deletePicturebox
            // 
            this.deletePicturebox.Image = ((System.Drawing.Image)(resources.GetObject("deletePicturebox.Image")));
            this.deletePicturebox.Location = new System.Drawing.Point(225, 210);
            this.deletePicturebox.Name = "deletePicturebox";
            this.deletePicturebox.Size = new System.Drawing.Size(30, 30);
            this.deletePicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deletePicturebox.TabIndex = 23;
            this.deletePicturebox.TabStop = false;
            this.deletePicturebox.Click += new System.EventHandler(this.deletePicturebox_Click);
            // 
            // editPicturebox
            // 
            this.editPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("editPicturebox.Image")));
            this.editPicturebox.Location = new System.Drawing.Point(261, 210);
            this.editPicturebox.Name = "editPicturebox";
            this.editPicturebox.Size = new System.Drawing.Size(30, 30);
            this.editPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editPicturebox.TabIndex = 22;
            this.editPicturebox.TabStop = false;
            this.editPicturebox.Click += new System.EventHandler(this.editPicturebox_Click);
            // 
            // noteLabel
            // 
            this.noteLabel.AutoEllipsis = true;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.noteLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.noteLabel.Location = new System.Drawing.Point(13, 123);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(266, 79);
            this.noteLabel.TabIndex = 15;
            this.noteLabel.Text = "Empty Note";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoEllipsis = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.headerLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.headerLabel.Location = new System.Drawing.Point(13, 5);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(266, 48);
            this.headerLabel.TabIndex = 14;
            this.headerLabel.Text = "Untitle";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeChip
            // 
            this.timeChip.AutoRoundedCorners = true;
            this.timeChip.BorderRadius = 24;
            this.timeChip.FillColor = System.Drawing.Color.Chocolate;
            this.timeChip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.timeChip.ForeColor = System.Drawing.Color.White;
            this.timeChip.IsClosable = false;
            this.timeChip.Location = new System.Drawing.Point(159, 61);
            this.timeChip.Name = "timeChip";
            this.timeChip.Size = new System.Drawing.Size(132, 50);
            this.timeChip.TabIndex = 3;
            this.timeChip.Text = "...";
            // 
            // dateChip
            // 
            this.dateChip.AutoRoundedCorners = true;
            this.dateChip.BorderRadius = 24;
            this.dateChip.FillColor = System.Drawing.Color.Chocolate;
            this.dateChip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dateChip.ForeColor = System.Drawing.Color.White;
            this.dateChip.IsClosable = false;
            this.dateChip.Location = new System.Drawing.Point(3, 61);
            this.dateChip.Name = "dateChip";
            this.dateChip.Size = new System.Drawing.Size(132, 50);
            this.dateChip.TabIndex = 2;
            this.dateChip.Text = "...";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(17, 51);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(262, 10);
            this.guna2Separator1.TabIndex = 25;
            // 
            // ReminderCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(312, 264);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReminderCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReminderCard";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deletePicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.Label headerLabel;
        public System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.PictureBox deletePicturebox;
        private System.Windows.Forms.PictureBox editPicturebox;
        public Guna.UI2.WinForms.Guna2Chip timeChip;
        public Guna.UI2.WinForms.Guna2Chip dateChip;
        public System.Windows.Forms.Label statuLabel;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}