using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class Form1 : Form
    {
        //USERS MOUSE CONTROLS
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);



        private const int MOUSEEVENTF_LEFTDOWN = 0x02;

        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private const int MOUSEEVENTF_RIGHTUP = 0x10;



        public LoginPage page = new LoginPage();
        //home page
        HomePage home = new HomePage();
        //sql database connection source
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        //Pages control for menu buttons
        bool booksPageOpen = false;
        bool homePageOpen = false;
        bool usersPageOpen = false;
        bool returnPageOpen = false;
        bool blockedPageOpen = false;
        bool reminderPageOpen = false;
        bool settingsPageOpen = false;
        bool admin = false;
        bool moderator = false;
        bool isLoading = true;
        private int id = 0;
        private string username = "";
        //notification sound
        SoundPlayer sound = new SoundPlayer(@"sounds\notification.wav");
        //data for homepage
        int totalReturn = 0;
        int todayGetİt = 0;
        int late = 0;
        int blocked = 0;
        //data for homepage
        List<DateTime> returnTimes = new List<DateTime>();
        List<string> returnClock = new List<string>();
        List<int> userId = new List<int>();
        List<int> blockedId = new List<int>();
        List<int> blockedRankId = new List<int>();
        List<int> lossBooksId = new List<int>();
        List<int> todayTakeBooksId = new List<int>();
        List<int> lateBooksId = new List<int>();
        List<string> totalReturnBooks = new List<string>();
        //colors for dark mode
        Color powColor = Color.FromArgb(239, 181, 71);
        Color lightColor = Color.FromArgb(243,198,114);
        Color foreColor = Color.SaddleBrown;
        Color actionColor = Color.Chocolate;
        //For Settings
        bool autoNightMode = false;
        bool autoBlocked = true;
        bool notificationSound = true;
        bool notificationShow = true;
        bool saveLog = false;
        bool sendTelegram = false;
        string telegramToken = "";
        string telegramId = "";
        bool isSendToday = false;
        public bool nocloseForm = false;
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public bool BooksPageOpen { get => booksPageOpen; set => booksPageOpen = value; }
        public bool HomePageOpen { get => homePageOpen; set => homePageOpen = value; }
        public bool UsersPageOpen { get => usersPageOpen; set => usersPageOpen = value; }
        public bool Admin { get => admin; set => admin = value; }
        public bool Moderator { get => moderator; set => moderator = value; }
        public int Id { get => id; set => id = value; }

        public Form1()
        {
            InitializeComponent();
        }
        //First take it setings data
        private void readSettingsData()
        {
            using(SqlCommand command = new SqlCommand("SELECT * From [Settings]",sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (Convert.ToInt32(reader["AutoStartNightmode"]) == 1)
                    {
                        guna2ToggleSwitch1.Checked = true;
                    }
                    if (Convert.ToInt32(reader["AutoNightmode"]) == 1)
                    {
                        autoNightMode = true;
                    }
                    if (Convert.ToInt32(reader["AutoBlocked"]) == 0)
                    {
                        autoBlocked = false;
                    }
                    if (Convert.ToInt32(reader["NotificationSound"]) == 0)
                    {
                        notificationSound = false;
                    }
                    if (Convert.ToInt32(reader["NotificationShow"]) == 0)
                    {
                        notificationShow = false;
                    }
                    if (Convert.ToInt32(reader["SaveLog"]) == 1)
                    {
                        saveLog = true;
                    }
                    if (Convert.ToInt32(reader["SendTelegram"]) == 1)
                    {
                        sendTelegram = true;
                    }
                    telegramToken = reader["TelegramToken"].ToString();
                    telegramId = reader["TelegramId"].ToString();
                }
                reader.Close();
                sqlConnection.Close();
            }
        }
        //Notifications send to your telegram account
        //Bildirimleri telegram hesabınıza gönderir
        private string sendNotificationToTelegram(string message)
        {
            string urlString = $"https://api.telegram.org/bot{telegramToken}/sendMessage?chat_id={telegramId}&text={message}";
            WebClient webclient = new WebClient();
            return webclient.DownloadString(urlString);
        }
        //Shows all notifications and alert
        //uyarıları ve bildirimleri gösterir
        private void showWarning(string fullname, string details)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            WarningCard warning = new WarningCard();
            warning.effect = effect;
            warning.fullNameLabel.Text = fullname;
            warning.emailLabel.Text = details;
            warning.errorMode = true;
            warning.ShowDialog();
        }
        //Takes login acces info
        private void loadLoginInfo()
        {
            string access = "";
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT * From [LoginUsers]";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Id == Convert.ToInt32(reader["Id"]))
                {
                    access = reader["Access"].ToString();
                    username = reader["UserName"].ToString();
                    usernameLabel.Text = reader["UserName"].ToString();
                    userDeniedLabel.Text = reader["Access"].ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["Photo"]);
                    MemoryStream stream = new MemoryStream(data);
                    guna2CirclePictureBox1.Image = Image.FromStream(stream);

                    if (reader["Access"].ToString() == "Admin")
                    {
                        Admin = true;
                    }
                    else if (reader["Access"].ToString()=="Moderatör")
                    {
                        moderator = true;
                    }
                    else
                    {
                        guna2TileButton1.Enabled = false;
                        guna2TileButton2.Enabled = false;
                        guna2TileButton1.Text = "Yetki Yok";
                        guna2TileButton2.Text = "Yetki Yok";
                    }

                }

            }
            reader.Close();
            sqlConnection.Close();
            loadHomePage();
            notificationsTimer.Enabled = true;
            notificationsTimer.Start();
            if (sendTelegram)
            {
                try
                {
                    sendNotificationToTelegram("Saturn Library System\nYeni bir giriş algılandı.\n" + "Kullanıcı Adı: " + username + "\nYetki: " + access + "\n" + DateTime.Now.ToString());
                }
                catch
                {
                }
            }
        }
        private void loadHomePage()
        {
            pageViewerPanel.Controls.Clear();
            home.TopLevel = false;
            home.Dock = DockStyle.Fill;
            home.HomePanel = pageViewerPanel;
            home.Admin = Admin;
            home.Moderator = moderator;
            pageViewerPanel.Controls.Add(home);
            home.Show();
            homeButton.BackColor = lightColor;
            kitaplarButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = powColor;
        }
        private void loadReminders()
        {
            int reminders = 0;
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [Reminders]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (DateTime.Parse(reader["Date"].ToString()).Day == DateTime.Now.Day && DateTime.Parse(reader["Date"].ToString()).Month == DateTime.Now.Month && DateTime.Parse(reader["Date"].ToString()).Year == DateTime.Now.Year)
                    {
                        if (DateTime.Parse(reader["Time"].ToString()).Hour <= DateTime.Now.Hour && DateTime.Parse(reader["Time"].ToString()).Minute <= DateTime.Now.Minute)
                        {
                            if (Convert.ToInt32(reader["isRead"]) == 0)
                            {
                                reminders++;

                                if (!isLoading)
                                {
                                    if (notificationSound)
                                    {
                                        sound.Play();
                                    }
                                    MaterialEffect effect = new MaterialEffect();
                                    effect.Show();
                                    AlertReminder alert = new AlertReminder();
                                    alert.Id = Convert.ToInt32(reader["Id"]);
                                    alert.effect = effect;
                                    ReminderCard card = new ReminderCard();
                                    card.TopLevel = false;
                                    card.headerLabel.Text = reader["Header"].ToString();
                                    card.noteLabel.Text = reader["Header"].ToString();
                                    card.dateChip.Text = DateTime.Parse(reader["Date"].ToString()).Month.ToString()+"/"+ DateTime.Parse(reader["Date"].ToString()).Day.ToString()+"/"+ DateTime.Parse(reader["Date"].ToString()).Year.ToString();
                                    card.timeChip.Text = reader["Time"].ToString();
                                    alert.BackColor = powColor;
                                    card.powColor = powColor;
                                    card.lightColor = lightColor;
                                    card.foreColor = foreColor;
                                    card.guna2Panel1.FillColor = lightColor;
                                    card.BackColor = lightColor;
                                    card.Id = Convert.ToInt32(reader["Id"]);
                                    alert.viewerPanel.Controls.Add(card);
                                    card.Show();
                                    alert.ShowDialog();
                                }
                                else
                                {
                                    if (notificationSound)
                                    {
                                        sound.Play();
                                    }
                                }
                                if (sendTelegram)
                                {
                                    try
                                    {
                                        sendNotificationToTelegram("Saturn Library System\nBir Hatırlatmanız Var\n"+reader["Header"].ToString()+"\n"+reader["Note"].ToString()+"\n"+reader["Date"].ToString()+" "+reader["Time"].ToString());
                                    }
                                    catch
                                    {
                                        showWarning("HATA","Bildirimler telegrama gönderilemedi, bağlantınızı kontrol edin.");
                                    }
                                }
                            }
                        }
                    }
                }
                reader.Close();
                sqlConnection.Close();
                home.reminderLabel.Text = reminders.ToString();
            }
            catch
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
        }
        private void loadReturnBooks()
        {
            int loss = 0;
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [ReturnBooks]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalReturn++;
                    totalReturnBooks.Add(reader["BookId"].ToString());
                    if (DateTime.Parse(reader["TakeDate"].ToString()).Day == DateTime.Now.Day && DateTime.Parse(reader["TakeDate"].ToString()).Month == DateTime.Now.Month && DateTime.Parse(reader["TakeDate"].ToString()).Year == DateTime.Now.Year)
                    {
                        todayGetİt++;
                        if (notificationSound)
                        {
                            sound.Play();
                        }
                        todayTakeBooksId.Add(Convert.ToInt32(reader["BookId"]));
                        if (sendTelegram && !isSendToday)
                        {
                            try
                            {
                                sendNotificationToTelegram("Saturn Library System\n"+"Bugün alınacak kitaplar var.\n"+DateTime.Now.ToString());
                            }
                            catch
                            {
                                showWarning("HATA", "Bildirimler telegrama gönderilemedi, bağlantınızı kontrol edin.");
                            }
                            isSendToday = true;
                        }
                    }
                    if (DateTime.Parse(reader["TakeDate"].ToString()).Day < DateTime.Now.Day || DateTime.Parse(reader["TakeDate"].ToString()).Month < DateTime.Now.Month || DateTime.Parse(reader["TakeDate"].ToString()).Year < DateTime.Now.Year)
                    {
                        late++;
                        lateBooksId.Add(Convert.ToInt32(reader["BookId"]));
                        if (!lateWarning&&!isLoading)
                        {
                            if (notificationSound)
                            {
                                sound.Play();
                            }
                            if (notificationShow)
                            {
                                showWarning("Geciken Kitaplar", "Bir kitabın teslim tarihi geçiyor.");
                            }
                            lateWarning = true;
                            if (sendTelegram)
                            {
                                try
                                {
                                    sendNotificationToTelegram("Saturn Library System\nBir kitabın teslim tarihi geçiyor"+DateTime.Now.ToString());
                                }
                                catch
                                {
                                    showWarning("HATA", "Bildirimler telegrama gönderilemedi, bağlantınızı kontrol edin.");
                                }
                            }
                        }
                        else
                        {
                            if (notificationSound)
                            {
                                sound.Play();
                            }
                        }
                    }
                    if (Convert.ToInt32(reader["loss"]) == 1)
                    {
                        isSendToday = false;
                        loss++;
                        lossBooksId.Add(Convert.ToInt32(reader["BookId"]));
                        if (sendTelegram)
                        {
                            try
                            {
                                sendNotificationToTelegram("Saturn Library System\nKayıp kitaplar var\n"+DateTime.Now.ToString());
                            }
                            catch
                            {
                                showWarning("HATA", "Bildirimler telegrama gönderilemedi, bağlantınızı kontrol edin.");
                            }
                        }
                    }

                    returnTimes.Add(DateTime.Parse(reader["TakeDate"].ToString()));
                    returnClock.Add(reader["TakeClock"].ToString());
                    userId.Add(Convert.ToInt32(reader["UserId"]));
                }
                home.totalReturnBooksLabel.Text = totalReturn.ToString();
                home.todayLabel.Text = todayGetİt.ToString();
                home.lateBooksLabel.Text = late.ToString();
                home.lossLabel.Text = loss.ToString();
                home.lossBooksId = lossBooksId;
                home.todayTakeBooksId = todayTakeBooksId;
                home.lateBooksId = lateBooksId;
                reader.Close();
                SqlConnection.Close();
                late = 0;
                todayGetİt = 0;
                totalReturn = 0;
                loadReminders();
            }
            catch
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
        }
        bool lateWarning = false;
        private void NotificationsControl()
        {
            late = 0;
            blocked = 0;
            for (int i = 0; i < returnTimes.Count; i++)
            {
                if (returnTimes[i].Month < DateTime.Now.Month || returnTimes[i].Year < DateTime.Now.Year || (returnTimes[i].Day < DateTime.Now.Day || DateTime.Parse(returnClock[i]).Hour < DateTime.Now.Hour))
                {
                    string query = "SELECT * From [Users]";
                    int blockedRank = 0;
                    int totalBlocked = 0;
                    int totalLate = 0;
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (userId[i] == Convert.ToInt32(reader["Id"]))
                            {
                                if (Convert.ToInt32(reader["Blocked"]) == 1)
                                {
                                    blockedId.Add(Convert.ToInt32(reader["Id"]));
                                }
                                totalLate = Convert.ToInt32(reader["LateBooks"]);
                                blockedRank = Convert.ToInt32(reader["BlockedRank"]);
                                totalBlocked = Convert.ToInt32(reader["TotalBlocked"]);
                            }
                        }
                        reader.Close();
                        sqlConnection.Close();
                    }
                    if (blockedRank < 5)
                    {
                        if (!blockedRankId.Contains(userId[i]))
                        {
                            query = "UPDATE Users SET BlockedRank=@blockedRank,LateBooks=@late where Id=@id";
                            using (SqlCommand command = new SqlCommand(query, sqlConnection))
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@id", userId[i]);
                                command.Parameters.AddWithValue("@blockedRank", blockedRank + 1);
                                command.Parameters.AddWithValue("@late", totalLate + 1);
                                sqlConnection.Open();
                                command.ExecuteNonQuery();
                                sqlConnection.Close();
                            }
                            blockedRankId.Add(userId[i]);
                        }
                    }
                    else
                    {
                        if (!blockedId.Contains(userId[i]))
                        {
                            if (autoBlocked)
                            {
                                blocked++;
                                query = "UPDATE Users SET Blocked=@blocked,TotalBlocked=@totalblocked where Id=@id";
                                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                                {
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@id", userId[i]);
                                    command.Parameters.AddWithValue("@blocked", 1);
                                    command.Parameters.AddWithValue("@totalblocked", totalBlocked + 1);
                                    sqlConnection.Open();
                                    command.ExecuteNonQuery();
                                    sqlConnection.Close();
                                }
                                if (notificationSound)
                                {
                                    sound.Play();
                                }
                                if (notificationShow)
                                {
                                    showWarning("Engellenen Kullanıcı", "Bir kullanıcı kara listeye eklendi");
                                }
                                home.label15.Text = blocked.ToString();
                                blockedId.Add(userId[i]);
                                if (sendTelegram)
                                {
                                    try
                                    {
                                        sendNotificationToTelegram("Saturn Library System\nBir kullanını kara listeye eklendi\n"+DateTime.Now.ToString());
                                    }
                                    catch
                                    {
                                        showWarning("HATA", "Bildirimler telegrama gönderilemedi, bağlantınızı kontrol edin.");
                                    }
                                }
                            }
                        }
                    }
                   
                }
            }
            lossBooksId.Clear();
            todayTakeBooksId.Clear();
            lateBooksId.Clear();
            returnTimes.Clear();
            returnClock.Clear();
            userId.Clear();
            loadReturnBooks();
        }
        private void loadBooksPage()
        {
            pageViewerPanel.Controls.Clear();
            BooksPage books = new BooksPage();
            books.TopLevel = false;
            books.Dock = DockStyle.Fill;
            books.powColor = powColor;
            books.lightColor = lightColor;
            books.foreColor = foreColor;
            books.panel1.BackColor = lightColor;
            books.flowLayoutPanel1.BackColor = lightColor;
            books.BackColor = lightColor;
            books.Admin = admin;
            books.Moderator = moderator;
            books.ManagerId = Id;
            books.ManagerUsername = username;
            pageViewerPanel.Controls.Add(books);
            books.Show();
            kitaplarButton.BackColor = lightColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = powColor;
        }
        private void loadUsersPage()
        {
            pageViewerPanel.Controls.Clear();
            UsersPage users = new UsersPage();
            users.TopLevel = false;
            users.Dock = DockStyle.Fill;
            users.usersPanel = pageViewerPanel;
            users.powColor = powColor;
            users.lightColor = lightColor;
            users.foreColor = foreColor;
            users.panel1.BackColor = lightColor;
            users.flowLayoutPanel1.BackColor = lightColor;
            users.BackColor = lightColor;
            users.admin = admin;
            users.moderator = moderator;
            pageViewerPanel.Controls.Add(users);
            users.Show();
            kitaplarButton.BackColor = powColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = lightColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = powColor;
        }
        private void loadReturnPage()
        {
            pageViewerPanel.Controls.Clear();

            ReturnPage page = new ReturnPage();
            page.TopLevel = false;
            page.Dock = DockStyle.Fill;
            page.onUsers = false;
            page.booksCard = true;
            page.powColor = powColor;
            page.lightColor = lightColor;
            page.foreColor = foreColor;
            page.panel1.BackColor = lightColor;
            page.flowLayoutPanel1.BackColor = lightColor;
            page.BackColor = lightColor;
            page.admin = admin;
            page.moderator = moderator;
            pageViewerPanel.Controls.Add(page);
            page.Show();
            kitaplarButton.BackColor = powColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = lightColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = powColor;
        }
        private void loadBlockedListPage()
        {
            pageViewerPanel.Controls.Clear();
            UsersPage users = new UsersPage();
            users.TopLevel = false;
            users.Dock = DockStyle.Fill;
            users.blockedNumber = 0;
            users.usersPanel = pageViewerPanel;
            users.powColor = powColor;
            users.lightColor = lightColor;
            users.foreColor = foreColor;
            users.panel1.BackColor = lightColor;
            users.flowLayoutPanel1.BackColor = lightColor;
            users.BackColor = lightColor;
            users.admin = admin;
            users.moderator = moderator;
            pageViewerPanel.Controls.Add(users);
            users.Show();
            kitaplarButton.BackColor = powColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = lightColor;
            settingsButton.BackColor = powColor;
        }
        private void loadReminderPage()
        {
            pageViewerPanel.Controls.Clear();
            ReminderPage reminder = new ReminderPage();
            reminder.TopLevel = false;
            reminder.Dock = DockStyle.Fill;
            reminder.powColor = powColor;
            reminder.lightColor = lightColor;
            reminder.foreColor = foreColor;
            reminder.panel1.BackColor = lightColor;
            reminder.flowLayoutPanel1.BackColor = lightColor;
            reminder.BackColor = lightColor;
            reminder.admin = admin;
            reminder.moderator = moderator;
            pageViewerPanel.Controls.Add(reminder);
            reminder.Show();

            kitaplarButton.BackColor = powColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = lightColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = powColor;
        }
        private void loadSettingsPage()
        {
            pageViewerPanel.Controls.Clear();
            SettingsPage settings = new SettingsPage();
            settings.TopLevel = false;
            settings.Dock = DockStyle.Fill;
            settings.settingsPanel.BackColor = lightColor;
            settings.BackColor = lightColor;
            settings.tokenTextbox.FillColor = lightColor;
            settings.idTextbox.FillColor = lightColor;
            settings.admin = admin;
            settings.moderator = moderator;
            settings.Id = Id;
            pageViewerPanel.Controls.Add(settings);
            settings.Show();
            kitaplarButton.BackColor = powColor;
            homeButton.BackColor = powColor;
            usersButton.BackColor = powColor;
            CalendarButton.BackColor = powColor;
            returnButton.BackColor = powColor;
            blackListButton.BackColor = powColor;
            settingsButton.BackColor = lightColor;
        }
        private void addBook()
        {
            AddBook addbook = new AddBook();
            addbook.BackColor = lightColor;
            addbook.nameTextbox.FillColor = lightColor;
            addbook.isbnTextbox.FillColor = lightColor;
            addbook.writerTextbox.FillColor = lightColor;
            addbook.publishHomeTextbox.FillColor = lightColor;
            addbook.genusTextbox.FillColor = lightColor;
            addbook.detailsTextbox.FillColor = lightColor;
            addbook.printedNumber.FillColor = lightColor;
            addbook.printedNumber.ForeColor = foreColor;
            addbook.guna2DateTimePicker1.FillColor = lightColor;
            addbook.guna2DateTimePicker1.BackColor = lightColor;
            addbook.guna2DateTimePicker1.ForeColor = foreColor;
            addbook.tagTextbox.FillColor = lightColor;
            addbook.pageNumberBox.FillColor = lightColor;
            addbook.pageNumberBox.ForeColor = foreColor;
            addbook.stockNumberBox.FillColor = lightColor;
            addbook.stockNumberBox.ForeColor = foreColor;
            addbook.shelfTextbox.FillColor = lightColor;
            addbook.shelfLineTextbox.FillColor = lightColor;
            addbook.tableLayoutPanel1.BackColor = lightColor;
            addbook.certificateTextbox.FillColor = lightColor;
            addbook.teamTextbox.FillColor = lightColor;
            addbook.languageTextbox.FillColor = lightColor;
            addbook.translaterTextbox.FillColor = lightColor;
            addbook.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            isLoading = true;
            readSettingsData();
            loadLoginInfo();
            loadReturnBooks();
            HomePageOpen = true;
            controlTimer.Enabled = true;
            controlTimer.Start();
            panel3.BackColor = powColor;
            panel1.BackColor = powColor;
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            if (!HomePageOpen)
            {
                loadHomePage();
                BooksPageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = false;
                HomePageOpen = true;
                blockedPageOpen = false;
                reminderPageOpen = false;
                settingsPageOpen = false;
            }
        }

        private void kitaplarButton_Click(object sender, EventArgs e)
        {
            if (!BooksPageOpen)
            {
                loadBooksPage();
                BooksPageOpen = true;
                HomePageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = false;
                blockedPageOpen = false;
                reminderPageOpen = false;
                settingsPageOpen = false;
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                addBook();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Kitap eklemek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void controlTimer_Tick(object sender, EventArgs e)
        {
            datetimeLabel.Text = Convert.ToString(DateTime.Now);
            if (autoNightMode)
            {
                if(DateTime.Now.Hour > 18 || DateTime.Now.Hour < 6)
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        guna2ToggleSwitch1.Checked = true;
                    }
                }
                else
                {
                    if (guna2ToggleSwitch1.Checked)
                    {
                        guna2ToggleSwitch1.Checked = false;
                    }
                }
            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                ActionsCard actions = new ActionsCard();
                actions.powColor = powColor;
                actions.lightColor = lightColor;
                actions.foreColor = foreColor;
                actions.Effect = effect;
                actions.BackColor = actionColor;
                actions.guna2TileButton1.FillColor = lightColor;
                actions.guna2TileButton2.FillColor = lightColor;
                actions.guna2TileButton3.FillColor = lightColor;
                actions.guna2TileButton4.FillColor = lightColor;
                actions.admin = admin;
                actions.moderator = moderator;
                actions.ShowDialog();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "İşlemlere erişmek için Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            if (!UsersPageOpen)
            {
                BooksPageOpen = false;
                HomePageOpen = false;
                UsersPageOpen = true;
                returnPageOpen = false;
                blockedPageOpen = false;
                reminderPageOpen = false;
                settingsPageOpen = false;
                loadUsersPage();
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            if (!returnPageOpen)
            {
                loadReturnPage();
                BooksPageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = true;
                HomePageOpen = false;
                blockedPageOpen = false;
                reminderPageOpen = false;
                settingsPageOpen = false;
            }
        }

        private void notificationsTimer_Tick(object sender, EventArgs e)
        {
            if (isLoading == true)
            {
                isLoading = false;
            }
            NotificationsControl();
        }

        private void blackListButton_Click(object sender, EventArgs e)
        {
            if (!blockedPageOpen)
            {
                loadBlockedListPage();
                BooksPageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = false;
                HomePageOpen = false;
                blockedPageOpen = true;
                reminderPageOpen = false;
                settingsPageOpen = false;
            }
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            if (!reminderPageOpen)
            {
                loadReminderPage();
                BooksPageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = false;
                HomePageOpen = false;
                blockedPageOpen = false;
                settingsPageOpen = false;
                reminderPageOpen = true;
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                powColor = Color.FromArgb(30, 30, 30);
                lightColor = Color.FromArgb(60, 60, 60);
                foreColor = Color.Silver;
                actionColor = Color.FromArgb(30, 30, 30);
            }
            else
            {
                powColor = Color.FromArgb(239, 181, 71);
                lightColor = Color.FromArgb(243,198,114);
                foreColor = Color.SaddleBrown;
                actionColor = Color.Chocolate;

            }
            panel3.BackColor = powColor;
            panel1.BackColor = powColor;
            topPanel.BackColor = lightColor;
            guna2TileButton1.FillColor = powColor;
            guna2TileButton2.FillColor = powColor;
            guna2TileButton1.ShadowDecoration.Color = foreColor;
            guna2TileButton2.ShadowDecoration.Color = foreColor;
            guna2ShadowPanel1.ShadowColor = foreColor;
            guna2ShadowPanel1.FillColor = lightColor;
            guna2ShadowPanel1.BackColor = lightColor;
            userDeniedLabel.ForeColor = foreColor;
            if (homePageOpen)
            {
                homeButton.BackColor = lightColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = powColor;

            }
            else if (booksPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = lightColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = powColor;
                booksPageOpen = false;
                kitaplarButton.PerformClick();
            }
            else if (usersPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = lightColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = powColor;
                usersPageOpen = false;
                usersButton.PerformClick();
            }
            else if (reminderPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = lightColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = powColor;
                reminderPageOpen = false;
                CalendarButton.PerformClick();
            }
            else if (returnPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = lightColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = powColor;
                returnPageOpen = false;
                returnButton.PerformClick();
            }
            else if (blockedPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = lightColor;
                settingsButton.BackColor = powColor;
                blockedPageOpen = false;
                blackListButton.PerformClick();
            }
            else if (settingsPageOpen)
            {
                homeButton.BackColor = powColor;
                kitaplarButton.BackColor = powColor;
                usersButton.BackColor = powColor;
                CalendarButton.BackColor = powColor;
                returnButton.BackColor = powColor;
                blackListButton.BackColor = powColor;
                settingsButton.BackColor = lightColor;
                settingsPageOpen = false;
                settingsButton.PerformClick();
            }
            this.BackColor = lightColor;
            pageViewerPanel.BackColor = lightColor;
            formPanel.BackColor = lightColor;

            home.guna2ShadowPanel1.FillColor = powColor;
            home.guna2ShadowPanel2.FillColor = powColor;
            home.guna2ShadowPanel3.FillColor = powColor;
            home.guna2ShadowPanel4.FillColor = powColor;
            home.guna2ShadowPanel5.FillColor = powColor;
            home.guna2ShadowPanel6.FillColor = powColor;
            home.guna2ShadowPanel7.FillColor = powColor;
            home.guna2ShadowPanel8.FillColor = powColor;
            home.guna2ShadowPanel9.FillColor = powColor;
            home.guna2ShadowPanel10.FillColor = powColor;
            home.guna2ShadowPanel11.FillColor = powColor;
            home.guna2ShadowPanel12.FillColor = powColor;
            home.flowLayoutPanel1.BackColor = lightColor;
            home.label11.ForeColor = foreColor;
            home.label12.ForeColor = foreColor;
            home.label14.ForeColor = foreColor;
            home.BackColor = lightColor;
            home.powColor = powColor;
            home.lightColor = lightColor;
            home.foreColor = foreColor;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (!settingsPageOpen)
            {
                loadSettingsPage();
                BooksPageOpen = false;
                UsersPageOpen = false;
                returnPageOpen = false;
                HomePageOpen = false;
                blockedPageOpen = false;
                reminderPageOpen = false;
                settingsPageOpen = true;
            }
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            WarningCard warning = new WarningCard();
            warning.effect = effect;
            warning.logOut = true;
            warning.page = page;
            warning.form = this;
            warning.fullNameLabel.Text = "Çıkış Yap";
            warning.emailLabel.Text = "Hesabınızdan çıkış yapılacak!";
            warning.ShowDialog();
        }
        public void MouseRightClick()
        {
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Convert.ToUInt32(X), Convert.ToUInt32(Y), 0, 0);
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            MouseRightClick();
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            MouseRightClick();
        }

        private void userDeniedLabel_Click(object sender, EventArgs e)
        {
            MouseRightClick();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!nocloseForm)
            {
                page.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devonesoft.42web.io/index.html");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devonesoft.42web.io/index.html");
        }
    }
}
