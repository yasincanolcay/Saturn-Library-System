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
    public partial class PublishHouseDetailCard : Form
    {
        public bool admin = false;
        public bool moderator = false;
        public byte[] photoByte = { };
        public int Id = 0;
        public string info = "";
        List<int> booksId = new List<int>();

        public Panel pageViewerPanel = new Panel();
        public HomePage home = new HomePage();
        public WritersPage writersPage = new WritersPage();

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public PublishHouseDetailCard()
        {
            InitializeComponent();
        }

        private void PublishHouseDetailCard_Load(object sender, EventArgs e)
        {
            int totalBooks = 0;
            MemoryStream mem = new MemoryStream(photoByte);
            profileBox.Image = Image.FromStream(mem);
            profileBox.BackgroundImage = Image.FromStream(mem);
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT * From [Books]";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (fullnameLabel.Text.ToLower() == reader["PUBLISHHOUSE"].ToString().ToLower())
                {
                    totalBooks++;
                    booksId.Add(Convert.ToInt32(reader["Id"]));
                }
            }
            reader.Close();
            sqlConnection.Close();
            numberLabel.Text = totalBooks.ToString();
        }

        private void editPicturebox_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddPublishHouse edit = new AddPublishHouse();
                edit.EditMode = true;
                edit.Id = Id;
                edit.BackColor = lightColor;
                edit.nameTextbox.FillColor = lightColor;
                edit.certificateBox.FillColor = lightColor;
                edit.linksBox.FillColor = lightColor;
                edit.contactBox.FillColor = lightColor;
                edit.addressBox.FillColor = lightColor;
                edit.infoBox.FillColor = lightColor;
                edit.extraBox.FillColor = lightColor;
                edit.Show();
            }
            else
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "Erişim Reddedildi";
                warning.emailLabel.Text = "Yaınevini düzenleyebilmek Admin veya Moderator olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void deletePicturebox_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.deleteHouse = true;
                warning.Id = Id;
                warning.fullNameLabel.Text = "Yayınevi Sil";
                warning.emailLabel.Text = "Bu yayınevi kalıcı olarak silinecek.";
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
                warning.emailLabel.Text = "Yayınevini silmek için Admin olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void infoPicturebox_Click(object sender, EventArgs e)
        {
            MaterialEffect effect = new MaterialEffect();
            effect.Show();
            WarningCard warning = new WarningCard();
            warning.effect = effect;
            warning.Info = true;
            warning.pictureBox1.Image = Image.FromFile("images/info_80px.png");
            warning.errorMode = true;
            warning.fullNameLabel.Text = "Yayınevi Bilgisi";
            warning.emailLabel.Text = info;
            warning.ShowDialog();
        }

        private void numberLabel_Click(object sender, EventArgs e)
        {
            WriterAndHouseBooks books = new WriterAndHouseBooks();
            books.TopLevel = false;
            books.Dock = DockStyle.Fill;
            books.home = home;
            books.writers = writersPage;
            books.pageViewerPanel = pageViewerPanel;
            books.booksId = booksId;
            books.searchBox.PlaceholderText = "Yayınevinin kitaplarını arayın";
            books.powColor = powColor;
            books.lightColor = lightColor;
            books.foreColor = foreColor;
            books.BackColor = lightColor;
            books.flowLayoutPanel1.BackColor = lightColor;
            books.panel1.BackColor = lightColor;
            books.admin = admin;
            books.moderator = moderator;
            pageViewerPanel.Controls.Clear();
            pageViewerPanel.Controls.Add(books);
            books.Show();
        }
    }
}
