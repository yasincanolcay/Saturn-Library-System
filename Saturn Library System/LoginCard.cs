using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class LoginCard : Form
    {
        int loginLimit = 0;
        public LoginPage page = new LoginPage();
        public LoginCard()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernameTextbox.Text != string.Empty && passwordTextbox.Text != string.Empty)
                {
                    if (loginLimit < 4)
                    {
                        login();
                    }
                    else
                    {
                        limitTimer.Enabled = true;
                        limitTimer.Start();
                        loginButton.Visible = false;
                        limitSecondLabel.Visible = true;
                    }
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.errorMode = true;
                warning.effect = effect;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
        private void login()
        {
            try
            {
                loginButton.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                string Password = "";
                int Id = 0;
                bool IsExist = false;

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                using (SqlCommand command = new SqlCommand("SELECT * From [LoginUsers] where UserName='" + usernameTextbox.Text + "'", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Password = reader["Password"].ToString(); //get the user password from db if the user name is exist in that.  
                        Id = Convert.ToInt32(reader["Id"]);
                        IsExist = true;
                    }
                    sqlConnection.Close();
                    if (IsExist)
                    {
                        if (Decrypt(Password).Equals(passwordTextbox.Text))
                        {
                            Form1 form = new Form1();
                            form.Id = Id;
                            form.page = page;
                            form.Show();
                            usernameTextbox.Clear();
                            passwordTextbox.Clear();
                            page.Hide();
                        }
                        else
                        {
                            MaterialEffect effect = new MaterialEffect();
                            effect.Show();
                            WarningCard warning = new WarningCard();
                            warning.errorMode = true;
                            warning.effect = effect;
                            warning.fullNameLabel.Text = "Hatalı Şifre";
                            warning.emailLabel.Text = "Girdiginiz şifre hatalı, lütfen tekrar deneyin!";
                            loginLimit++;
                            warning.ShowDialog();
                        }
                    }
                    else
                    {
                        MaterialEffect effect = new MaterialEffect();
                        effect.Show();
                        WarningCard warning = new WarningCard();
                        warning.errorMode = true;
                        warning.effect = effect;
                        warning.fullNameLabel.Text = "Kullanıcı Bulunamadı";
                        warning.emailLabel.Text = "Girdiginiz bilgilerle eşleşen kullanıcı yok, lütfen bilgileri kontrol edin!";
                        loginLimit++;
                        warning.ShowDialog();
                    }
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.errorMode = true;
                warning.effect = effect;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
        //veritabaından hash formatında gelen şifreyi çözümler
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement, but the decryption key should be same as encryption key    
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        int second = 0;
        private void limitTimer_Tick(object sender, EventArgs e)
        {
            if (second < 21)
            {
                second++;
                limitSecondLabel.Text = second.ToString();
            }
            else
            {
                loginLimit = 0;
                second = 0;
                limitSecondLabel.Visible = false;
                loginButton.Visible = true;
                limitTimer.Enabled = false;
                limitTimer.Stop();
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            loginButton.Visible = true;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
        }

        private void usernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                passwordTextbox.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (passwordTextbox.Text != string.Empty)
                {
                    loginButton.PerformClick();
                }
                else
                {
                    passwordTextbox.Focus();
                }
            }
        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                usernameTextbox.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }

        private void forgetPasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            ForgetPassword forget = new ForgetPassword();
            forget.effect = effect;
            forget.ShowDialog();
        }
    }
}
