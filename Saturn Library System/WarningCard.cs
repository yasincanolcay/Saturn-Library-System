using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class WarningCard : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public PictureBox addReturn = new PictureBox();
        public PictureBox showAddReturn = new PictureBox();
        public MaterialEffect effect = new MaterialEffect();
        public int Id = 0;
        public bool errorMode = false;
        public bool blockedMode = false;
        public bool isBlocked = false;
        public bool deleteUser = false;
        public bool deleteBook = false;
        public bool deleteReminder = false;
        public bool deleteWriter = false;
        public bool deleteHouse = false;
        public bool Info = false;
        public bool logOut = false;
        public LoginPage page = new LoginPage();
        public Form1 form = new Form1();
        List<int> returnBooksId = new List<int>();
        public WarningCard()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            cancel();
        }
        private void cancel()
        {
            effect.Close();
            this.Close();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (errorMode)
            {
                cancel();
            }
            else if (blockedMode)
            {
                string query = "UPDATE Users SET Blocked=@blocked,BlockedRank=@rank,TotalBlocked=@total where Id=@id";
                if (!isBlocked)
                {
                    int totalBlocked = 0;
                    using (SqlCommand command = new SqlCommand())
                    {
                        sqlConnection.Open();
                        command.Connection = sqlConnection;
                        command.CommandText = "SELECT * From [Users]";
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (Id == Convert.ToInt32(reader["Id"]))
                            {
                                totalBlocked = Convert.ToInt32(reader["TotalBlocked"]);
                            }
                        }
                        reader.Close();
                        sqlConnection.Close();
                    }
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@blocked", 1);
                        command.Parameters.AddWithValue("@rank", 5);
                        command.Parameters.AddWithValue("@total", totalBlocked+1);
                        command.Parameters.AddWithValue("@id", Id);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                        addReturn.Enabled = false;
                        showAddReturn.Enabled = false;
                    }
                }
                else
                {
                    query = "UPDATE Users SET Blocked=@blocked,BlockedRank=@rank where Id=@id";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@blocked", 0);
                        command.Parameters.AddWithValue("@rank", 0);
                        command.Parameters.AddWithValue("@id", Id);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
            }
            else if(deleteUser)
            {
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete Users where Id='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    for (int index = 0; index < returnBooksId.Count; index++)
                    {
                        command.Connection = sqlConnection;
                        command.CommandText = "delete ReturnBooks where Id='" + returnBooksId[index] + "'";
                        command.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            else if (deleteBook)
            {
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete Books where Id='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete ReturnBooks where BookId='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else if (deleteReminder)
            {
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete Reminders where Id='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else if (deleteWriter)
            {
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete Writer where Id='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else if (deleteHouse)
            {
                guna2TileButton1.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    command.CommandText = "delete PublishHouse where Id='" + Id + "'";
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else if (logOut)
            {
                form.nocloseForm = true;
                page.Show();
                form.Close();
                cancel();
            }
        }

        private void WarningCard_Load(object sender, EventArgs e)
        {
            if (errorMode)
            {
                guna2TileButton1.Text = "Tamam";
                guna2TileButton2.Text = "Geri";
            }
            else if (blockedMode)
            {
                if (!isBlocked)
                {
                    fullNameLabel.Text = "Engelleme İşlemi";
                    emailLabel.Text = "Bu kullanıcı engellenecek, engellenen kullanıcılara emanet verilemez.";
                    guna2TileButton1.Text = "Engelle";
                    guna2TileButton2.Text = "iptal";
                }
                else
                {
                    fullNameLabel.Text = "Engellemeyi Kaldırın";
                    emailLabel.Text = "Bu kullanıcı kara listeden çıkarılacak, lütfen güveniyorsanız devam edin!";
                    guna2TileButton1.Text = "Kaldır";
                    guna2TileButton2.Text = "iptal";
                    guna2TileButton2.Focus();
                }
            }
            else if(deleteUser)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    sqlConnection.Open();
                    command.Connection = sqlConnection;
                    command.CommandText = ("Select * From [ReturnBooks]");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Id == Convert.ToInt32(reader["UserId"]))
                        {
                            returnBooksId.Add(Convert.ToInt32(reader["Id"]));
                        }
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            else if (deleteBook)
            {
                fullNameLabel.Text = "Kitabı Sil";
                emailLabel.Text = "Bu kitap ve emanet bilgileri kalıcı olarak silinecek, emanetlerinizi kontrol ettiğinizden emin olun!";
                guna2TileButton1.Text = "Sil";
                guna2TileButton2.Text = "iptal";
                guna2TileButton2.Focus();
            }
            else if (logOut)
            {
                guna2TileButton1.Text = "Çıkış";
            }
            guna2TileButton2.Focus();
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            loadingProgress.Dispose();
            guna2TileButton1.Visible = true;
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            loadingTimer.Dispose();
            cancel();
        }
    }
}
