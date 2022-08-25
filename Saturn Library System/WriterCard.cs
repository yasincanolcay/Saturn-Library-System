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
    public partial class WriterCard : Form
    {
        public byte[] photoByte = { };
        public int Id = 0;
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public bool admin = false;
        public bool moderator = false;
        public WriterCard()
        {
            InitializeComponent();
        }

        private void WriterCard_Load(object sender, EventArgs e)
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
                warning.deleteWriter = true;
                warning.Id = Id;
                warning.fullNameLabel.Text = "Yazarı Sil";
                warning.emailLabel.Text = "Bu yazar kalıcı olarak silinecek.";
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
                warning.emailLabel.Text = "Yazarı silmek için Admin olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddWriter edit = new AddWriter();
                edit.EditMode = true;
                edit.Id = Id;
                edit.BackColor = lightColor;
                edit.nameTextbox.FillColor = lightColor;
                edit.surnameBox.FillColor = lightColor;
                edit.linksBox.FillColor = lightColor;
                edit.phoneNumberbox.FillColor = lightColor;
                edit.genusBox.FillColor = lightColor;
                edit.cityBox.FillColor = lightColor;
                edit.infoBox.FillColor = lightColor;
                edit.languageBox.FillColor = lightColor;
                edit.emailBox.FillColor = lightColor;
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
                warning.emailLabel.Text = "Yazar bilgilerini düzenleyebilmek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }
    }
}
