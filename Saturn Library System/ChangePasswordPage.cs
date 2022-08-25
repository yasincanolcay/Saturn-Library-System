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
    public partial class ChangePasswordPage : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public MaterialEffect effect = new MaterialEffect();
        public int Id = 0;
        private string Password = "";
        private string answer = "";
        public bool forgetMode = false;
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void ChangePasswordPage_Load(object sender, EventArgs e)
        {
            using(SqlCommand command = new SqlCommand("SELECT * From [LoginUsers] where Id='" + Id + "'", sqlConnection))
            {
                Password = "";
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    askLabel.Text = reader["SecurityAsk"].ToString();
                    answer = reader["SecurityAnswer"].ToString();
                    Password = reader["Password"].ToString(); //get the user password from db if the user name is exist in that.  
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            if (forgetMode)
            {
                passwordTextbox.Visible = false;
                guna2Separator1.Visible = false;
            }
        }
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

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!forgetMode)
            {
                changePassword();
            }
            else
            {
                if (askAnswerTextbox.Text != string.Empty)
                {
                    if (Decrypt(answer).Equals(askAnswerTextbox.Text))
                    {
                        effect.Close();
                        MaterialEffect effect2 = new MaterialEffect();
                        effect2.Show();
                        NewPasswordPage newPassword = new NewPasswordPage();
                        newPassword.Id = Id;
                        newPassword.effect = effect2;
                        newPassword.ShowDialog();
                        this.Close();
                        effect.Close();
                    }
                    else
                    {
                        MaterialEffect effect2 = new MaterialEffect();
                        effect2.Show();
                        WarningCard warning = new WarningCard();
                        warning.effect = effect2;
                        warning.errorMode = true;
                        warning.fullNameLabel.Text = "Yanlış Cevap";
                        warning.emailLabel.Text = "Güvenlik sorusunu yanlış cevapladınız.";
                        warning.ShowDialog();
                    }
                }
                else
                {
                    MaterialEffect effect2 = new MaterialEffect();
                    effect2.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect2;
                    warning.errorMode = true;
                    warning.fullNameLabel.Text = "Geçersiz Değer";
                    warning.emailLabel.Text = "Lütfen boş alanlara gerekli bilgileri giriniz";
                    warning.ShowDialog();
                }
            }
        }
        private void changePassword()
        {
            if (askAnswerTextbox.Text != string.Empty && passwordTextbox.Text != string.Empty)
            {
                if (Decrypt(Password).Equals(passwordTextbox.Text) && Decrypt(answer).Equals(askAnswerTextbox.Text))
                {
                    effect.Close();
                    MaterialEffect effect2 = new MaterialEffect();
                    effect2.Show();
                    NewPasswordPage newPassword = new NewPasswordPage();
                    newPassword.Id = Id;
                    newPassword.effect = effect2;
                    newPassword.ShowDialog();
                    this.Close();
                    effect.Close();
                }
                else
                {
                    MaterialEffect effect2 = new MaterialEffect();
                    effect2.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect2;
                    warning.errorMode = true;
                    warning.fullNameLabel.Text = "Yanlış Cevap";
                    warning.emailLabel.Text = "Güvenlik sorusunu yanlış cevapladınız.";
                    warning.ShowDialog();
                }
            }
            else
            {
                MaterialEffect effect2 = new MaterialEffect();
                effect2.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect2;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Geçersiz Değer";
                warning.emailLabel.Text = "Lütfen boş alanlara gerekli bilgileri giriniz";
                warning.ShowDialog();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }
    }
}
