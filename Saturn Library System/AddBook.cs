using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Saturn_Library_System
{
    public partial class AddBook : Form
    {
        //auto complete api
        //https://openlibrary.org/isbn/9780140328721.json
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

        String filePath = "images/default.jpg";
        private bool admin = false;
        private byte[] photoPath;
        private bool clearTag = false;
        private int maxTag = 0;
        private List<string> c = new List<string>();
        private bool editMode = false;
        private int id = 0;
        private int managerId = 0;
        private int returnBooks = 0;
        private bool autoCompleteIsbn = false;
        private bool saveHistory = false;
        private string access = "";
        private string managerUsername = "";
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public byte[] PhotoPath { get => photoPath; set => photoPath = value; }
        public bool ClearTag { get => clearTag; set => clearTag = value; }
        public int MaxTag { get => maxTag; set => maxTag = value; }
        public List<string> C { get => c; set => c = value; }
        public bool EditMode { get => editMode; set => editMode = value; }
        public int Id { get => id; set => id = value; }
        public int ReturnBooks { get => returnBooks; set => returnBooks = value; }
        public int UserId { get => ManagerId; set => ManagerId = value; }
        public bool Admin { get => admin; set => admin = value; }
        public string UserName { get => ManagerUsername; set => ManagerUsername = value; }
        public string Access { get => access; set => access = value; }
        public string ManagerUsername { get => managerUsername; set => managerUsername = value; }
        public int ManagerId { get => managerId; set => managerId = value; }

        public AddBook()
        {
            InitializeComponent();
        }

        private void readSettingsData()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * From Settings", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["AutoCompletedIsbn"]) == 1)
                        {
                            autoCompleteIsbn = true;
                        }
                        if (Convert.ToInt32(reader["SaveLog"]) == 1)
                        {
                            saveHistory = true;
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch
            {
            }
        }

        private void autoComplete()
        {
            try
            {
                var url = "https://openlibrary.org/isbn/" + isbnTextbox.Text + ".json";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Accept = "application/json";


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<Root>(result);
                    nameTextbox.Text = items.title;
                    publishHomeTextbox.Text = items.publishers[0];
                    pageNumberBox.Value = items.number_of_pages;
                    printedNumber.Value = items.revision;
                    guna2DateTimePicker1.Text = items.publish_date;
                    autoCompleteWriterAndCover("https://openlibrary.org" + items.authors[0].key + ".json");
                }
                isbnTextbox.IconRight = Image.FromFile("images/ok_30px.png");
            }
            catch
            {
                isbnTextbox.IconRight = Image.FromFile("images/error_30px.png");
            }
        }
        private void autoCompleteWriterAndCover(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Accept = "application/json";


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<Root>(result);
                    writerTextbox.Text = items.name;
                }
                using (WebClient webClient = new WebClient())
                {
                    StringBuilder builder = new StringBuilder();
                    Enumerable
                       .Range(65, 26)
                        .Select(e => ((char)e).ToString())
                        .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                        .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                        .OrderBy(e => Guid.NewGuid())
                        .Take(11)
                        .ToList().ForEach(e => builder.Append(e));
                    string id = builder.ToString();
                    webClient.DownloadFile("https://covers.openlibrary.org/b/isbn/" + isbnTextbox.Text + "-L.jpg", "booksCover/" + id + ".png");
                    filePath = "booksCover/" + id + ".png";
                    photoPath = ImageToStream(filePath);
                    MemoryStream stream = new MemoryStream(photoPath);
                    guna2PictureBox1.Image = Image.FromStream(stream);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch
            {
                isbnTextbox.IconRight = Image.FromFile("images/error_30px.png");
            }
        }
        private void AddBook_Load(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    Access = "Admin";
                }
                else
                {
                    Access = "Moderatör";
                }
                if (EditMode)
                {
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    MemoryStream mem = new MemoryStream(PhotoPath);
                    guna2PictureBox1.Image = Image.FromStream(mem);
                }
                else
                {
                    if (File.Exists(FilePath))
                    {
                        PhotoPath = ImageToStream(FilePath);
                    }
                }

                using (SqlCommand command = new SqlCommand("SELECT * From [Writer]", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        writerTextbox.AutoCompleteCustomSource.Add(reader["Name"].ToString() + " " + reader["Surname"].ToString());
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
                using (SqlCommand command = new SqlCommand("SELECT * From [PublishHouse]", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        publishHomeTextbox.AutoCompleteCustomSource.Add(reader["Name"].ToString());
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
                using (SqlCommand command = new SqlCommand("SELECT * From [Books]", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] tag = reader["TAG"].ToString().Split(',');
                        for (int tagIndex = 0; tagIndex < tag.Length; tagIndex++)
                        {
                            if (!tagTextbox.AutoCompleteCustomSource.Contains(tag[tagIndex]))
                            {
                                tagTextbox.AutoCompleteCustomSource.Add(tag[tagIndex]);
                            }
                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
                readSettingsData();
            }
            catch
            {
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (nameTextbox.Text != "" && writerTextbox.Text != "" && publishHomeTextbox.Text != "" && genusTextbox.Text != "" && guna2DateTimePicker1.Text != ""  && detailsTextbox.Text != ""  && shelfTextbox.Text != "" && shelfLineTextbox.Text != "" && certificateTextbox.Text != "" && teamTextbox.Text != "" && languageTextbox.Text != "" && translaterTextbox.Text != "")
            {
                try
                {
                    String tag = "";
                    for (int t = 0; t < C.Count; t++)
                    {
                        tag += "," + C[t];
                    }

                    //UPDATE Books SET
                    string query = "";
                    if (EditMode)
                    {
                        query = "UPDATE Books SET Name = @name,ISBN = @isbn,WRITER = @writer,PUBLISHHOUSE = @phouse,GENUS = @genus,PRINTEDDATE = @pdate,PRINTEDNUMBER = @printedNumber,PAGENUMBER = @pagenumber,STOCKNUMBER = @stocknumber,SHELF = @shelf,COVER = @cover,CERTIFICATENUMBER = @certificate,DETAIL = @detail,SHELFLINE = @shelfline,TEAM = @team,LANGUAGE = @language,TAG = @tag,TRANSLATER = @translater,MOSTREAD = @most,SAVEDDATE = @savedDate,RETURNBooks = @return where Id = @id";
                    }
                    else
                    {
                        query = "INSERT INTO [Books] (Name,ISBN,WRITER,PUBLISHHOUSE,GENUS,PRINTEDDATE,PRINTEDNUMBER,PAGENUMBER,STOCKNUMBER,SHELF,COVER,CERTIFICATENUMBER,DETAIL,SHELFLINE,TEAM,LANGUAGE,TAG,TRANSLATER,MOSTREAD,SAVEDDATE,RETURNBooks) VALUES (@name,@isbn,@writer,@phouse,@genus,@pdate,@printedNumber,@pagenumber,@stocknumber,@shelf,@cover,@certificate,@detail,@shelfline,@team,@language,@tag,@translater,@most,@savedDate,@return)";
                    }
                    using (SqlCommand command = new SqlCommand(query, SqlConnection))
                    {
                        command.Parameters.Clear();
                        if (EditMode)
                        {
                            command.Parameters.AddWithValue("@id", Id);
                        }
                        command.Parameters.AddWithValue("@name", nameTextbox.Text);
                        command.Parameters.AddWithValue("@isbn", isbnTextbox.Text);
                        command.Parameters.AddWithValue("@writer", writerTextbox.Text);
                        command.Parameters.AddWithValue("@phouse", publishHomeTextbox.Text);
                        command.Parameters.AddWithValue("@genus", genusTextbox.Text);
                        command.Parameters.AddWithValue("@pdate", guna2DateTimePicker1.Text);
                        command.Parameters.AddWithValue("@printedNumber", Convert.ToInt32(printedNumber.Value));
                        command.Parameters.AddWithValue("@pagenumber", Convert.ToInt32(pageNumberBox.Value));
                        command.Parameters.AddWithValue("@stocknumber", Convert.ToInt32(stockNumberBox.Value));
                        command.Parameters.AddWithValue("@shelf", shelfTextbox.Text);


                        command.Parameters.AddWithValue("@cover", PhotoPath);
                        command.Parameters.AddWithValue("@certificate", certificateTextbox.Text);
                        command.Parameters.AddWithValue("@detail", detailsTextbox.Text);
                        command.Parameters.AddWithValue("@shelfline", shelfLineTextbox.Text);
                        command.Parameters.AddWithValue("@team", teamTextbox.Text);
                        command.Parameters.AddWithValue("@language", languageTextbox.Text);
                        if (tag != "")
                        {
                            command.Parameters.AddWithValue("@tag", tag.Substring(1));

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@tag", null);

                        }
                        command.Parameters.AddWithValue("@translater", translaterTextbox.Text);
                        if (mostToggle.Checked)
                        {
                            command.Parameters.AddWithValue("@most", 1);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@most", 0);

                        }
                        command.Parameters.AddWithValue("@savedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@return", ReturnBooks);

                        SqlConnection.Open();
                        command.ExecuteNonQuery();
                        SqlConnection.Close();
                    }
                    if (saveHistory)
                    {
                 
                    }
                    saveButton.ForeColor = Color.White;
                    saveButton.Visible = false;
                    loadingProgress.Visible = true;
                    loadingProgress.Start();
                    saveLoadingTimer.Enabled = true;
                    saveLoadingTimer.Start();
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
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Resim (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif");
            openFileDialog1.Title = "Resim Dosyası Seçin";
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName!= "openFileDialog1" && openFileDialog1.FileName!="")
            {
                FilePath = openFileDialog1.FileName;
                guna2PictureBox1.Image = Image.FromFile(FilePath);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                if (File.Exists(FilePath))
                {
                    PhotoPath = ImageToStream(FilePath);
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

        private void saveLoadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Visible = false;
            saveButton.Visible = true;
            loadingProgress.Stop();
            saveLoadingTimer.Stop();
            saveLoadingTimer.Dispose();
        }

        private void tagTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (MaxTag < 4)
                    {
                        if (!C.Contains(tagTextbox.Text))
                        {
                            C.Add(tagTextbox.Text);
                            if (!ClearTag)
                            {
                                tableLayoutPanel1.Controls.Clear();
                                ClearTag = true;
                            }
                            Guna.UI2.WinForms.Guna2Chip chip = new Guna.UI2.WinForms.Guna2Chip();
                            chip.FillColor = Color.Chocolate;
                            chip.Text = C.Last();
                            tableLayoutPanel1.Controls.Add(chip);
                            chip.Show();
                            tagTextbox.Clear();
                            MaxTag++;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void tableLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            try
            {
                if (ClearTag)
                {
                    C.Remove(e.Control.Text);
                    if (C.Count > 0)
                    {
                        MaxTag--;

                    }
                    else
                    {
                        MaxTag = 0;
                        ClearTag = false;
                        Guna.UI2.WinForms.Guna2Chip chip = new Guna.UI2.WinForms.Guna2Chip();
                        chip.FillColor = Color.Chocolate;
                        chip.Text = "(boş)";
                        tableLayoutPanel1.Controls.Add(chip);
                        chip.Show();
                    }
                }
            }
            catch
            {
            }
        }

        public class Author
        {
            public string key { get; set; }
        }

        public class Classifications
        {
        }

        public class Created
        {
            public string type { get; set; }
            public DateTime value { get; set; }
        }

        public class FirstSentence
        {
            public string type { get; set; }
            public string value { get; set; }
        }

        public class Identifiers
        {
            public List<string> goodreads { get; set; }
            public List<string> librarything { get; set; }
        }

        public class Language
        {
            public string key { get; set; }
        }

        public class LastModified
        {
            public string type { get; set; }
            public DateTime value { get; set; }
        }

        public class Root
        {
            public List<string> publishers { get; set; }
            public int number_of_pages { get; set; }
            public List<string> isbn_10 { get; set; }
            public List<int> covers { get; set; }
            public string key { get; set; }
            public List<Author> authors { get; set; }
            public string ocaid { get; set; }
            public List<string> contributions { get; set; }
            public List<Language> languages { get; set; }
            public Classifications classifications { get; set; }
            public List<string> source_records { get; set; }
            public string title { get; set; }
            public Identifiers identifiers { get; set; }
            public List<string> isbn_13 { get; set; }
            public List<string> local_id { get; set; }
            public string publish_date { get; set; }
            public List<Work> works { get; set; }
            public Type type { get; set; }
            public FirstSentence first_sentence { get; set; }
            public int latest_revision { get; set; }
            public int revision { get; set; }
            public Created created { get; set; }
            public LastModified last_modified { get; set; }
            public string name { get; set; }
        }

        public class Type
        {
            public string key { get; set; }
        }

        public class Work
        {
            public string key { get; set; }
        }

        private void isbnTextbox_IconRightClick(object sender, EventArgs e)
        {
            autoComplete();
        }

        private void isbnTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (autoCompleteIsbn && isbnTextbox.Text != string.Empty)
                {
                    isbnTextbox.IconRight = Image.FromFile("images/ok_30px.png");
                }
                else
                {
                    isbnTextbox.IconRight = null;
                }
            }
            catch
            {
            }
        }
    }
}
