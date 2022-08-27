using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class SettingsPage : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool admin = false;
        public bool moderator = false;
        bool isReady = false;
        public int Id = 0;
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            readSettingsData();
        }
        private void readSettingsData()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * From [Settings]", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Id = Convert.ToInt32(reader["Id"]);
                        if (Convert.ToInt32(reader["AutoStart"]) == 1)
                        {
                            autostartToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["AutoStartNightmode"]) == 1)
                        {
                            autostartNightToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["AutoNightmode"]) == 1)
                        {
                            autoNightToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["AutoBlocked"]) == 1)
                        {
                            autoBlockedToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["NotificationSound"]) == 1)
                        {
                            notificationSoundToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["NotificationShow"]) == 1)
                        {
                            notificationShowToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["AutoCompletedIsbn"]) == 1)
                        {
                            autoCompleteToggle.Checked = true;
                        }
                        if (Convert.ToInt32(reader["SendTelegram"]) == 1)
                        {
                            telegramSendToggle.Checked = true;
                        }
                        tokenTextbox.Text = reader["TelegramToken"].ToString();
                        idTextbox.Text = reader["TelegramId"].ToString();
                    }
                    reader.Close();
                    sqlConnection.Close();
                    isReady = true;
                }
                if (!admin)
                {
                    tokenTextbox.Enabled = false;
                    idTextbox.Enabled = false;
                    telegramSendToggle.Enabled = false;
                    autostartToggle.Enabled = false;
                    autoBlockedToggle.Enabled = false;
                    addUserButton.Enabled = false;
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
        private void updateSettings(string parameter,int value)
        {
            try
            {
                string query = "UPDATE Settings SET " + parameter + "=@parameter where Id=@id";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@parameter", value);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
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
                warning.emailLabel.Text = "Ayarlar kaydedilmedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
        private void updateSettingsTelegram(string parameter, string value)
        {
            try
            {
                string query = "UPDATE Settings SET " + parameter + "=@parameter where Id=@id";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@parameter", value);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
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
                warning.emailLabel.Text = "Ayarlar kaydedilmedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
        private void autostartToggle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                {
                    if (autostartToggle.Checked)
                    {
                        updateSettings("AutoStart", 1);
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                        key.SetValue("Saturn Library System", "\"" + Application.ExecutablePath + "\"");
                    }
                    else
                    {
                        updateSettings("AutoStart", 0);
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                        key.DeleteValue("Saturn Library System");
                    }
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
                warning.emailLabel.Text = "Ayarlar kaydedilmedi , lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void autostartNightToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (autostartNightToggle.Checked)
                {
                    updateSettings("AutoStartNightmode", 1);
                }
                else
                {
                    updateSettings("AutoStartNightmode", 0);
                }
            }
        }

        private void autoNightToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (autoNightToggle.Checked)
                {
                    updateSettings("AutoNightmode", 1);
                }
                else
                {
                    updateSettings("AutoNightmode", 0);
                }
            }
        }

        private void autoBlockedToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (autoBlockedToggle.Checked)
                {
                    updateSettings("AutoBlocked", 1);
                }
                else
                {
                    updateSettings("AutoBlocked", 0);
                }
            }
        }

        private void notificationSoundToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (notificationSoundToggle.Checked)
                {
                    updateSettings("NotificationSound", 1);
                }
                else
                {
                    updateSettings("NotificationSound", 0);
                }
            }
        }

        private void notificationShowToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (notificationShowToggle.Checked)
                {
                    updateSettings("NotificationShow", 1);
                }
                else
                {
                    updateSettings("NotificationShow", 0);
                }
            }
        }
        private void autoCompleteToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (autoCompleteToggle.Checked)
                {
                    updateSettings("AutoCompletedIsbn", 1);
                }
                else
                {
                    updateSettings("AutoCompletedIsbn", 0);
                }
            }
        }

        private void telegramSendToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                if (telegramSendToggle.Checked)
                {
                    updateSettings("SendTelegram", 1);
                }
                else
                {
                    updateSettings("SendTelegram", 0);
                }
            }
        }

        private void tokenTextbox_IconRightClick(object sender, EventArgs e)
        {
            updateSettingsTelegram("TelegramToken", tokenTextbox.Text);
        }

        private void idTextbox_IconRightClick(object sender, EventArgs e)
        {
            updateSettingsTelegram("TelegramId", idTextbox.Text);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                addNewUser();
            }
        }
        private void addNewUser()
        {
            LoginPage page = new LoginPage();
            page.AddNewUser = true;
            page.Show();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            ChangePasswordPage change = new ChangePasswordPage();
            change.Id = Id;
            change.effect = effect;
            change.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devonesoft.42web.io/index.html");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devonesoft.42web.io/index.html");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devonesoft.42web.io/index.html");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCJ8uEcZIP_sSKhZJ2NTjflg");
        }
    }
}
