using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Saturn_Library_System
{
    public partial class RegisterCard : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

        private int limit = 0;
        private int second = 0;
        byte[] photoByte = { };
        String filePath = "images/default.jpg";
        private Panel loginPanel = new Panel();
        private bool addNewUser = false;
        private string access = "";

        public Panel LoginPanel { get => loginPanel; set => loginPanel = value; }
        public bool AddNewUser { get => addNewUser; set => addNewUser = value; }

        public RegisterCard()
        {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextbox.Text != string.Empty && surnameTextbox.Text != string.Empty && usernameTextbox.Text != string.Empty && emailTextbox.Text != string.Empty && phoneTextbox.Text != string.Empty && passwordTextbox.Text != string.Empty && accessComboBox.Text != string.Empty)
                {
                    usernameControl();
                }
                if (limit < 3)
                {
                    limit++;
                }
                else
                {
                    limit = 0;
                    registerButton.Visible = false;
                    limitSecondLabel.Visible = true;
                    limitTimer.Enabled = true;
                    limitTimer.Start();
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
        private void usernameControl()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                bool isHave = false;
                using (SqlCommand command = new SqlCommand("SELECT * From [LoginUsers]", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() == usernameTextbox.Text)
                        {
                            isHave = true;
                            MaterialEffect effect = new MaterialEffect();
                            effect.Show();
                            WarningCard warning = new WarningCard();
                            warning.errorMode = true;
                            warning.effect = effect;
                            warning.fullNameLabel.Text = "Geçersiz Kullanıcı Adı";
                            warning.emailLabel.Text = "Kullanıcı adı zaten kullanılıyor, lütfen başka bir kullanıcı adı girin.";
                            warning.ShowDialog();
                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
                if (!isHave)
                {
                    register();
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
        private void register()
        {
            try
            {
                if (!addNewUser)
                {
                    access = "Admin";
                }
                string query = "INSERT INTO [LoginUsers] (Name,Surname,UserName,Access,Email,Phone,Photo,Password,SecurityAsk,SecurityAnswer) VALUES (@name,@surname,@username,@access,@email,@phone,@photo,@password,@ask,@answer)";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", nameTextbox.Text);
                    command.Parameters.AddWithValue("@surname", surnameTextbox.Text);
                    command.Parameters.AddWithValue("@username", usernameTextbox.Text);
                    command.Parameters.AddWithValue("@access", access);
                    command.Parameters.AddWithValue("@email", emailTextbox.Text);
                    command.Parameters.AddWithValue("@phone", phoneTextbox.Text);
                    command.Parameters.AddWithValue("@photo", photoByte);
                    string password = Encrypt(passwordTextbox.Text);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@ask", SecurityComboBox.Text);
                    string answer = Encrypt(answerTextbox.Text);
                    command.Parameters.AddWithValue("@answer", answer);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                registerButton.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
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
        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            registerButton.Visible = true;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            if (!addNewUser)
            {
                loginPanel.Controls.Clear();
                LoginCard login = new LoginCard();
                login.TopLevel = false;
                login.Dock = DockStyle.Fill;
                loginPanel.Controls.Add(login);
                login.Show();
                this.Close();
            }
        }
        private byte[] ImageToStream(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            tryagain:
            try
            {
                Bitmap image = new Bitmap(fileName);
                var type = image.RawFormat;
                image.Save(stream, type);
            }
            catch
            {
                goto tryagain;
            }
            return stream.ToArray();
        }
        private void RegisterCard_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                photoByte = ImageToStream(filePath);
            }
            if (addNewUser)
            {
                accessComboBox.Items.Add("Moderatör");
                accessComboBox.Items.Add("Gözlemci");
            }
        }

        private void profilePicturebox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Resim (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif");
            openFileDialog1.Title = "Resim Dosyası Seçin";
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName != "openFileDialog1" && openFileDialog1.FileName != "")
            {
                filePath = openFileDialog1.FileName;
                profilePicturebox.Image = Image.FromFile(filePath);
                profilePicturebox.BackgroundImage = Image.FromFile(filePath);
                profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                if (File.Exists(filePath))
                {
                    photoByte = ImageToStream(filePath);
                }
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

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                phoneTextbox.Focus();
            }
        }

        private void phoneTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                emailTextbox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                passwordTextbox.Focus();
            }
        }

        private void emailTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                surnameTextbox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                phoneTextbox.Focus();
            }
        }

        private void surnameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                nameTextbox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                emailTextbox.Focus();
            }
        }

        private void nameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                usernameTextbox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                surnameTextbox.Focus();
            }
        }

        private void usernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                nameTextbox.Focus();
            }
        }

        private void accessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            access = accessComboBox.Text;
        }

        private void limitTimer_Tick(object sender, EventArgs e)
        {
            if (second < 20)
            {
                second++;
                limitSecondLabel.Text = second.ToString();
            }
            else
            {
                limitSecondLabel.Visible = false;
                second = 0;
                registerButton.Visible = true;
                limitTimer.Enabled = false;
                limitTimer.Stop();
            }
        }
    }
}