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
    public partial class BooksCard : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

        private bool addReturn = false;
        public bool getReturn = false;
        public bool onUsers = false;
        public bool admin = false;
        public bool moderator = false;
        private string[] getBooksId = { };
        bool isShow = false;
        private byte[] photoPath;
        private int bookNumber = 0;
        private int id = 0;
        private int userId = 0;
        private int page = 0;
        public int getReturnId = 0;
        private int managerId = 0;
        private string managerUsername = "";
        private string clock = "11:22:00";
        private DateTime takeDate = DateTime.Now;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public bool AddReturn { get => addReturn; set => addReturn = value; }
        public string[] GetBooksId { get => getBooksId; set => getBooksId = value; }
        public bool IsShow { get => isShow; set => isShow = value; }
        public byte[] PhotoPath { get => photoPath; set => photoPath = value; }
        public int BookNumber { get => bookNumber; set => bookNumber = value; }
        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int Page { get => page; set => page = value; }
        public DateTime TakeDate { get => takeDate; set => takeDate = value; }
        public string Clock { get => clock; set => clock = value; }
        public int ManagerId { get => managerId; set => managerId = value; }
        public string ManagerUsername { get => managerUsername; set => managerUsername = value; }

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public BooksCard()
        {
            InitializeComponent();

        }

        private void guna2PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsShow)
            {
                numberLabel.Visible = true;
                numberLabel.Text = BookNumber.ToString();
                guna2PictureBox1.Image = null;
                IsShow = true;
            }
            else
            {
                MemoryStream mem = new MemoryStream(PhotoPath);
                numberLabel.Visible = false;
                guna2PictureBox1.Image = Image.FromStream(mem);
                IsShow = false;
            }
        }

        private void BooksCard_Load(object sender, EventArgs e)
        {
            if (!getReturn&&!onUsers)
            {
                MemoryStream mem = new MemoryStream(PhotoPath);
                guna2PictureBox1.Image = Image.FromStream(mem);
            }
            else
            {
                getBooksInfo();
            }
            changeOpenpictureboxImage();
        }
        private void getBooksInfo()
        {
            SqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = SqlConnection;
            command.CommandText = ("Select * From [Books]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (getReturnId==Convert.ToInt32(reader["Id"]))
                {
                    BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["COVER"]);
                    photoPath = data;
                    MemoryStream mem = new MemoryStream(PhotoPath);
                    guna2PictureBox1.Image = Image.FromStream(mem);
                }
            }
            sqlConnection.Close();
        }
        private void changeOpenpictureboxImage()
        {
            if (AddReturn)
            {
                if (admin || moderator)
                {
                    openPicturebox.Image = Image.FromFile("images/plus_math_80px.png");
                }
                else
                {
                    openPicturebox.Image = Image.FromFile("images/lock_30px.png");
                }
            }
            else if (getReturn)
            {
                if (admin || moderator)
                {
                    openPicturebox.Image = Image.FromFile("images/return_book_80px.png");
                }
                else
                {
                    openPicturebox.Image = Image.FromFile("images/lock_30px.png");
                }
            }
        }
        private void numberLabel_MouseHover(object sender, EventArgs e)
        {
            openPicturebox.Visible = true;
        }

        private void BooksCard_MouseHover(object sender, EventArgs e)
        {
            openPicturebox.Visible = true;

        }

        private void openPicturebox_MouseLeave(object sender, EventArgs e)
        {
            openPicturebox.Visible = false;
        }

        private void guna2PictureBox1_MouseHover(object sender, EventArgs e)
        {
            openPicturebox.Visible = true;

        }

        private void BooksCard_MouseMove(object sender, MouseEventArgs e)
        {
            //openPicturebox.Visible = true;
        }

        private void BooksCard_MouseLeave(object sender, EventArgs e)
        {
            //openPicturebox.Visible = false;
        }

        private void guna2PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            openPicturebox.Visible = false;
        }

        private void numberLabel_MouseLeave(object sender, EventArgs e)
        {
            openPicturebox.Visible = false;
        }

        private void openPicturebox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AddReturn && !getReturn)
                {
                    SqlConnection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = SqlConnection;
                    command.CommandText = ("Select * From [Books]");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Id"]) == Id)
                        {
                            BookShowCard show = new BookShowCard();
                            show.Id = Convert.ToInt32(reader["Id"]);
                            show.writernameLabel.Text = reader["WRITER"].ToString();
                            show.certificatenoLabel.Text = reader["CERTIFICATENUMBER"].ToString();
                            show.printeddateDateLabel.Text = reader["PRINTEDDATE"].ToString();
                            show.stockNumberLabel.Text = reader["STOCKNUMBER"].ToString();
                            show.pageNumberNumLabel.Text = reader["PAGENUMBER"].ToString();
                            show.genusNameLabel.Text = reader["GENUS"].ToString();
                            show.shelfToLabel.Text = reader["SHELF"].ToString();
                            show.returnNumberLabel.Text = reader["RETURNBooks"].ToString();
                            show.publishouseLabel.Text = reader["PUBLISHHOUSE"].ToString();
                            show.isbnNumberLabel.Text = reader["ISBN"].ToString();
                            show.printedNumberNumLabel.Text = reader["PRINTEDNUMBER"].ToString();
                            show.teamNamesLabel.Text = reader["TEAM"].ToString();
                            show.languageNameLabel.Text = reader["LANGUAGE"].ToString();
                            show.translaterNameLabel.Text = reader["TRANSLATER"].ToString();
                            show.shelfLineNameLabel.Text = reader["SHELFLINE"].ToString();
                            string[] tags = reader["TAG"].ToString().Split(',');
                            show.tagTablePanel.Controls.Clear();
                            for (int tIndex = 0; tIndex < tags.Length; tIndex++)
                            {
                                Guna.UI2.WinForms.Guna2Chip tagChip = new Guna.UI2.WinForms.Guna2Chip();
                                tagChip.Text = tags[tIndex];
                                tagChip.FillColor = Color.Chocolate;
                                tagChip.IsClosable = false;
                                show.tagTablePanel.Controls.Add(tagChip);
                                tagChip.Show();
                            }
                            show.Tags = reader["TAG"].ToString().Split(',');
                            show.bookHeaderLabel.Text = reader["NAME"].ToString();
                            show.bookDetailLabel.Text = reader["DETAIL"].ToString();
                            show.savedDatetimeLabel.Text = DateTime.Now.ToString();
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["COVER"]);
                            MemoryStream mem = new MemoryStream(data);
                            show.bookPicturebox.Image = Image.FromStream(mem);
                            if (Convert.ToInt32(reader["MOSTREAD"]) == 1)
                            {
                                show.MostRead = true;
                            }
                            show.PhotoPath = PhotoPath;
                            show.powColor = powColor;
                            show.lightColor = lightColor;
                            show.foreColor = foreColor;
                            show.BackColor = lightColor;
                            show.editButton.FillColor = powColor;
                            show.guna2TileButton1.FillColor = powColor;
                            show.guna2TileButton2.FillColor = powColor;
                            show.guna2TileButton3.FillColor = powColor;
                            show.guna2TileButton4.FillColor = powColor;
                            show.guna2ShadowPanel6.FillColor = lightColor;
                            show.admin = admin;
                            show.moderator = moderator;
                            show.ManagerId = managerId;
                            show.ManagerUsername = managerUsername;
                            guna2Transition1.Show(show);
                            reader.Close();
                            SqlConnection.Close();
                            break;
                        }

                    }
                }
                else if (getReturn && onUsers)
                {
                    if (admin || moderator)
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = sqlConnection;
                            command.CommandText = "delete ReturnBooks where Id='" + Id + "'";
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                        int totalReturn = 0;
                        using (SqlCommand command = new SqlCommand())
                        {
                            sqlConnection.Open();
                            command.Connection = sqlConnection;
                            command.CommandText = ("Select * From [Users]");
                            SqlDataReader reader2 = command.ExecuteReader();
                            while (reader2.Read())
                            {
                                if (userId == Convert.ToInt32(reader2["Id"]))
                                {
                                    totalReturn = Convert.ToInt32(reader2["totalReturn"]);
                                }
                            }
                            reader2.Close();
                            sqlConnection.Close();
                        }
                        string query = "UPDATE Users SET totalReturn=@totalReturn where Id=@id";
                        using (SqlCommand command = new SqlCommand(query, sqlConnection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@id", userId);
                            command.Parameters.AddWithValue("@totalReturn", totalReturn + 1);
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                        openPicturebox.Visible = false;
                        loadingProgress.Visible = true;
                        loadingProgress.Start();
                        loadingTimer.Enabled = true;
                        loadingTimer.Start();
                        openPicturebox.Image = Image.FromFile("images/ok_30px.png");
                        openPicturebox.Enabled = false;
                    }
                    else
                    {
                        MaterialEffect effect = new MaterialEffect();
                        effect.Show();
                        WarningCard warning = new WarningCard();
                        warning.effect = effect;
                        warning.errorMode = true;
                        warning.fullNameLabel.Text = "Erişim Reddedildi";
                        warning.emailLabel.Text = "Emanet alabilmek için Admin veya Moderator olmanız gerekmektedir";
                        warning.ShowDialog();
                    }
                }
                else if (getReturn && !onUsers)
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    GetReturnDialog returnDialog = new GetReturnDialog();
                    returnDialog.onUsers = false;
                    returnDialog.effect = effect;
                    returnDialog.Id = getReturnId;
                    returnDialog.booksCard = false;
                    returnDialog.powColor = powColor;
                    returnDialog.lightColor = lightColor;
                    returnDialog.foreColor = foreColor;
                    returnDialog.BackColor = lightColor;
                    returnDialog.pageViewerPanel.BackColor = lightColor;
                    returnDialog.admin = admin;
                    returnDialog.moderator = moderator;
                    returnDialog.ShowDialog();
                }
                else if (addReturn)
                {
                    if (admin || moderator)
                    {
                        int totalReturn = 0;
                        using (SqlCommand command = new SqlCommand())
                        {
                            SqlConnection.Open();
                            command.Connection = SqlConnection;
                            command.CommandText = ("Select * From [ReturnBooks]");
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (Id == Convert.ToInt32(reader["BookId"]))
                                {
                                    totalReturn++;
                                }
                            }
                            reader.Close();
                            SqlConnection.Close();
                        }
                        int totalStock = bookNumber - totalReturn;
                        //emanet verme işlemi
                        if (totalStock > 0)
                        {
                            int totalBook = 0;
                            int totalPage = 0;
                            using (SqlCommand command = new SqlCommand())
                            {
                                SqlConnection.Open();
                                command.Connection = SqlConnection;
                                command.CommandText = ("Select * From [Users]");
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (UserId == Convert.ToInt32(reader["Id"]))
                                    {
                                        totalBook = Convert.ToInt32(reader["totalBook"]);
                                        totalPage = Convert.ToInt32(reader["TotalPage"]);
                                    }
                                }
                                reader.Close();
                                SqlConnection.Close();
                            }
                            openPicturebox.Visible = false;
                            loadingProgress.Visible = true;
                            loadingProgress.Start();
                            loadingTimer.Enabled = true;
                            loadingTimer.Start();
                            openPicturebox.Image = Image.FromFile("images/ok_30px.png");
                            openPicturebox.Enabled = false;
                            string query = "UPDATE Users SET totalBook = @book,TotalPage=@page where Id = @id";
                            using (SqlCommand command = new SqlCommand(query, SqlConnection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@id", UserId);
                                command.Parameters.AddWithValue("@book", totalBook + 1);
                                command.Parameters.AddWithValue("@page", totalPage + Page);
                                SqlConnection.Open();
                                command.ExecuteNonQuery();
                                SqlConnection.Close();
                            }
                            query = "INSERT INTO [ReturnBooks] (BookId,UserId,TakeDate,TakeClock,loss) Values (@bookid,@userid,@takedate,@takeclock,@loss)";
                            using (SqlCommand command = new SqlCommand(query, SqlConnection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@bookid", Id);
                                command.Parameters.AddWithValue("@userid", UserId);
                                command.Parameters.AddWithValue("@takedate", TakeDate);
                                command.Parameters.AddWithValue("@takeclock", DateTime.Parse(Clock));
                                command.Parameters.AddWithValue("@loss", 0);

                                SqlConnection.Open();
                                command.ExecuteNonQuery();
                                SqlConnection.Close();
                            }
                        }
                        else
                        {
                            MaterialEffect effect = new MaterialEffect();
                            effect.Show();
                            WarningCard warning = new WarningCard();
                            warning.effect = effect;
                            warning.fullNameLabel.Text = "Hiç Kitap Yok";
                            warning.emailLabel.Text = "Emanet verilecek kitap stokta kalmadı, lütfen emanetleri alın veya kitap ekleyin.";
                            warning.errorMode = true;
                            warning.ShowDialog();
                        }
                    }
                    else
                    {
                        MaterialEffect effect = new MaterialEffect();
                        effect.Show();
                        WarningCard warning = new WarningCard();
                        warning.effect = effect;
                        warning.errorMode = true;
                        warning.fullNameLabel.Text = "Erişim Reddedildi";
                        warning.emailLabel.Text = "Emanet verebilmek için Admin veya Moderator olmanız gerekmektedir";
                        warning.ShowDialog();
                    }
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.fullNameLabel.Text = "İşlem Hatası";
                warning.emailLabel.Text = "Geçici bir hata oluştu, lütfen tekrar deneyiniz.";
                warning.errorMode = true;
                warning.ShowDialog();
            }

        }

        private void openPicturebox_MouseHover(object sender, EventArgs e)
        {
            openPicturebox.Visible = true;
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            loadingProgress.Dispose();
            openPicturebox.Visible = true;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            loadingTimer.Dispose();
        }
    }
}
