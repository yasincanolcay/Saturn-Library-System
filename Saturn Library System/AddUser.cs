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

namespace Saturn_Library_System
{
    public partial class AddUser : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");


        string picturePath = "images/male_user_80px.png";
        private byte[] pictureByte = { };
        bool editMode = false;
        public int Id = 0;
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public byte[] PictureByte { get => pictureByte; set => pictureByte = value; }
        public bool EditMode { get => editMode; set => editMode = value; }

        int blocked = 0;
        int totalbook = 0;
        int totalPage = 0;
        int totalReturn = 0;
        float score = 0;
        int medal = 0;
        int totalBlocked = 0;
        int trust = 0;
        int blockedRank = 0;
        public AddUser()
        {
            InitializeComponent();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            nameTextbox.Clear();
            surnameBox.Clear();
            countryIdBox.Clear();
            phoneNumberbox.Clear();
            schoolBox.Clear();
            housePhoneBox.Clear();
            addressBox.Clear();
            languageBox.Clear();
            emailBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextbox.Text != string.Empty && surnameBox.Text != string.Empty && countryIdBox.Text != string.Empty && addressBox.Text != string.Empty && phoneNumberbox.Text != string.Empty && schoolBox.Text != string.Empty && languageBox.Text != string.Empty && housePhoneBox.Text != string.Empty && emailBox.Text != string.Empty)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                    string query = "";
                    if (!editMode)
                    {
                        query = "INSERT INTO [Users] (Name,Surname,CountryIdNo,Address,Phone,School,Language,HousePhone,Email,Blocked,ProfilePicture,Medal,Score,Trust,totalBook,totalReturn,TotalPage,TotalBlocked,BlockedRank) VALUES (@Name,@Surname,@CountryIdNo,@Address,@Phone,@School,@Language,@HousePhone,@Email,@blocked,@Profile,@Medal,@Score,@Trust,@totalBook,@totalReturn,@TotalPage,@TotalBlocked,@blockedRank)";
                    }
                    else
                    {
                        query = "UPDATE Users SET Name=@Name,Surname=@Surname,CountryIdNo=@CountryIdNo,Address=@Address,Phone=@Phone,School=@School,Language=@Language,HousePhone=@HousePhone,Email=@Email,Blocked=@Blocked,ProfilePicture=@Profile,Medal=@Medal,Score=@Score,Trust=@Trust,totalBook=@totalBook,totalReturn=@totalReturn,TotalPage=@TotalPage,TotalBlocked=@TotalBlocked,BlockedRank=@blockedRank where Id=@id";
                    }
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Clear();
                        if (editMode)
                            command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@Name", nameTextbox.Text);
                        command.Parameters.AddWithValue("@Surname", surnameBox.Text);
                        command.Parameters.AddWithValue("@CountryIdNo", countryIdBox.Text);
                        command.Parameters.AddWithValue("@Address", addressBox.Text);
                        command.Parameters.AddWithValue("@Phone", phoneNumberbox.Text);
                        command.Parameters.AddWithValue("@School", schoolBox.Text);
                        command.Parameters.AddWithValue("@Language", languageBox.Text);
                        command.Parameters.AddWithValue("@HousePhone", housePhoneBox.Text);
                        command.Parameters.AddWithValue("@Email", emailBox.Text);
                        command.Parameters.AddWithValue("@blocked", blocked);
                        command.Parameters.AddWithValue("@Profile", PictureByte);
                        command.Parameters.AddWithValue("@Medal", medal);
                        command.Parameters.AddWithValue("@Score", score);
                        command.Parameters.AddWithValue("@Trust", trust);
                        command.Parameters.AddWithValue("@totalBook", totalbook);
                        command.Parameters.AddWithValue("@totalReturn", totalReturn);
                        command.Parameters.AddWithValue("@TotalPage", totalPage);
                        command.Parameters.AddWithValue("@TotalBlocked", totalBlocked);
                        command.Parameters.AddWithValue("@blockedRank", blockedRank);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    saveButton.Visible = false;
                    loadingProgress.Visible = true;
                    loadingProgress.Start();
                    loadingTimer.Enabled = true;
                    loadingTimer.Start();
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
                warning.emailLabel.Text = "Kayıt yapılırken bir hata oluştu, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void profilePicturebox_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Resim (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif");
            openFileDialog1.Title = "Resim Dosyası Seçin";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1" && openFileDialog1.FileName != "")
            {
                PicturePath = openFileDialog1.FileName;
                profilePicturebox.Image = Image.FromFile(PicturePath);
                profilePicturebox.BackgroundImage = Image.FromFile(PicturePath);
                profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                if (File.Exists(PicturePath))
                {
                    PictureByte = ImageToStream(PicturePath);
                }
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

        private void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(PicturePath) && !editMode)
                {
                    PictureByte = ImageToStream(PicturePath);
                }
                if (editMode)
                {
                    MemoryStream stream = new MemoryStream(pictureByte);
                    profilePicturebox.Image = Image.FromStream(stream);
                    profilePicturebox.BackgroundImage = Image.FromStream(stream);
                    profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                    using (SqlCommand command = new SqlCommand())
                    {
                        sqlConnection.Open();
                        command.Connection = sqlConnection;
                        command.CommandText = ("Select * From [Users]");
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (Id == Convert.ToInt32(reader["Id"]))
                            {
                                nameTextbox.Text = reader["Name"].ToString();
                                surnameBox.Text = reader["Surname"].ToString();
                                countryIdBox.Text = reader["CountryIdNo"].ToString();
                                phoneNumberbox.Text = reader["Phone"].ToString();
                                schoolBox.Text = reader["School"].ToString();
                                housePhoneBox.Text = reader["HousePhone"].ToString();
                                addressBox.Text = reader["Address"].ToString();
                                languageBox.Text = reader["Language"].ToString();
                                emailBox.Text = reader["Email"].ToString();
                                blocked = Convert.ToInt32(reader["Blocked"]);
                                totalbook = Convert.ToInt32(reader["totalBook"]);
                                totalPage = Convert.ToInt32(reader["TotalPage"]);
                                score = float.Parse(reader["Score"].ToString());
                                medal = Convert.ToInt32(reader["Medal"]);
                                trust = Convert.ToInt32(reader["Trust"]);
                                totalReturn = Convert.ToInt32(reader["totalReturn"]);
                                blockedRank = Convert.ToInt32(reader["BlockedRank"]);
                                totalBlocked = 0;
                                reader.Close();
                                break;
                            }
                        }
                        sqlConnection.Close();
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

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            saveButton.Visible = true;
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            loadingProgress.Dispose();
            loadingTimer.Stop();
            loadingTimer.Enabled = false;
            loadingTimer.Dispose();
        }

        private void nameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                surnameBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                addressBox.Focus();
            }
        }

        private void surnameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                nameTextbox.Focus();
            }
            if(e.KeyCode == Keys.Down)
            {
                countryIdBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                addressBox.Focus();
            }
        }

        private void countryIdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                surnameBox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                phoneNumberbox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                addressBox.Focus();
            }
        }

        private void phoneNumberbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                countryIdBox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                schoolBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                addressBox.Focus();
            }
        }

        private void schoolBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                phoneNumberbox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                housePhoneBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                languageBox.Focus();
            }
        }

        private void housePhoneBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                schoolBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                emailBox.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                emailBox.Focus();
            }
        }

        private void addressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                nameTextbox.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                languageBox.Focus();
            }
        }

        private void languageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                addressBox.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                emailBox.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                schoolBox.Focus();
            }

        }

        private void emailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                languageBox.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                housePhoneBox.Focus();
            }
        }
    }
}
