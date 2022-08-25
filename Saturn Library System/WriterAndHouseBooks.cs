using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class WriterAndHouseBooks : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        bool sortingChange = false;
        bool IssearchBoxClear = false;
        bool searchBoxSourceIsAdded = false;
        public bool admin = false;
        public bool moderator = false;
        public List<int> booksId = new List<int>();

        public Panel pageViewerPanel = new Panel();
        public HomePage home = new HomePage();
        public WritersPage writers = new WritersPage();

        public bool homeMode = false;


        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;

        public WriterAndHouseBooks()
        {
            InitializeComponent();
        }

        private void WriterAndHouseBooks_Load(object sender, EventArgs e)
        {
            loadBooks(false);
        }
        private void loadBooks(bool seacrh)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Books]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (booksId.Contains(Convert.ToInt32(reader["Id"])))
                {
                    BooksCard card = new BooksCard();
                    card.BackColor = lightColor;
                    card.guna2ShadowPanel6.FillColor = lightColor;
                    card.powColor = powColor;
                    card.lightColor = lightColor;
                    card.foreColor = foreColor;
                    card.admin = admin;
                    card.moderator = moderator;
                    if (!seacrh)
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
                        if (!searchBoxSourceIsAdded)
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
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }

                    }
                }
            }
            searchBoxSourceIsAdded = true;
            reader.Close();
            sqlConnection.Close();
        }
        private void loadBooksDetailsCard(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Books]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (booksId.Contains(Convert.ToInt32(reader["Id"])))
                {
                    BookDetailCard card = new BookDetailCard();
                    card.thumbShadowPanel.FillColor = lightColor;
                    card.BackColor = lightColor;
                    card.guna2Panel1.FillColor = lightColor;
                    card.powColor = powColor;
                    card.lightColor = lightColor;
                    card.foreColor = foreColor;
                    card.admin = admin;
                    card.moderator = moderator;
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
                            card.Page = Convert.ToInt32(reader["PAGENUMBER"]);
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void thumbSortButton_Click(object sender, EventArgs e)
        {
            loadBooks(false);
            thumbSortButton.ShadowDecoration.Enabled = true;
            listSortButton.ShadowDecoration.Enabled = false;
            sortingChange = false;
        }

        private void listSortButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Enabled = false;
            sortingChange = true;
            loadBooksDetailsCard(false);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            filterCombobox.SelectedItem=default;
            IssearchBoxClear = false;
            if (!sortingChange)
            {
                loadBooks(false);
            }
            else
            {
                loadBooksDetailsCard(false);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text != string.Empty)
            {
                if (filterCombobox.Text.Length > 0)
                {
                    IssearchBoxClear = true;
                    filterCombobox.Text = "";
                }
                if (!sortingChange)
                {
                    loadBooks(true);
                }
                else
                {
                    loadBooksDetailsCard(true);
                }
            }
            else
            {
                refreshButton.PerformClick();
            }
        }

        private void filterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0 && !IssearchBoxClear)
            {
                searchBox.Clear();
            }
            if (!sortingChange)
            {
                loadBooks(true);
            }
            else
            {
                loadBooksDetailsCard(true);
            }
            IssearchBoxClear = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!homeMode)
            {
                pageViewerPanel.Controls.Clear();
                pageViewerPanel.Controls.Add(writers);
                writers.Show();
            }
            else
            {
                pageViewerPanel.Controls.Clear();
                pageViewerPanel.Controls.Add(home);
                home.Show();
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("usercardImages/left_60px_hover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("usercardImages/left_60px.png");
        }
    }
}
