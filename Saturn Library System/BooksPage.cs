using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
namespace Saturn_Library_System
{
    public partial class BooksPage : Form
    {
        //update database data
        //  komut = "UPDATE Merhaba.dbo.Rehber SET Adi=@Adi, Tel =@Tel where id=@id";
        //SqlParameterCollection param = sql_cmd.Parameters;
        //param.AddWithValue("id",textBox1.Text);
        //add image database
        /*
           using (SqlCommand com = new SqlCommand("INSERT INTO myTable (myImage) VALUES (@IM)", con))
        {
        byte[] imageData = File.ReadAllBytes(@"F:\Temp\Picture.jpg");
        com.Parameters.AddWithValue("@IM", imageData);
        com.ExecuteNonQuery();
        }
         */

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

        bool sortingChange = false;
        bool IssearchBoxClear = false;
        bool searchBoxSourceIsAdded = false;
        private bool admin = false;
        private bool moderator = false;
        private bool addReturn = false;
        private int userId = 0;
        private int page = 0;
        public int stockNumber = 0;
        private int managerId = 0;
        private string managerUsername = "";
        private DateTime takeDate = DateTime.Now;
        private string clock = "11:22:00";

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public bool SortingChange { get => sortingChange; set => sortingChange = value; }
        public bool IssearchBoxClear1 { get => IssearchBoxClear; set => IssearchBoxClear = value; }
        public bool SearchBoxSourceIsAdded { get => searchBoxSourceIsAdded; set => searchBoxSourceIsAdded = value; }
        public bool AddReturn { get => addReturn; set => addReturn = value; }
        public int UserId { get => userId; set => userId = value; }
        public int Page { get => page; set => page = value; }
        public DateTime TakeDate { get => takeDate; set => takeDate = value; }
        public string Clock { get => clock; set => clock = value; }
        public bool Admin { get => admin; set => admin = value; }
        public bool Moderator { get => moderator; set => moderator = value; }
        public int ManagerId { get => managerId; set => managerId = value; }
        public string ManagerUsername { get => managerUsername; set => managerUsername = value; }

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public BooksPage()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void BooksPage_Load(object sender, EventArgs e)
        {
            loadBook(false);
        }
        private void showWarning()
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            WarningCard warning = new WarningCard();
            warning.effect = effect;
            warning.fullNameLabel.Text = "İşlem Hatası";
            warning.emailLabel.Text = "İşlemler tamamlanamadı, lütfen tekrar deneyin veya destek isteyin.";
            warning.errorMode = true;
            warning.ShowDialog();
        }
        private void loadBook(bool search)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                SqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = ("Select * From [Books]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BooksCard card = new BooksCard();
                    card.guna2ShadowPanel6.FillColor = lightColor;
                    card.BackColor = lightColor;
                    card.powColor = powColor;
                    card.lightColor = lightColor;
                    card.foreColor = foreColor;
                    card.admin = Admin;
                    card.moderator = Moderator;
                    card.ManagerId = managerId;
                    card.ManagerUsername = managerUsername;
                    if (!search)
                    {
                        card.TopLevel = false;
                        card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["COVER"]);
                        //MemoryStream mem = new MemoryStream(data);
                        string[] tag = reader["TAG"].ToString().Split(',');
                        for (int tagIndex = 0; tagIndex < tag.Length; tagIndex++)
                        {
                            if (!filterCombobox.Items.Contains(tag[tagIndex]))
                            {
                                filterCombobox.Items.Add(tag[tagIndex]);
                            }
                        }
                        card.PhotoPath = data;
                        card.Id = Convert.ToInt32(reader["Id"]);
                        if (!SearchBoxSourceIsAdded)
                        {
                            searchBox.AutoCompleteCustomSource.Add(reader["NAME"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["ISBN"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["WRITER"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["PUBLISHHOUSE"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["GENUS"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["CERTIFICATENUMBER"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["SHELF"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["PRINTEDDATE"].ToString());
                        }
                        card.UserId = UserId;
                        card.AddReturn = AddReturn;
                        card.TakeDate = TakeDate;
                        card.Clock = Clock;
                        card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    else
                    {

                        if (searchBox.Text.ToLower() == reader["Name"].ToString().ToLower() || searchBox.Text.ToLower() == reader["ISBN"].ToString().ToLower() || searchBox.Text.ToLower() == reader["WRITER"].ToString().ToLower() || searchBox.Text.ToLower() == reader["PUBLISHHOUSE"].ToString().ToLower() || searchBox.Text.ToLower() == reader["GENUS"].ToString().ToLower() || searchBox.Text.ToLower() == reader["CERTIFICATENUMBER"].ToString().ToLower() || searchBox.Text.ToLower() == reader["SHELF"].ToString().ToLower() || searchBox.Text == reader["PRINTEDDATE"].ToString())
                        {
                            card.TopLevel = false;
                            card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["COVER"]);
                            //MemoryStream mem = new MemoryStream(data);
                            card.PhotoPath = data;
                            card.Id = Convert.ToInt32(reader["Id"]);
                            card.UserId = UserId;
                            card.AddReturn = AddReturn;
                            card.TakeDate = TakeDate;
                            card.Clock = Clock;
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }
                        if (reader["TAG"].ToString().Split(',').Contains(filterCombobox.Text) && filterCombobox.Text != "")
                        {
                            card.TopLevel = false;
                            card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["COVER"]);
                            //MemoryStream mem = new MemoryStream(data);
                            card.PhotoPath = data;
                            card.Id = Convert.ToInt32(reader["Id"]);
                            card.UserId = UserId;
                            card.AddReturn = AddReturn;
                            card.TakeDate = TakeDate;
                            card.Clock = Clock;
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }

                    }
                }
                SearchBoxSourceIsAdded = true;
                reader.Close();
                SqlConnection.Close();
            }
            catch
            {
                showWarning();
            }
        }
        private void loadListTypeBook(bool search)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                SqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = ("Select * From [Books]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookDetailCard card = new BookDetailCard();
                    card.BackColor = lightColor;
                    card.guna2Panel1.FillColor = lightColor;
                    card.powColor = powColor;
                    card.lightColor = lightColor;
                    card.foreColor = foreColor;
                    card.admin = Admin;
                    card.moderator = Moderator;
                    card.ManagerId = managerId;
                    card.ManagerUsername = managerUsername;
                    if (!search)
                    {
                        card.TopLevel = false;
                        card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["COVER"]);
                        //MemoryStream mem = new MemoryStream(data);
                        card.PhotoPath = data;
                        card.bookNameLabel.Text = reader["Name"].ToString();
                        card.detailsShortLabel.Text = reader["DETAIL"].ToString();
                        card.writerNameLabel.Text = reader["WRITER"].ToString();
                        string[] tag = reader["TAG"].ToString().Split(',');
                        card.Tag1 = tag;
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.UserId = UserId;
                        card.AddReturn = AddReturn;
                        card.TakeDate = TakeDate;
                        card.Clock = Clock;
                        card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    else
                    {
                        if (searchBox.Text.ToLower() == reader["Name"].ToString().ToLower() || searchBox.Text.ToLower() == reader["ISBN"].ToString().ToLower() || searchBox.Text.ToLower() == reader["WRITER"].ToString().ToLower() || searchBox.Text.ToLower() == reader["PUBLISHHOUSE"].ToString().ToLower() || searchBox.Text.ToLower() == reader["GENUS"].ToString().ToLower() || searchBox.Text.ToLower() == reader["CERTIFICATENUMBER"].ToString().ToLower() || searchBox.Text.ToLower() == reader["SHELF"].ToString().ToLower() || searchBox.Text == reader["PRINTEDDATE"].ToString())
                        {
                            card.TopLevel = false;
                            card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["COVER"]);
                            //MemoryStream mem = new MemoryStream(data);
                            card.PhotoPath = data;
                            card.bookNameLabel.Text = reader["Name"].ToString();
                            card.detailsShortLabel.Text = reader["DETAIL"].ToString();
                            card.writerNameLabel.Text = reader["WRITER"].ToString();
                            string[] tag = reader["TAG"].ToString().Split(',');
                            card.Tag1 = tag;
                            card.Id = Convert.ToInt32(reader["Id"]);
                            card.UserId = UserId;
                            card.AddReturn = AddReturn;
                            card.TakeDate = TakeDate;
                            card.Clock = Clock;
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }
                        else if (reader["TAG"].ToString().Split(',').Contains(filterCombobox.Text) && filterCombobox.Text != "")
                        {
                            card.TopLevel = false;
                            card.BookNumber = Convert.ToInt32(reader["STOCKNUMBER"]);
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["COVER"]);
                            //MemoryStream mem = new MemoryStream(data);
                            card.PhotoPath = data;
                            card.bookNameLabel.Text = reader["Name"].ToString();
                            card.detailsShortLabel.Text = reader["DETAIL"].ToString();
                            card.writerNameLabel.Text = reader["WRITER"].ToString();
                            string[] tag = reader["TAG"].ToString().Split(',');
                            card.Tag1 = tag;
                            card.Id = Convert.ToInt32(reader["Id"]);
                            card.UserId = UserId;
                            card.AddReturn = AddReturn;
                            card.TakeDate = TakeDate;
                            card.Clock = Clock;
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }
                    }
                }
                reader.Close();
                SqlConnection.Close();
            }
            catch
            {
                showWarning();
            }
        }
        private void thumbSortButton_Click(object sender, EventArgs e)
        {
            loadBook(false);
            thumbSortButton.ShadowDecoration.Enabled = true;
            listSortButton.ShadowDecoration.Enabled = false;
            SortingChange = false;
        }
        private void listSortButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Enabled = false;
            SortingChange = true;
            loadListTypeBook(false);
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            filterCombobox.Text = "";
            IssearchBoxClear1 = false;
            if (!SortingChange)
            {
                loadBook(false);
            }
            else
            {
                loadListTypeBook(false);
            }
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text != string.Empty)
            {
                if (filterCombobox.Text.Length > 0)
                {
                    IssearchBoxClear1 = true;
                    filterCombobox.Text = "";
                }
                if (!SortingChange)
                {
                    loadBook(true);
                }
                else
                {
                    loadListTypeBook(true);
                }
            }
            else
            {
                refreshButton.PerformClick();
            }
        }

        private void filterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0 && !IssearchBoxClear1)
            {
                searchBox.Clear();
            }
            if (!SortingChange)
            {
                loadBook(true);
            }
            else
            {
                loadListTypeBook(true);
            }
            IssearchBoxClear1 = false;
        }
    }
}
