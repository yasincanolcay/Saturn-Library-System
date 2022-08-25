using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class HomePage : Form
    {
        SoundPlayer sound = new SoundPlayer(@"sounds\notification.wav");
        int totalReturn = 0;
        int todayGetİt = 0;
        int late = 0;
        private Panel homePanel = new Panel();
        private bool admin = false;
        private bool moderator = false;
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        List<string> totalReturnBooks = new List<string>();
        List<string> totalLossBooks = new List<string>();
        List<string> totaldictonary = new List<string>();
        List<DateTime> returnTimes = new List<DateTime>();
        List<string> returnClock = new List<string>();
        List<int> childBooksId = new List<int>();
        List<int> dictonaryBooksId = new List<int>();
        List<int> ansiklopediBooksId = new List<int>();
        public List<int> lossBooksId = new List<int>();
        public List<int> todayTakeBooksId = new List<int>();
        public List<int> lateBooksId = new List<int>();
        string[] childTag = {
            "çocuk",
            "cocuk",
            "çocuk kitapları",
            "cocuk kitapları",
            "cocuk kitaplari",
            "cocuklar",
            "çocuklar",
            "kids",
            "children",
            "child",
            "çoçuk",
            "çocuklar",
            "cocuklar"
        };
        string[] ansiklopediTag = { 
            "ansiklopedi",
            "ansiklopediler",
            "ansiklopedi kitapları",
            "ansıklopedı",
        };
        string[] dictonaryTag = { 
            "sözlük",
            "sozluk",
            "sozlük",
            "sözluk",
            "sözlükler",
            "dictonary",
            "el sözlügü",
            "sozlukler",
            "el sozlugu",
            "sozluk kitabı"
        };
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public HomePage()
        {
            InitializeComponent();
        }
        private void HomePage_Load(object sender, EventArgs e)
        {
            loadBooksınfo();
        }
        private void showWarning(string fullname,string details)
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
        private void loadBooksınfo()
        {
            try
            {
                int totalBook = 0;
                int childBook = 0;
                int ansiklopedi = 0;
                int dictonary = 0;
                bool childAdded = false;
                bool ansiklopediAdded = false;
                bool dictonaryAdded = false;
                SqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [Books]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalBook++;
                    string[] tags = reader["Tag"].ToString().Split(',');
                    
                    for (int index = 0; index < tags.Length; index++)
                    {

                        if (ChildTag.Contains(tags[index].ToLower())&&!childAdded)
                        {
                            childBook++;
                            childAdded = true;
                            childBooksId.Add(Convert.ToInt32(reader["Id"]));
                        }
                        if (AnsiklopediTag.Contains(tags[index].ToLower())&&!ansiklopediAdded)
                        {
                            ansiklopedi++;
                            ansiklopediAdded = true;
                            ansiklopediBooksId.Add(Convert.ToInt32(reader["Id"]));
                        }
                        if (DictonaryTag.Contains(tags[index].ToLower())&&!dictonaryAdded)
                        {
                            dictonary++;
                            dictonaryAdded = true;
                            dictonaryBooksId.Add(Convert.ToInt32(reader["Id"]));
                        }

                    }
                    childAdded = false;
                    ansiklopediAdded = false;
                    dictonaryAdded = false;
                }
                totalbookLabel.Text = totalBook.ToString();
                childBooksLabel.Text = childBook.ToString();
                ansiklopediLabel.Text = ansiklopedi.ToString();
                dictonaryLabel.Text = dictonary.ToString();
                reader.Close();
            }
            catch 
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
            loadUsersInfo();
        }
        private void loadUsersInfo()
        {
            try
            {
                int blocked = 0;
                int totalUser = 0;
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [Users]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalUser++;
                    if (Convert.ToInt32(reader["Blocked"]) == 1)
                    {
                        blocked++;
                    }
                }
                blockedLabel.Text = blocked.ToString();
                totalUserLabel.Text = totalUser.ToString();
                reader.Close();
            }
            catch
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
            loadWriterInfo();
        }
        private void loadWriterInfo()
        {
            try
            {
                int writers = 0;
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [Writer]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    writers++;
                }
                writersLabel.Text = writers.ToString();
                reader.Close();
            }
            catch
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
            loadPublishHouseInfo();
        }
        private void loadPublishHouseInfo()
        {
            try
            {
                int house = 0;
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = "SELECT * From [PublishHouse]";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    house++;
                }
                publishHouseLabel.Text = house.ToString();
                reader.Close();
            }
            catch
            {
                showWarning("İşlemler Tamamlanamadı", "Bazı işlemler tamamlanamamış olabilir, lütfen sayfayı yenileyin veya destek isteyin.");
            }
            sqlConnection.Close();
        }
       
        bool lateWarning = false;

        public SoundPlayer Sound { get => sound; set => sound = value; }
        public int TotalReturn { get => totalReturn; set => totalReturn = value; }
        public int TodayGetİt { get => todayGetİt; set => todayGetİt = value; }
        public int Late { get => late; set => late = value; }
        public Panel HomePanel { get => homePanel; set => homePanel = value; }
        public bool Admin { get => admin; set => admin = value; }
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public List<string> TotalReturnBooks { get => totalReturnBooks; set => totalReturnBooks = value; }
        public List<string> TotalLossBooks { get => totalLossBooks; set => totalLossBooks = value; }
        public List<string> Totaldictonary { get => totaldictonary; set => totaldictonary = value; }
        public List<DateTime> ReturnTimes { get => returnTimes; set => returnTimes = value; }
        public List<string> ReturnClock { get => returnClock; set => returnClock = value; }
        public string[] ChildTag { get => childTag; set => childTag = value; }
        public string[] AnsiklopediTag { get => ansiklopediTag; set => ansiklopediTag = value; }
        public string[] DictonaryTag { get => dictonaryTag; set => dictonaryTag = value; }
        public bool LateWarning { get => lateWarning; set => lateWarning = value; }
        public bool Moderator { get => moderator; set => moderator = value; }

        private void label21_Click(object sender, EventArgs e)
        {
            showWritersPage(false);
        }

        private void label21_MouseHover(object sender, EventArgs e)
        {
            label21.ForeColor = Color.Chocolate;
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.ForeColor = Color.WhiteSmoke;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            showWritersPage(true);
        }

        private void label19_MouseHover(object sender, EventArgs e)
        {
            label19.ForeColor = Color.Chocolate;
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            label19.ForeColor = Color.WhiteSmoke;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            showWriterAndHouseBooksPage("Çocuk kitapları arayın...", childBooksId);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            showWriterAndHouseBooksPage("Ansiklopedileri arayın...", ansiklopediBooksId);
        }

        private void label29_Click(object sender, EventArgs e)
        {
            showWriterAndHouseBooksPage("Sözlükleri arayın...", dictonaryBooksId);
        }

        private void label25_MouseHover(object sender, EventArgs e)
        {
            label25.ForeColor = Color.Chocolate;
        }

        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.ForeColor = Color.WhiteSmoke;
        }

        private void label27_MouseHover(object sender, EventArgs e)
        {
            label27.ForeColor = Color.Chocolate;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.ForeColor = Color.WhiteSmoke;
        }

        private void label29_MouseHover(object sender, EventArgs e)
        {
            label29.ForeColor = Color.Chocolate;
        }

        private void label29_MouseLeave(object sender, EventArgs e)
        {
            label29.ForeColor = Color.WhiteSmoke;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            showWriterAndHouseBooksPage("Kayıp kitapları arayın...", lossBooksId);
        }

        private void label17_MouseHover(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Chocolate;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.WhiteSmoke;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            showWriterAndHouseBooksPage("Bugün alınacakları arayın...", todayTakeBooksId);
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            label23.ForeColor = Color.Chocolate;
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            label23.ForeColor = Color.WhiteSmoke;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            showLateBooks();
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            label12.Font = new Font(DefaultFont.FontFamily, 8f, FontStyle.Bold);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.Font = new Font(DefaultFont.FontFamily, 9.75f, FontStyle.Regular);
        }

        private void lateBooksLabel_Click(object sender, EventArgs e)
        {
            showLateBooks();
        }
        private void showLateBooks()
        {
            showWriterAndHouseBooksPage("Geçmiş kitapları arayın...", lateBooksId);
        }

        private void lateBooksLabel_MouseHover(object sender, EventArgs e)
        {
            lateBooksLabel.ForeColor = Color.Chocolate;
        }

        private void lateBooksLabel_MouseLeave(object sender, EventArgs e)
        {
            lateBooksLabel.ForeColor = Color.WhiteSmoke;
        }
        private void showWriterAndHouseBooksPage(string placeHolder, List<int> booksId)
        {
            HomePanel.Controls.Clear();
            WriterAndHouseBooks page = new WriterAndHouseBooks();
            page.TopLevel = false;
            page.Dock = DockStyle.Fill;
            page.pageViewerPanel = HomePanel;
            page.home = this;
            page.homeMode = true;
            page.booksId = booksId;
            page.searchBox.PlaceholderText = placeHolder;
            page.panel1.BackColor = lightColor;
            page.panel4.BackColor = lightColor;
            page.flowLayoutPanel1.BackColor = lightColor;
            page.powColor = powColor;
            page.lightColor = lightColor;
            page.foreColor = foreColor;
            page.admin = admin;
            page.moderator = moderator;
            HomePanel.Controls.Add(page);
            page.Show();
        }
        private void showWritersPage(bool houseMode)
        {
            HomePanel.Controls.Clear();
            WritersPage page = new WritersPage();
            page.TopLevel = false;
            page.Dock = DockStyle.Fill;
            page.pageViewerPanel = HomePanel;
            page.home = this;
            page.publishHouseMode = houseMode;
            page.powColor = powColor;
            page.lightColor = lightColor;
            page.foreColor = foreColor;
            page.panel1.BackColor = lightColor;
            page.panel4.BackColor = lightColor;
            page.flowLayoutPanel1.BackColor = lightColor;
            page.admin = admin;
            page.moderator = moderator;
            HomePanel.Controls.Add(page);
            page.Show();
        }
    }
}
