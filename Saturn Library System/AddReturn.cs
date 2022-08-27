using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class AddReturn : Form
    {
        private MaterialEffect effect = new MaterialEffect();
        //for add return books
        private int bookId = 0;
        private int page = 0;
        public int stockNumber = 0;
        private bool onUsersPage = false;
        //for users add return books
        private int userId = 0;
        private string[] getBooksId = { };
        public bool admin = false;
        public bool moderator = false;

        public MaterialEffect Effect { get => effect; set => effect = value; }
        public int BookId { get => bookId; set => bookId = value; }
        public int Page { get => page; set => page = value; }
        public bool OnUsersPage { get => onUsersPage; set => onUsersPage = value; }
        public int UserId { get => userId; set => userId = value; }
        public string[] GetBooksId { get => getBooksId; set => getBooksId = value; }


        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public AddReturn()
        {
            InitializeComponent();
        }

        private void AddReturn_Load(object sender, EventArgs e)
        {
            loadPage();
        }
        private void loadPage()
        {
            try
            {
                pageViewerPanel.Controls.Clear();
                if (!OnUsersPage)
                {
                    UsersPage users = new UsersPage();
                    users.powColor = powColor;
                    users.lightColor = lightColor;
                    users.foreColor = foreColor;
                    users.panel1.BackColor = lightColor;
                    users.flowLayoutPanel1.BackColor = lightColor;
                    users.BackColor = lightColor;
                    users.addReturn = true;
                    users.TopLevel = false;
                    users.Dock = DockStyle.Fill;
                    users.bookId = BookId;
                    users.page = Page;
                    users.bookNumber = stockNumber;
                    users.takeDate = DateTime.Parse(guna2DateTimePicker1.Text);
                    users.clock = clockPicker.Text;
                    users.admin = admin;
                    users.moderator = moderator;
                    pageViewerPanel.Controls.Add(users);
                    users.Show();
                }
                else
                {
                    headerLabel.Text = "Kitapları Seçin";
                    BooksPage books = new BooksPage();
                    books.powColor = powColor;
                    books.lightColor = lightColor;
                    books.foreColor = foreColor;
                    books.panel1.BackColor = lightColor;
                    books.flowLayoutPanel1.BackColor = lightColor;
                    books.BackColor = lightColor;
                    books.AddReturn = true;
                    books.UserId = UserId;
                    books.TopLevel = false;
                    books.Dock = DockStyle.Fill;
                    books.TakeDate = DateTime.Parse(guna2DateTimePicker1.Text);
                    books.Clock = clockPicker.Text;
                    books.Page = Page;
                    books.Admin = admin;
                    books.Moderator = moderator;
                    books.stockNumber = stockNumber;
                    pageViewerPanel.Controls.Add(books);
                    books.Show();
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.errorMode = true;
                warning.effect = effect;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Yükleme yapılırken bir hata oluştu, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Effect.Close();
            this.Close();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadPage();
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            loadPage();
        }
    }
}
