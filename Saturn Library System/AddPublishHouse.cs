using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Saturn_Library_System
{
    public partial class AddPublishHouse : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");


        string picturePath = "images/male_user_80px.png";
        private byte[] pictureByte = { };
        bool editMode = false;
        public int Id = 0;
        public string PicturePath { get => PicturePath1; set => PicturePath1 = value; }
        public byte[] PictureByte { get => PictureByte1; set => PictureByte1 = value; }
        public bool EditMode { get => EditMode1; set => EditMode1 = value; }
        public string PicturePath1 { get => picturePath; set => picturePath = value; }
        public byte[] PictureByte1 { get => pictureByte; set => pictureByte = value; }
        public bool EditMode1 { get => editMode; set => editMode = value; }

        public AddPublishHouse()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void AddPublishHouse_Load(object sender, EventArgs e)
        {
            try
            {
                if (EditMode)
                {
                    saveButton.Text = "Kaydet";
                    using (SqlCommand command = new SqlCommand("SELECT * From [PublishHouse]", sqlConnection))
                    {
                        sqlConnection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (Id == Convert.ToInt32(reader["Id"]))
                            {
                                nameTextbox.Text = reader["Name"].ToString();
                                certificateBox.Text = reader["Certificate"].ToString();
                                addressBox.Text = reader["Address"].ToString();
                                infoBox.Text = reader["Info"].ToString();
                                contactBox.Text = reader["Contact"].ToString();
                                linksBox.Text = reader["Links"].ToString();
                                extraBox.Text = reader["Extra"].ToString();
                                Byte[] data = new Byte[0];
                                pictureByte = (Byte[])(reader["Icon"]);
                                MemoryStream mem = new MemoryStream(pictureByte);
                                profilePicturebox.Image = Image.FromStream(mem);
                                profilePicturebox.BackgroundImage = Image.FromStream(mem);
                                profilePicturebox.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        reader.Close();
                        sqlConnection.Close();
                    }
                }
                else
                {
                    PictureByte = ImageToStream(PicturePath);
                }
            }
            catch
            {
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            loadingProgress.Dispose();
            saveButton.Visible = true;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            loadingTimer.Dispose();
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
            try
            {
                if (nameTextbox.Text != string.Empty && certificateBox.Text != string.Empty && linksBox.Text != string.Empty && contactBox.Text != string.Empty && infoBox.Text != string.Empty)
                {
                    string query = "";
                    if (!EditMode)
                    {
                        query = "INSERT INTO [PublishHouse] (Name,Certificate,Address,Info,Icon,Contact,Links,Extra) VALUES (@name,@certificate,@address,@info,@icon,@contact,@links,@extra)";
                    }
                    else
                    {
                        query = "UPDATE PublishHouse SET Name=@name,Certificate=@certificate,Address=@address,Info=@info,Icon=@icon,Contact=@contact,Links=links,Extra=@extra where Id=@id";
                    }
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Clear();
                        if (editMode)
                            command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@name", nameTextbox.Text);
                        command.Parameters.AddWithValue("@certificate", certificateBox.Text);
                        command.Parameters.AddWithValue("@address", addressBox.Text);
                        command.Parameters.AddWithValue("@info", infoBox.Text);
                        command.Parameters.AddWithValue("@icon", PictureByte);
                        command.Parameters.AddWithValue("@contact", contactBox.Text);
                        command.Parameters.AddWithValue("@links", linksBox.Text);
                        command.Parameters.AddWithValue("@extra", extraBox.Text);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
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
                warning.emailLabel.Text = "Kayıt yapılırken bir hata oluştu, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
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
