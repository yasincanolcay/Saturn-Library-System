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
    public partial class BookShowCard : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool admin = false;
        public bool moderator = false;
        private bool mostRead = false;
        private string[] tags = { };
        private byte[] photoPath = { };
        private int id = 0;
        private int managerId = 0;
        private string managerUsername = "";
        //---------------------//
        string[] users = { };

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public bool MostRead { get => mostRead; set => mostRead = value; }
        public string[] Tags { get => tags; set => tags = value; }
        public byte[] PhotoPath { get => photoPath; set => photoPath = value; }
        public int Id { get => id; set => id = value; }
        public string[] Users { get => users; set => users = value; }
        public int ManagerId { get => managerId; set => managerId = value; }
        public string ManagerUsername { get => managerUsername; set => managerUsername = value; }

        public BookShowCard()
        {
            InitializeComponent();
        }

        private void BookShowCard_Load(object sender, EventArgs e)
        {
            getUserAndReturns();
        }
        private void getUserAndReturns()
        {
            try
            {
                int totalReturn = 0;
                SqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlConnection;
                command.CommandText = ("Select * From [ReturnBooks]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Id == Convert.ToInt32(reader["BookId"]))
                    {
                        totalReturn++;
                        Users.Append<string>(reader["UserId"].ToString());
                    }
                }
                reader.Close();
                SqlConnection.Close();
                returnNumberLabel.Text = totalReturn.ToString();
                int totalStock = Convert.ToInt32(stockNumberLabel.Text) - totalReturn;
                totalNumberLabel.Text = totalStock.ToString();
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.fullNameLabel.Text = "Emanetler Alınamadı";
                warning.emailLabel.Text = "Toplam emanet sayısı alınırken bir hata oluştu!";
                warning.errorMode = true;
                warning.ShowDialog();
            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                try
                {
                    editButton.Enabled = false;
                    AddBook editbook = new AddBook();
                    editbook.PhotoPath = PhotoPath;
                    editbook.EditMode = true;
                    editbook.saveButton.Text = "KAYDET";
                    editbook.mostToggle.Checked = MostRead;
                    editbook.nameTextbox.Text = bookHeaderLabel.Text;
                    editbook.isbnTextbox.Text = isbnNumberLabel.Text;
                    editbook.writerTextbox.Text = writernameLabel.Text;
                    editbook.publishHomeTextbox.Text = publishouseLabel.Text;
                    editbook.genusTextbox.Text = genusNameLabel.Text;
                    editbook.guna2DateTimePicker1.Text = printeddateDateLabel.Text;
                    editbook.printedNumber.Text = printedNumberNumLabel.Text;
                    editbook.detailsTextbox.Text = bookDetailLabel.Text;
                    if (Tags.Length != 0)
                    {
                        editbook.tableLayoutPanel1.Controls.Clear();
                        editbook.ClearTag = true;
                        editbook.C.AddRange(Tags);
                        for (int tIndex = 0; tIndex < Tags.Length; tIndex++)
                        {
                            Guna.UI2.WinForms.Guna2Chip tagChip = new Guna.UI2.WinForms.Guna2Chip();
                            tagChip.Text = Tags[tIndex];
                            tagChip.FillColor = Color.Chocolate;
                            tagChip.IsClosable = true;
                            editbook.tableLayoutPanel1.Controls.Add(tagChip);
                            tagChip.Show();
                        }
                        editbook.MaxTag = Tags.Length;
                    }
                    editbook.pageNumberBox.Text = pageNumberNumLabel.Text;
                    editbook.stockNumberBox.Text = stockNumberLabel.Text;
                    editbook.shelfTextbox.Text = shelfToLabel.Text;
                    editbook.shelfLineTextbox.Text = shelfLineNameLabel.Text;
                    editbook.certificateTextbox.Text = certificatenoLabel.Text;
                    editbook.teamTextbox.Text = teamNamesLabel.Text;
                    editbook.languageTextbox.Text = languageNameLabel.Text;
                    editbook.translaterTextbox.Text = translaterNameLabel.Text;
                    editbook.Id = Id;
                    editbook.ReturnBooks = Convert.ToInt32(returnNumberLabel.Text);
                    editbook.BackColor = lightColor;
                    editbook.nameTextbox.FillColor = lightColor;
                    editbook.isbnTextbox.FillColor = lightColor;
                    editbook.writerTextbox.FillColor = lightColor;
                    editbook.publishHomeTextbox.FillColor = lightColor;
                    editbook.genusTextbox.FillColor = lightColor;
                    editbook.detailsTextbox.FillColor = lightColor;
                    editbook.printedNumber.FillColor = lightColor;
                    editbook.printedNumber.ForeColor = foreColor;
                    editbook.guna2DateTimePicker1.FillColor = lightColor;
                    editbook.guna2DateTimePicker1.BackColor = lightColor;
                    editbook.guna2DateTimePicker1.ForeColor = foreColor;
                    editbook.tagTextbox.FillColor = lightColor;
                    editbook.pageNumberBox.FillColor = lightColor;
                    editbook.pageNumberBox.ForeColor = foreColor;
                    editbook.stockNumberBox.FillColor = lightColor;
                    editbook.stockNumberBox.ForeColor = foreColor;
                    editbook.shelfTextbox.FillColor = lightColor;
                    editbook.shelfLineTextbox.FillColor = lightColor;
                    editbook.tableLayoutPanel1.BackColor = lightColor;
                    editbook.certificateTextbox.FillColor = lightColor;
                    editbook.teamTextbox.FillColor = lightColor;
                    editbook.languageTextbox.FillColor = lightColor;
                    editbook.translaterTextbox.FillColor = lightColor;
                    editbook.ManagerUsername = managerUsername;
                    editbook.ManagerId = managerId;
                    guna2Transition1.Show(editbook);
                    editButton.Enabled = true;
                }
                catch
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect;
                    warning.fullNameLabel.Text = "Birşeyler Ters Gitti";
                    warning.emailLabel.Text = "Hay aksi, düzenleme penceresi açılamadı, lütfen tekrar deneyin!";
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
                warning.fullNameLabel.Text = "ERİŞİM REDDEDİLDİ";
                warning.emailLabel.Text = "Kitap bilgilerini düzenlemek için Admin veya Moderator olmanız gerekmektedir.";
                warning.errorMode = true;
                warning.ShowDialog();
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin || moderator)
                {
                    if (Convert.ToInt32(totalNumberLabel.Text) > 0)
                    {
                        MaterialEffect effect = new MaterialEffect();
                        effect.Show();
                        AddReturn add = new AddReturn();
                        add.BackColor = lightColor;
                        add.Effect = effect;
                        add.BookId = Id;
                        add.OnUsersPage = false;
                        add.Page = Convert.ToInt32(pageNumberNumLabel.Text);
                        add.stockNumber = Convert.ToInt32(stockNumberLabel.Text);
                        add.powColor = powColor;
                        add.lightColor = lightColor;
                        add.foreColor = foreColor;
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
                    warning.fullNameLabel.Text = "ERİŞİM REDDEDİLDİ";
                    warning.emailLabel.Text = "Emanet verebilmek için Admin veya Moderator olmanız gerekmektedir";
                    warning.ShowDialog();
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
                warning.emailLabel.Text = "İşlem gerçekleştirilemiyor, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                GetReturnDialog returnDialog = new GetReturnDialog();
                returnDialog.onUsers = false;
                returnDialog.effect = effect;
                returnDialog.Id = Id;
                returnDialog.booksCard = false;
                returnDialog.BackColor = lightColor;
                returnDialog.pageViewerPanel.BackColor = lightColor;
                returnDialog.powColor = powColor;
                returnDialog.lightColor = lightColor;
                returnDialog.foreColor = foreColor;
                returnDialog.admin = admin;
                returnDialog.moderator = moderator;
                returnDialog.ShowDialog();
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.errorMode = true;
                warning.effect = effect;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    WarningCard warning = new WarningCard();
                    warning.effect = effect;
                    warning.errorMode = false;
                    warning.Id = Id;
                    warning.deleteBook = true;
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
                    warning.emailLabel.Text = "Kitabı silebilmek için Admin olmanız gerekmektedir";
                    warning.ShowDialog();
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
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin || moderator)
                {
                    MaterialEffect effect = new MaterialEffect();
                    effect.Show();
                    GetReturnDialog returnDialog = new GetReturnDialog();
                    returnDialog.onUsers = false;
                    returnDialog.effect = effect;
                    returnDialog.Id = Id;
                    returnDialog.booksCard = false;
                    returnDialog.addLoss = true;
                    returnDialog.BackColor = lightColor;
                    returnDialog.pageViewerPanel.BackColor = lightColor;
                    returnDialog.powColor = powColor;
                    returnDialog.lightColor = lightColor;
                    returnDialog.foreColor = foreColor;
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
                    warning.emailLabel.Text = "Kayıp kitap ekleyebilmek için Admin veya Moderator olmanız gerekmektedir";
                    warning.ShowDialog();
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
                warning.emailLabel.Text = "Bazı işlemler gerçekleştirilemedi, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }
    }
}
