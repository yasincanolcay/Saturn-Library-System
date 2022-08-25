using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class GetReturnDialog : Form
    {
        public MaterialEffect effect = new MaterialEffect();
        public bool onUsers = false;
        public bool booksCard = false;
        public bool addLoss = false;
        public bool admin = false;
        public bool moderator = false;
        public int Id = 0;
        public int totalReturn = 0;

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public GetReturnDialog()
        {
            InitializeComponent();
        }

        private void GetReturnDialog_Load(object sender, EventArgs e)
        {
            loadPage();
            if (addLoss)
            {
                headerLabel.Text = "Kayıp Olarak İşaretleyin";
            }
        }
        private void loadPage()
        {
            ReturnPage page = new ReturnPage();
            page.TopLevel = false;
            page.Dock = DockStyle.Fill;
            page.onUsers = onUsers;
            page.Id = Id;
            page.totalReturn = totalReturn;
            page.booksCard = booksCard;
            page.addLoss = addLoss;
            page.powColor = powColor;
            page.lightColor = lightColor;
            page.foreColor = foreColor;
            page.panel1.BackColor = lightColor;
            page.flowLayoutPanel1.BackColor = lightColor;
            page.BackColor = lightColor;
            pageViewerPanel.BackColor = lightColor;
            page.admin = admin;
            page.moderator = moderator;
            pageViewerPanel.Controls.Add(page);
            page.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }
    }
}
