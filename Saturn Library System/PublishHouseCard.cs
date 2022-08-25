using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class PublishHouseCard : Form
    {
        public bool admin = false;
        public bool moderator = false;
        public byte[] photoByte = { };
        public int Id = 0;
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public PublishHouseCard()
        {
            InitializeComponent();
        }

        private void PublishHouseCard_Load(object sender, EventArgs e)
        {
            MemoryStream mem = new MemoryStream(photoByte);
            profileBox.Image = Image.FromStream(mem);
            profileBox.BackgroundImage = Image.FromStream(mem);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.deleteHouse = true;
                warning.Id = Id;
                warning.fullNameLabel.Text = "Yayınevi Sil";
                warning.emailLabel.Text = "Bu yayınevi kalıcı olarak silinecek.";
                warning.ShowDialog();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Yayınevini silmek için Admin olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddPublishHouse edit = new AddPublishHouse();
                edit.EditMode = true;
                edit.Id = Id;
                edit.BackColor = lightColor;
                edit.nameTextbox.FillColor = lightColor;
                edit.certificateBox.FillColor = lightColor;
                edit.linksBox.FillColor = lightColor;
                edit.contactBox.FillColor = lightColor;
                edit.addressBox.FillColor = lightColor;
                edit.infoBox.FillColor = lightColor;
                edit.extraBox.FillColor = lightColor;
                edit.Show();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Yayınevini düzenleyebilmek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }
    }
}
