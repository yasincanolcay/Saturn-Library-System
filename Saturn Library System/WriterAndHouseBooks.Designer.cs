
namespace Saturn_Library_System
{
    partial class WriterAndHouseBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriterAndHouseBooks));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.refreshButton = new Guna.UI2.WinForms.Guna2Button();
            this.searchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.thumbSortButton = new Guna.UI2.WinForms.Guna2Button();
            this.listSortButton = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tagFilterLabel = new System.Windows.Forms.Label();
            this.filterCombobox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(671, 30);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 38);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.refreshButton);
            this.panel3.Controls.Add(this.searchBox);
            this.panel3.Controls.Add(this.thumbSortButton);
            this.panel3.Controls.Add(this.listSortButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(302, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 38);
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
            this.refreshButton.Location = new System.Drawing.Point(332, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.ShadowDecoration.BorderRadius = 10;
            this.refreshButton.ShadowDecoration.Depth = 22;
            this.refreshButton.Size = new System.Drawing.Size(34, 29);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Animated = true;
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.BorderRadius = 10;
            this.searchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBox.DefaultText = "";
            this.searchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchBox.FillColor = System.Drawing.Color.Chocolate;
            this.searchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchBox.Location = new System.Drawing.Point(15, 4);
            this.searchBox.Name = "searchBox";
            this.searchBox.PasswordChar = '\0';
            this.searchBox.PlaceholderText = "Yazarın Kitaplarını Arayın...";
            this.searchBox.SelectedText = "";
            this.searchBox.Size = new System.Drawing.Size(231, 30);
            this.searchBox.TabIndex = 5;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
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
            this.thumbSortButton.Location = new System.Drawing.Point(252, 5);
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
            this.listSortButton.Location = new System.Drawing.Point(292, 5);
            this.listSortButton.Name = "listSortButton";
            this.listSortButton.ShadowDecoration.BorderRadius = 10;
            this.listSortButton.ShadowDecoration.Depth = 22;
            this.listSortButton.Size = new System.Drawing.Size(34, 29);
            this.listSortButton.TabIndex = 3;
            this.listSortButton.Click += new System.EventHandler(this.listSortButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tagFilterLabel);
            this.panel2.Controls.Add(this.filterCombobox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 38);
            this.panel2.TabIndex = 0;
            // 
            // tagFilterLabel
            // 
            this.tagFilterLabel.AutoSize = true;
            this.tagFilterLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tagFilterLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.tagFilterLabel.Location = new System.Drawing.Point(14, 9);
            this.tagFilterLabel.Name = "tagFilterLabel";
            this.tagFilterLabel.Size = new System.Drawing.Size(117, 22);
            this.tagFilterLabel.TabIndex = 6;
            this.tagFilterLabel.Text = "Etiket Filtresi";
            // 
            // filterCombobox
            // 
            this.filterCombobox.BackColor = System.Drawing.Color.Transparent;
            this.filterCombobox.BorderColor = System.Drawing.Color.Chocolate;
            this.filterCombobox.BorderRadius = 12;
            this.filterCombobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterCombobox.DropDownHeight = 110;
            this.filterCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCombobox.FillColor = System.Drawing.Color.Chocolate;
            this.filterCombobox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.filterCombobox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.filterCombobox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.filterCombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.filterCombobox.IntegralHeight = false;
            this.filterCombobox.ItemHeight = 30;
            this.filterCombobox.Location = new System.Drawing.Point(133, 1);
            this.filterCombobox.Name = "filterCombobox";
            this.filterCombobox.Size = new System.Drawing.Size(140, 36);
            this.filterCombobox.TabIndex = 5;
            this.filterCombobox.SelectedIndexChanged += new System.EventHandler(this.filterCombobox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(671, 531);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // WriterAndHouseBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(198)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(671, 599);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WriterAndHouseBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitaplar";
            this.Load += new System.EventHandler(this.WriterAndHouseBooks_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2TextBox searchBox;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel3;
        public Guna.UI2.WinForms.Guna2Button refreshButton;
        public Guna.UI2.WinForms.Guna2Button thumbSortButton;
        public Guna.UI2.WinForms.Guna2Button listSortButton;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label tagFilterLabel;
        public Guna.UI2.WinForms.Guna2ComboBox filterCombobox;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}