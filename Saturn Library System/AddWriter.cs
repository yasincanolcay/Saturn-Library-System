using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Saturn_Library_System
{
    public partial class AddWriter : Form
    {
        private bool editMode = false;
        private int id = 0;
        string picturePath = "images/male_user_80px.png";
        private byte[] pictureByte = { };

        public bool EditMode { get => editMode; set => editMode = value; }
        public int Id { get => id; set => id = value; }
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public byte[] PictureByte { get => pictureByte; set => pictureByte = value; }

        public AddWriter()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void AddWriter_Load(object sender, EventArgs e)
        {
            if (EditMode)
            {
                saveButton.Text = "Kaydet";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * From [Writer]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Id == Convert.ToInt32(reader["Id"]))
                    {
                        nameTextbox.Text = reader["Name"].ToString();
                        surnameBox.Text = reader["Surname"].ToString();
                        linksBox.Text = reader["Links"].ToString();
                        phoneNumberbox.Text = reader["Phone"].ToString();
                        genusBox.Text = reader["Genus"].ToString();
                        cityBox.Text = reader["City"].ToString();
                        infoBox.Text = reader["Info"].ToString();
                        languageBox.Text = reader["Language"].ToString();
                        emailBox.Text = reader["Email"].ToString();
                        Byte[] data = new Byte[0];
                        pictureByte = (Byte[])(reader["Photo"]);
                        MemoryStream mem = new MemoryStream(pictureByte);
                        profilePicturebox.Image = Image.FromStream(mem);
                        profilePicturebox.BackgroundImage = Image.FromStream(mem);
                        profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            else
            {
                PictureByte = ImageToStream(PicturePath);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Visible = false;
            loadingProgress.Visible = true;
            loadingProgress.Start();
            loadingTimer.Enabled = true;
            loadingTimer.Start();
            Thread saveThread = new Thread(new ThreadStart(saveData));
            saveThread.Start();
        }
        private void saveData()
        {
            if (nameTextbox.Text != string.Empty && surnameBox.Text != string.Empty && phoneNumberbox.Text != string.Empty && genusBox.Text != string.Empty && cityBox.Text != string.Empty && infoBox.Text != string.Empty && languageBox.Text != string.Empty && emailBox.Text != string.Empty)
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                string query = "";
                if (!EditMode)
                {
                    query = "INSERT INTO [Writer] (Name,Surname,Links,Phone,Genus,City,Info,Language,Email,Photo) VALUES (@name,@surname,@links,@phone,@genus,@city,@info,@language,@email,@photo)";

                }
                else
                {
                    query = "UPDATE Writer SET Name=@name,Surname=@surname,Links=@links,Phone=@phone,Genus=@genus,City=@city,Info=@info,Language=@language,Email=@email,Photo=@photo where Id=@id";
                }
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    if (EditMode)
                    {
                        command.Parameters.AddWithValue("@id", Id);
                    }
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", nameTextbox.Text);
                    command.Parameters.AddWithValue("@surname", surnameBox.Text);
                    command.Parameters.AddWithValue("@links", linksBox.Text);
                    command.Parameters.AddWithValue("@phone", phoneNumberbox.Text);
                    command.Parameters.AddWithValue("@genus", genusBox.Text);
                    command.Parameters.AddWithValue("@city", cityBox.Text);
                    command.Parameters.AddWithValue("@info", infoBox.Text);
                    command.Parameters.AddWithValue("@language", languageBox.Text);
                    command.Parameters.AddWithValue("@email", emailBox.Text);
                    command.Parameters.AddWithValue("@photo", PictureByte);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
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
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                goto tryagain;
            }

            return stream.ToArray();
        }
        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            saveButton.Visible = true;
            loadingProgress.Visible = false;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            loadingTimer.Dispose();
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
                profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                if (File.Exists(PicturePath))
                {
                    PictureByte = ImageToStream(PicturePath);
                }
            }
        }
    }
}
