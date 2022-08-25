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
using System.Threading;

namespace Saturn_Library_System
{
    public partial class NewPasswordPage : Form
    {

        public MaterialEffect effect = new MaterialEffect();
        public int Id = 0;
        public NewPasswordPage()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Thread changeThread = new Thread(new ThreadStart(changePassword));
            changeThread.Start();
        }
        private void changePassword()
        {
            if (newsPasswordBox.Text != string.Empty && newPasswordRepeatBox.Text != string.Empty && newsPasswordBox.Text == newPasswordRepeatBox.Text)
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
                string password = Encrypt(newsPasswordBox.Text);
                string query = "UPDATE LoginUsers SET Password=@password where Id=@id";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@password", password);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                MaterialEffect effect2 = new MaterialEffect();
                effect2.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect2;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "ŞİFRE GÜNCELLEMESİ";
                warning.emailLabel.Text = "Şifreniz başarılı bir şekilde güncellendi, iyi çalışmalar dileriz";
                warning.ShowDialog();
                effect.Close();
                sqlConnection.Dispose();
                this.Close();
            }
            else
            {
                MaterialEffect effect2 = new MaterialEffect();
                effect2.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect2;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Geçersiz Değer";
                warning.emailLabel.Text = "Lütfen bilgilerinizin doğruluğunu kontrol ediniz!";
                warning.ShowDialog();
            }
        }
        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

    }
}
