using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class UserCard : Form
    {
        public bool admin = false;
        public bool moderator = false;
        public bool addLoss = false;
        public bool isBlocked = false;
        public int bookNumber = 0;
        public bool getReturn = false;
        public int bookId = 0;
        public int page = 0;
        public bool addReturn = false;
        public string[] getBooksId = { };
        public int Id = 0;
        public int medal = 0;
        public byte[] photoPath = { };
        public Panel usersPanel = new Panel();
        public DateTime takeDate = DateTime.Now;
        public string clock = "11:22:00";
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

        //USERS MOUSE CONTROLS

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);



        private const int MOUSEEVENTF_LEFTDOWN = 0x02;

        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public UsersPage userspage = new UsersPage();

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public UserCard()
        {
            InitializeComponent();
        }

        private void UserCard_Load(object sender, EventArgs e)
        {
            try
            {
                if (addReturn)
                {
                    pictureBox5.Visible = false;
                }
                if (!getReturn && !addLoss)
                {
                    MedalList medalList = new MedalList();
                    MemoryStream mem = new MemoryStream(photoPath);
                    profileBox.Image = Image.FromStream(mem);
                    profileBox.BackgroundImage = Image.FromStream(mem);
                    medalPicturebox.Image = Image.FromFile(medalList.Medals[medal]);
                }
                else
                {
                    getUsersInfo();
                }
                changeOpenpictureboxImage();
                loadInfo("", "", false);
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

        private void getUsersInfo()
        {
            try
            {
                hatırlatıcıEkleToolStripMenuItem.Enabled = false;
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = ("Select * From [Users]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Id == Convert.ToInt32(reader["Id"]))
                    {
                        MedalList medalList = new MedalList();
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["ProfilePicture"]);
                        photoPath = data;
                        MemoryStream mem = new MemoryStream(photoPath);
                        profileBox.Image = Image.FromStream(mem);
                        profileBox.BackgroundImage = Image.FromStream(mem);
                        fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        emailLabel.Text = reader["Email"].ToString();
                        scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                        medalPicturebox.Image = Image.FromFile(medalList.Medals[Convert.ToInt32(reader["Medal"])]);
                        if (Convert.ToInt32(reader["Blocked"]) == 1)
                        {
                            pictureBox5.Enabled = false;
                            karaListeyeEkleToolStripMenuItem.Text = "Kara Listeden Çıkar";
                            isBlocked = true;
                        }

                    }
                }
                sqlConnection.Close();
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
        private void changeOpenpictureboxImage()
        {
            if (addReturn||addLoss)
            {
                if (admin || moderator)
                {
                    pictureBox6.Image = Image.FromFile("images/plus_math_80px.png");

                }
                else
                {
                    pictureBox6.Image = Image.FromFile("images/lock_30px.png");

                }
            }
            else if (getReturn)
            {
                if (admin || moderator)
                {
                    pictureBox6.Image = Image.FromFile("images/return_book_80px.png");
                }
                else
                {
                    pictureBox6.Image = Image.FromFile("images/lock_30px.png");
                }
            }
        }
        private void loadInfo(string infoName, string dialogİnfoName,bool click)
        {
            try
            {
                int lossBooks = 0;
                int lateBooks = 0;
                int totalBlocked = 0;
                int totalBooks = 0;
                int totalReturn = 0;
                int totalPage = 0;
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = ("Select * From [Users]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Id == Convert.ToInt32(reader["Id"]))
                    {
                        if (!addReturn && !getReturn && click)
                        {
                            MaterialEffect effect = new MaterialEffect();
                            effect.Show();
                            UserInfoDialog info = new UserInfoDialog();
                            info.effect = effect;
                            info.fullNameLabel.Text = fullnameLabel.Text;
                            info.infoNameLabel.Text = dialogİnfoName;
                            info.infoDetailBox.Text = reader[infoName].ToString();
                            info.Id = Id;
                            info.admin = admin;
                            info.moderator = moderator;
                            info.updateParameter = infoName;
                            info.ShowDialog();
                        }
                        lossBooks = Convert.ToInt32(reader["LossBooks"]);
                        lateBooks = Convert.ToInt32(reader["LateBooks"]);
                        totalBlocked = Convert.ToInt32(reader["TotalBlocked"]);
                        totalBooks = Convert.ToInt32(reader["totalBook"]);
                        totalReturn = Convert.ToInt32(reader["totalReturn"]);
                        totalPage = Convert.ToInt32(reader["TotalPage"]);

                        reader.Close();
                        break;
                    }
                }
                sqlConnection.Close();
                string query = "";
                if (lossBooks > 0 && lossBooks < 5)
                {
                    query = "UPDATE Users SET Trust=@trust where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query,sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@trust", 10);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (lossBooks > 5)
                {
                    query = "UPDATE Users SET Trust=@trust where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@trust", 0);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (lossBooks == 0 && totalBlocked < 2 && lateBooks>0 && totalBooks > 3 && totalBooks < 10)
                {
                    query = "UPDATE Users SET Trust=@trust where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@trust", 20);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (lossBooks == 0 && totalBlocked == 0 && lateBooks < 3 && totalBooks>3&&totalBooks<20)
                {
                    query = "UPDATE Users SET Trust=@trust where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@trust", 35);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (lossBooks == 0 && totalBlocked == 0 && lateBooks==0 && totalBooks > 20)
                {
                    query = "UPDATE Users SET Trust=@trust where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@trust", 50);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                //score control system
                if (totalPage > 5000 && totalPage < 10000)
                {
                    query = "UPDATE Users SET Score=@score,Medal=@medal where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@score", 1.5f);
                        command2.Parameters.AddWithValue("@medal", 0);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (totalPage > 10000 && totalPage < 20000)
                {
                    query = "UPDATE Users SET Score=@score,Medal=@medal where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@score", 2.5f);
                        command2.Parameters.AddWithValue("@medal", 1);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (totalPage > 20000 && totalPage < 30000)
                {
                    query = "UPDATE Users SET Score=@score,Medal=@medal where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@score", 3.5f);
                        command2.Parameters.AddWithValue("@medal", 2);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                else if (totalPage > 30000)
                {
                    query = "UPDATE Users SET Score=@score,Medal=@medal where Id=@id";
                    using (SqlCommand command2 = new SqlCommand(query, sqlConnection))
                    {
                        command2.Parameters.Clear();
                        command2.Parameters.AddWithValue("@id", Id);
                        command2.Parameters.AddWithValue("@score", 5.0f);
                        command2.Parameters.AddWithValue("@medal", 3);
                        sqlConnection.Open();
                        command2.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
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
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MouseRightClick();
        }
        public void MouseRightClick()
        {

            int X = Cursor.Position.X;

            int Y = Cursor.Position.Y;

            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Convert.ToUInt32(X), Convert.ToUInt32(Y), 0, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            UserInfoDialog info = new UserInfoDialog();
            info.effect = effect;
            info.fullNameLabel.Text = fullnameLabel.Text;
            info.infoNameLabel.Text = "E-Posta Adresi";
            info.infoDetailBox.Text = emailLabel.Text;
            info.Id = Id;
            info.admin = admin;
            info.moderator = moderator;
            info.updateParameter = "Email";
            info.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            loadInfo("Phone", "Telefon Numarası",true);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            loadInfo("Address", "Ev Adresi",true);
        }

        private void kullanıcıyıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.Id = Id;
                warning.errorMode = false;
                warning.deleteUser = true;
                warning.ShowDialog();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Kullanıcıyı silmek için Admin olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!addReturn && !getReturn && !addLoss)
                {
                    loadProfile();
                }
                else if (getReturn)
                {
                    if (admin || moderator)
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = sqlConnection;
                            command.CommandText = "delete ReturnBooks where Id='" + bookId + "'";
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
                                if (Id == Convert.ToInt32(reader2["Id"]))
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
                            command.Parameters.AddWithValue("@id", Id);
                            command.Parameters.AddWithValue("@totalReturn", totalReturn + 1);
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                        pictureBox6.Visible = false;
                        loadingProgress.Visible = true;
                        loadingProgress.Start();
                        loadingTimer.Enabled = true;
                        loadingTimer.Start();
                        pictureBox6.Image = Image.FromFile("images/ok_30px.png");
                        pictureBox6.Enabled = false;
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
                else if (addLoss)
                {
                    if (admin || moderator)
                    {
                        string query = "UPDATE ReturnBooks SET loss=@loss where Id=@id";
                        using (SqlCommand command = new SqlCommand(query, sqlConnection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@id", bookId);
                            command.Parameters.AddWithValue("@loss", 1);
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                        int loss = 0;
                        using (SqlCommand command = new SqlCommand())
                        {
                            sqlConnection.Open();
                            command.Connection = sqlConnection;
                            command.CommandText = ("Select * From [Users]");
                            SqlDataReader reader2 = command.ExecuteReader();
                            while (reader2.Read())
                            {
                                if (Id == Convert.ToInt32(reader2["Id"]))
                                {
                                    loss = Convert.ToInt32(reader2["LossBooks"]);
                                }
                            }
                            reader2.Close();
                            sqlConnection.Close();
                        }
                        query = "UPDATE Users SET LossBooks=@loss where Id=@id";
                        using (SqlCommand command = new SqlCommand(query, sqlConnection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@id", Id);
                            command.Parameters.AddWithValue("@loss", loss + 1);
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                        pictureBox6.Visible = false;
                        loadingProgress.Visible = true;
                        loadingProgress.Start();
                        loadingTimer.Enabled = true;
                        loadingTimer.Start();
                        pictureBox6.Image = Image.FromFile("images/ok_30px.png");
                        pictureBox6.Enabled = false;
                    }
                    else
                    {
                        MaterialEffect effect = new MaterialEffect();
                        effect.Show();
                        WarningCard warning = new WarningCard();
                        warning.effect = effect;
                        warning.errorMode = true;
                        warning.fullNameLabel.Text = "Erişim Reddedildi";
                        warning.emailLabel.Text = "Kayıp kitap ekleyebilmek için Admin veya Moderator olmanız gerekmektedir";
                        warning.ShowDialog();
                    }
                }
                else
                {
                    if (admin || moderator)
                    {
                        int totalReturn = 0;
                        using (SqlCommand command = new SqlCommand())
                        {
                            sqlConnection.Open();
                            command.Connection = sqlConnection;
                            command.CommandText = ("Select * From [ReturnBooks]");
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (bookId == Convert.ToInt32(reader["BookId"]))
                                {
                                    totalReturn++;
                                }
                            }
                            reader.Close();
                            sqlConnection.Close();
                        }
                        int totalStock = bookNumber - totalReturn;

                        if (totalStock > 0)
                        {
                            int totalBook = 0;
                            int totalPage = 0;
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
                                        totalBook = Convert.ToInt32(reader["totalBook"]);
                                        totalPage = Convert.ToInt32(reader["TotalPage"]);
                                    }
                                }
                                reader.Close();
                                sqlConnection.Close();
                            }
                            pictureBox6.Visible = false;
                            loadingProgress.Visible = true;
                            loadingProgress.Start();
                            loadingTimer.Enabled = true;
                            loadingTimer.Start();
                            string query = "UPDATE Users SET totalBook = @book, TotalPage=@page where Id = @id";
                            using (SqlCommand command = new SqlCommand(query, sqlConnection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@id", Id);
                                command.Parameters.AddWithValue("@book", totalBook + 1);
                                command.Parameters.AddWithValue("@page", totalPage + page);
                                sqlConnection.Open();
                                command.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                            query = "INSERT INTO [ReturnBooks] (BookId,UserId,TakeDate,TakeClock,loss) Values (@bookid,@userid,@takedate,@takeclock,@loss)";
                            using (SqlCommand command = new SqlCommand(query, sqlConnection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@bookid", bookId);
                                command.Parameters.AddWithValue("@userid", Id);
                                command.Parameters.AddWithValue("@takedate", takeDate);
                                command.Parameters.AddWithValue("@takeclock", DateTime.Parse(clock));
                                command.Parameters.AddWithValue("@loss", 0);

                                sqlConnection.Open();
                                command.ExecuteNonQuery();
                                sqlConnection.Close();
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
                warning.errorMode = true;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void loadProfile()
        {
            try
            {
                usersPanel.Controls.Clear();
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = ("Select * From [Users]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Id == Convert.ToInt32(reader["Id"]))
                    {
                        MedalList medallist = new MedalList();
                        UserProfilePage users = new UserProfilePage();
                        users.TopLevel = false;
                        users.Dock = DockStyle.Fill;
                        users.isBlocked = isBlocked;
                        users.usersPanel = usersPanel;
                        users.page = userspage;
                        users.profileBox.Image = profileBox.Image;
                        users.profileBox.BackgroundImage = profileBox.Image;
                        users.fullnameLabel.Text = fullnameLabel.Text;
                        users.emailLabel.Text = emailLabel.Text;
                        users.scoreRatingStar.Value = scoreRatingStar.Value;
                        users.countryIdNoLabel.Text = reader["CountryIdNo"].ToString();
                        users.phoneLabel.Text = reader["Phone"].ToString();
                        users.addressLabel.Text = reader["Address"].ToString();
                        users.housePhoneLabel.Text = reader["HousePhone"].ToString();
                        users.totalPageNumberLabel.Text = reader["TotalPage"].ToString();
                        users.totalbookNumberLabel.Text = reader["totalBook"].ToString();
                        users.totalgiveNumberLabel.Text = reader["totalReturn"].ToString();
                        users.totallateNumberLabel.Text = reader["LateBooks"].ToString();
                        users.totalBlockNumberLabel.Text = reader["TotalBlocked"].ToString();
                        users.totalLossBooksLabel.Text = reader["LossBooks"].ToString();
                        users.medalPicturebox2.Image = Image.FromFile(medallist.Medals[medal]);
                        users.medalPicturebox.Image = Image.FromFile(medallist.Medals[medal]);
                        users.levelRatingStar.Value = scoreRatingStar.Value;
                        users.trustProggress.Value = Convert.ToInt32(reader["Trust"]);
                        users.schoolAdressLabel.Text = reader["School"].ToString();
                        users.sortingChange = false;
                        users.lightColor = lightColor;
                        usersPanel.Controls.Add(users);
                        guna2Transition1.Show(users);
                        //users.Show();
                    }
                }
                sqlConnection.Close();
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bu profil yüklenemiyor, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadingProgress.Stop();
            loadingProgress.Visible = false;
            pictureBox6.Visible = true;
            loadingProgress.Dispose();
            loadingTimer.Enabled = false;
            loadingTimer.Stop();
            loadingTimer.Dispose();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (admin||moderator)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                AddReturn add = new AddReturn();
                add.Effect = effect;
                add.UserId = Id;
                add.BookId = bookId;
                add.GetBooksId = getBooksId;
                add.OnUsersPage = true;
                add.powColor = powColor;
                add.lightColor = lightColor;
                add.foreColor = foreColor;
                add.BackColor = lightColor;
                add.admin = admin;
                add.moderator = moderator;
                add.ShowDialog();
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

        private void karaListeyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.Id = Id;
                warning.errorMode = false;
                warning.blockedMode = true;
                warning.isBlocked = isBlocked;
                warning.addReturn = pictureBox5;
                if (addReturn)
                {
                    warning.showAddReturn = pictureBox6;
                }
                warning.ShowDialog();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Kullanıcıyı kara listeye eklemek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void profilResmiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                openFileDialog1.Filter = ("Resim (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif");
                openFileDialog1.Title = "Resim Dosyası Seçin";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "openFileDialog1" && openFileDialog1.FileName != "")
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {
                        photoPath = ImageToStream(openFileDialog1.FileName);
                        MemoryStream stream = new MemoryStream(photoPath);
                        profileBox.Image = Image.FromStream(stream);
                        profileBox.BackgroundImage = Image.FromStream(stream);
                        string query = "UPDATE Users SET ProfilePicture=@picture where Id=@id";
                        using (SqlCommand command = new SqlCommand(query, sqlConnection))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@id", Id);
                            command.Parameters.AddWithValue("@picture", photoPath);
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                    }
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
                warning.emailLabel.Text = "Profil resmini değiştirmek için Admin veya Moderator olmanız gerekmektedir";
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

        private void isimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInfo("Name", "İsim", true);
        }

        private void soyisimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInfo("Surname", "Soyisim", true);
        }

        private void okulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInfo("School", "Okul", true);
        }

        private void tcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInfo("CountryIdNo", "Tc Kimlik Numarası", true);
        }

        private void konuştuguDilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInfo("Language", "Konuştugu Dil", true);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadInfo("HousePhone", "Ev Telefonu", true);
        }

        private void telefonNumarasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddUser add = new AddUser();
                add.EditMode = true;
                add.PictureByte = photoPath;
                add.Id = Id;
                add.BackColor = lightColor;
                add.nameTextbox.FillColor = lightColor;
                add.surnameBox.FillColor = lightColor;
                add.countryIdBox.FillColor = lightColor;
                add.schoolBox.FillColor = lightColor;
                add.phoneNumberbox.FillColor = lightColor;
                add.housePhoneBox.FillColor = lightColor;
                add.addressBox.FillColor = lightColor;
                add.languageBox.FillColor = lightColor;
                add.emailBox.FillColor = lightColor;
                add.Show();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Bilgileri düzenlemek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void hatırlatıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                GetReturnDialog returnDialog = new GetReturnDialog();
                returnDialog.onUsers = true;
                returnDialog.effect = effect;
                returnDialog.Id = Id;
                returnDialog.booksCard = true;
                returnDialog.powColor = powColor;
                returnDialog.lightColor = lightColor;
                returnDialog.foreColor = foreColor;
                returnDialog.pageViewerPanel.BackColor = lightColor;
                returnDialog.BackColor = lightColor;
                returnDialog.admin = admin;
                returnDialog.moderator = moderator;
                returnDialog.ShowDialog();
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
    }
}
