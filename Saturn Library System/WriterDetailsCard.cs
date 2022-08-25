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
    public partial class WriterDetailsCard : Form
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
        public WriterDetailsCard()
        {
            InitializeComponent();
        }

        private void WriterDetailsCard_Load(object sender, EventArgs e)
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
                if (fullnameLabel.Text.ToLower() == reader["WRITER"].ToString().ToLower())
                {
                    totalBooks++;
                    booksId.Add(Convert.ToInt32(reader["Id"]));
                }
            }
            reader.Close();
            sqlConnection.Close();
            numberLabel.Text = totalBooks.ToString();
        }

        private void deletePicturebox_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.deleteWriter = true;
                warning.Id = Id;
                warning.fullNameLabel.Text = "Yazarı Sil";
                warning.emailLabel.Text = "Bu yazar kalıcı olarak silinecek.";
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
                warning.emailLabel.Text = "Yazarı silmek için Admin olmanız gerekmektedir";
                warning.ShowDialog();
            }
        }

        private void editPicturebox_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddWriter edit = new AddWriter();
                edit.EditMode = true;
                edit.Id = Id;
                edit.BackColor = lightColor;
                edit.nameTextbox.FillColor = lightColor;
                edit.surnameBox.FillColor = lightColor;
                edit.linksBox.FillColor = lightColor;
                edit.phoneNumberbox.FillColor = lightColor;
                edit.genusBox.FillColor = lightColor;
                edit.cityBox.FillColor = lightColor;
                edit.infoBox.FillColor = lightColor;
                edit.languageBox.FillColor = lightColor;
                edit.emailBox.FillColor = lightColor;
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
                warning.emailLabel.Text = "Yazar bilgilerini düzenleyebilmek için Admin veya Moderator olmanız gerekmektedir";
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
            warning.fullNameLabel.Text = "Yazar Bilgisi";
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
