using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class ReturnPage : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool admin = false;
        public bool moderator = false;
        public bool addLoss = false;
        public bool booksCard = false;
        public bool onUsers = false;
        public int Id = 0;
        public int totalReturn = 0;
        int getId = 0;
        List<int> books = new List<int>();
        List<int> userId = new List<int>();
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public ReturnPage()
        {
            InitializeComponent();
        }

        private void ReturnPage_Load(object sender, EventArgs e)
        {
            if (booksCard)
            {
                loadBookCard(false);
            }
            else
            {
                loadUsersCard(false);
                headerLabel.Text = "Kitabı Alan Kullanıcılar";
            }
        }

        private void loadBookCard(bool sorting)
        {
            books.Clear();
            flowLayoutPanel1.Controls.Clear();
            if (!onUsers)
            {
                getId = Id;
            }
            if (!sorting)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT * From [ReturnBooks]";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (onUsers)
                        {
                            getId = Convert.ToInt32(reader["UserId"]);
                        }
                        if (Id == getId)
                        {
                            if (!books.Contains(Convert.ToInt32(reader["BookId"])))
                            {
                                BooksCard card = new BooksCard();
                                card.TopLevel = false;
                                card.guna2ShadowPanel6.FillColor = lightColor;
                                card.BackColor = lightColor;
                                card.powColor = powColor;
                                card.lightColor = lightColor;
                                card.foreColor = foreColor;
                                card.getReturnId = Convert.ToInt32(reader["BookId"]);
                                card.Id = Convert.ToInt32(reader["Id"]);
                                card.UserId = getId;
                                card.getReturn = true;
                                card.onUsers = onUsers;
                                card.guna2ShadowPanel6.FillColor = lightColor;
                                card.BackColor = lightColor;
                                card.admin = admin;
                                card.moderator = moderator;
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                                books.Add(Convert.ToInt32(reader["BookId"]));
                            }
                            //kullanıcılar kartında emaneti al kısmına basınca bu sayfa show dialog
                            //şeklinde yuklenecek ve getreturn, onusers true olacak
                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT * From [ReturnBooks]";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (onUsers)
                        {
                            getId = Convert.ToInt32(reader["UserId"]);
                        }
                        if (Id == getId)
                        {
                            if (!books.Contains(Convert.ToInt32(reader["BookId"])))
                            {
                                BookDetailCard card = new BookDetailCard();
                                card.TopLevel = false;
                                card.BackColor = lightColor;
                                card.guna2Panel1.FillColor = lightColor;
                                card.powColor = powColor;
                                card.lightColor = lightColor;
                                card.foreColor = foreColor;
                                card.getReturnId = Convert.ToInt32(reader["BookId"]);
                                card.Id = Convert.ToInt32(reader["Id"]);
                                card.UserId = getId;
                                card.getReturn = true;
                                card.onUsers = onUsers;
                                card.guna2Panel1.FillColor = lightColor;
                                card.BackColor = lightColor;
                                card.thumbShadowPanel.FillColor = lightColor;
                                card.admin = admin;
                                card.moderator = moderator;
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                                books.Add(Convert.ToInt32(reader["BookId"]));
                            }
                            //kullanıcılar kartında emaneti al kısmına basınca bu sayfa show dialog
                            //şeklinde yuklenecek ve getreturn, onusers true olacak
                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
        }
        private void loadUsersCard(bool sorting)
        {
            flowLayoutPanel1.Controls.Clear();
            userId.Clear();
            if (!sorting)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT * From [ReturnBooks]";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Id == Convert.ToInt32(reader["BookId"]))
                        {
                            if (!userId.Contains(Convert.ToInt32(reader["UserId"])))
                            {
                                UserCard card = new UserCard();
                                card.TopLevel = false;
                                card.bookId = Convert.ToInt32(reader["Id"]);
                                card.Id = Convert.ToInt32(reader["UserId"]);
                                card.guna2Panel1.FillColor = lightColor;
                                card.emailLabel.ForeColor = foreColor;
                                card.BackColor = lightColor;
                                card.powColor = powColor;
                                card.lightColor = lightColor;
                                card.foreColor = foreColor;
                                if (!addLoss)
                                {
                                    card.getReturn = true;
                                }
                                else
                                {
                                    card.addLoss = true;
                                }
                                card.admin = admin;
                                card.moderator = moderator;
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                                userId.Add(Convert.ToInt32(reader["UserId"]));
                            }

                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT * From [ReturnBooks]";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Id == Convert.ToInt32(reader["BookId"]))
                        {
                            if (!userId.Contains(Convert.ToInt32(reader["UserId"])))
                            {
                                UserDetailsCard card = new UserDetailsCard();
                                card.TopLevel = false;
                                card.bookId = Convert.ToInt32(reader["Id"]);
                                card.Id = Convert.ToInt32(reader["UserId"]);
                                card.guna2Panel1.FillColor = lightColor;
                                card.emailLabel.ForeColor = foreColor;
                                card.BackColor = lightColor;
                                card.powColor = powColor;
                                card.lightColor = lightColor;
                                card.foreColor = foreColor;
                                if (!addLoss)
                                {
                                    card.getReturn = true;
                                }
                                else
                                {
                                    card.addLoss = true;
                                }
                                card.admin = admin;
                                card.moderator = moderator;
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                                userId.Add(Convert.ToInt32(reader["UserId"]));
                            }

                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
        }
        private void guna2HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void listSortButton_Click(object sender, EventArgs e)
        {
            if (booksCard)
            {
                loadBookCard(true);
            }
            else
            {
                loadUsersCard(true);
            }
            listSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Enabled = false;
            listSortButton.ShadowDecoration.Color = foreColor;
        }

        private void thumbSortButton_Click(object sender, EventArgs e)
        {
            if (booksCard)
            {
                loadBookCard(false);
            }
            else
            {
                loadUsersCard(false);
            }
            listSortButton.ShadowDecoration.Enabled = false;
            thumbSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Color = foreColor;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (booksCard)
            {
                loadBookCard(false);
            }
            else
            {
                loadUsersCard(false);
            }
            listSortButton.ShadowDecoration.Enabled = false;
            thumbSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Color = foreColor;
        }
    }
}
