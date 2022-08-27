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
    public partial class ReminderCard : Form
    {
        public int Id = 0;
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public bool admin = false;
        public bool moderator = false;
        public ReminderCard()
        {
            InitializeComponent();
        }

        private void deletePicturebox_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect;
                    warning.fullNameLabel.Text = "Hatırlatıcıyı Sil";
                    warning.emailLabel.Text = "Bu hatırlatıcı kalıcı olarak silinecek";
                    warning.Id = Id;
                    warning.deleteReminder = true;
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
                    warning.emailLabel.Text = "Hatırlatıcıyı silmek için Admin olmanız gerekmektedir";
                    warning.ShowDialog();
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void editPicturebox_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin || moderator)
                {
                    AddReminder reminder = new AddReminder();
                    reminder.editMode = true;
                    reminder.Id = Id;
                    reminder.BackColor = lightColor;
                    reminder.datePicker.FillColor = powColor;
                    reminder.datePicker.ForeColor = foreColor;
                    reminder.timePicker.FillColor = powColor;
                    reminder.timePicker.ForeColor = foreColor;
                    reminder.headerBox.FillColor = powColor;
                    reminder.noteBox.FillColor = powColor;
                    reminder.createButton.FillColor = powColor;
                    reminder.Show();
                }
                else
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect;
                    warning.errorMode = true;
                    warning.fullNameLabel.Text = "Erişim Reddedildi";
                    warning.emailLabel.Text = "Hatırlatmayı düzenlemek için Admin veya Moderator olmanız gerekmektedir";
                    warning.ShowDialog();
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
    }
}
