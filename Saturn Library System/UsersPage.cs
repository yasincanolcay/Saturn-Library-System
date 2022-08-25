using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class UsersPage : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool sortingChange = false;
        bool IssearchBoxClear = false;
        bool searchBoxSourceIsAdded = false;
        public Panel usersPanel = new Panel();
        public bool addReturn = false;
        public bool admin = false;
        public bool moderator = false;
        public int bookId = 0;
        public int page = 0;
        public int bookNumber = 0;
        public int blockedNumber = 1;
        public DateTime takeDate = DateTime.Now;
        public string clock = "11:22:00";
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public UsersPage()
        {
            InitializeComponent();
        }

        private void UsersPage_Load(object sender, EventArgs e)
        {
            if (!sortingChange)
            {
                loadUser(false);
                thumbSortButton.ShadowDecoration.Enabled = true;
                listSortButton.ShadowDecoration.Enabled = false;
            }
            else
            {
                loadDetailUser(false);
                thumbSortButton.ShadowDecoration.Enabled = false;
                listSortButton.ShadowDecoration.Enabled = true;
            }
        }
        private void loadUser(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Users]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["Blocked"])!=blockedNumber)
                {
                    UserCard userthumbCard = new UserCard();
                    userthumbCard.usersPanel = usersPanel;
                    userthumbCard.userspage = this;
                    userthumbCard.guna2Panel1.FillColor = lightColor;
                    userthumbCard.emailLabel.ForeColor = foreColor;
                    userthumbCard.BackColor = lightColor;
                    userthumbCard.powColor = powColor;
                    userthumbCard.lightColor=lightColor;
                    userthumbCard.foreColor = foreColor;
                    userthumbCard.admin = admin;
                    userthumbCard.moderator = moderator;
                    if (blockedNumber == 0)
                    {
                        userthumbCard.pictureBox5.Enabled = false;
                        userthumbCard.karaListeyeEkleToolStripMenuItem.Text = "Kara Listeden Çıkar";
                        userthumbCard.isBlocked = true;
                    }
                    if (!search)
                    {
                        userthumbCard.TopLevel = false;
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["ProfilePicture"]);
                        //MemoryStream mem = new MemoryStream(data);
                        string tag = reader["Email"].ToString();
                        string countryId = reader["CountryIdNo"].ToString();
                        if (!filterCombobox.Items.Contains(tag))
                        {
                            filterCombobox.Items.Add(tag);
                        }
                        if (!filterCombobox.Items.Contains(countryId))
                        {
                            filterCombobox.Items.Add(countryId);
                        }
                        userthumbCard.photoPath = data;
                        userthumbCard.Id = Convert.ToInt32(reader["Id"]);
                        if (!searchBoxSourceIsAdded)
                        {
                            searchBox.AutoCompleteCustomSource.Add(reader["NAME"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["NAME"].ToString() + " " + reader["Surname"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["Surname"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["CountryIdNo"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["Address"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["Phone"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["School"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["HousePhone"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["Email"].ToString());
                            searchBox.AutoCompleteCustomSource.Add(reader["Address"].ToString());
                        }
                        userthumbCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        userthumbCard.emailLabel.Text = reader["Email"].ToString();
                        userthumbCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                        userthumbCard.medal = Convert.ToInt32(reader["Medal"]);
                        userthumbCard.addReturn = addReturn;
                        userthumbCard.bookId = bookId;
                        userthumbCard.takeDate = takeDate;
                        userthumbCard.clock = clock;
                        userthumbCard.page = page;
                        userthumbCard.bookNumber = bookNumber;
                        flowLayoutPanel1.Controls.Add(userthumbCard);
                        userthumbCard.Show();
                    }
                    else
                    {

                        if (searchBox.Text.ToLower() == reader["Name"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Surname"].ToString().ToLower() || searchBox.Text.ToLower() == reader["CountryIdNo"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Email"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Address"].ToString().ToLower() || searchBox.Text.ToLower() == reader["School"].ToString().ToLower() || searchBox.Text.ToLower() == reader["HousePhone"].ToString().ToLower() || searchBox.Text == reader["Phone"].ToString() || searchBox.Text == reader["Name"].ToString() + " " + reader["Surname"])
                        {
                            userthumbCard.TopLevel = false;
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["ProfilePicture"]);
                            //MemoryStream mem = new MemoryStream(data);
                            userthumbCard.photoPath = data;
                            userthumbCard.Id = Convert.ToInt32(reader["Id"]);
                            userthumbCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                            userthumbCard.emailLabel.Text = reader["Email"].ToString();
                            userthumbCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                            userthumbCard.medal = Convert.ToInt32(reader["Medal"]);
                            userthumbCard.addReturn = addReturn;
                            userthumbCard.bookId = bookId;
                            userthumbCard.takeDate = takeDate;
                            userthumbCard.clock = clock;
                            userthumbCard.page = page;
                            userthumbCard.bookNumber = bookNumber;
                            flowLayoutPanel1.Controls.Add(userthumbCard);
                            userthumbCard.Show();
                        }
                        if (reader["Email"].ToString()==filterCombobox.Text || reader["CountryIdNo"].ToString() == filterCombobox.Text && filterCombobox.Text != "")
                        {
                            userthumbCard.TopLevel = false;
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["ProfilePicture"]);
                            userthumbCard.photoPath = data;
                            userthumbCard.Id = Convert.ToInt32(reader["Id"]);
                            userthumbCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                            userthumbCard.emailLabel.Text = reader["Email"].ToString();
                            userthumbCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                            userthumbCard.medal = Convert.ToInt32(reader["Medal"]);
                            userthumbCard.addReturn = addReturn;
                            userthumbCard.bookId = bookId;
                            userthumbCard.takeDate = takeDate;
                            userthumbCard.clock = clock;
                            userthumbCard.page = page;
                            userthumbCard.bookNumber = bookNumber;
                            flowLayoutPanel1.Controls.Add(userthumbCard);
                            userthumbCard.Show();
                        }

                    }
                }

            }
            searchBoxSourceIsAdded = true;
            reader.Close();
            sqlConnection.Close();
        }

        private void loadDetailUser(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Users]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["Blocked"]) != blockedNumber)
                {
                    UserDetailsCard userDetailCard = new UserDetailsCard();
                    userDetailCard.usersPanel = usersPanel;
                    userDetailCard.userspage = this;
                    userDetailCard.guna2Panel1.FillColor = lightColor;
                    userDetailCard.emailLabel.ForeColor = foreColor;
                    userDetailCard.BackColor = lightColor;
                    userDetailCard.schoolNameLabel.ForeColor = foreColor;
                    userDetailCard.addressDetailLabel.ForeColor = foreColor;
                    userDetailCard.returnNumberLabel.ForeColor = foreColor;
                    userDetailCard.pageNumberLabel.ForeColor = foreColor;
                    userDetailCard.powColor = powColor;
                    userDetailCard.lightColor = lightColor;
                    userDetailCard.foreColor = foreColor;
                    userDetailCard.admin = admin;
                    userDetailCard.moderator = moderator;
                    if (blockedNumber == 0)
                    {
                        userDetailCard.pictureBox5.Enabled = false;
                        userDetailCard.toolStripMenuItem2.Text = "Kara Listeden Çıkar";
                        userDetailCard.isBlocked = true;
                    }
                    if (!search)
                    {
                        userDetailCard.TopLevel = false;
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["ProfilePicture"]);
                        //MemoryStream mem = new MemoryStream(data);
                        userDetailCard.photoPath = data;
                        userDetailCard.Id = Convert.ToInt32(reader["Id"]);
                        userDetailCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        userDetailCard.emailLabel.Text = reader["Email"].ToString();
                        userDetailCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                        userDetailCard.medal = Convert.ToInt32(reader["Medal"]);
                        userDetailCard.schoolNameLabel.Text = reader["School"].ToString();
                        userDetailCard.addressDetailLabel.Text = reader["Address"].ToString();
                        userDetailCard.pageNumberLabel.Text = reader["totalPage"].ToString();
                        userDetailCard.addReturn = addReturn;
                        userDetailCard.bookId = bookId;
                        userDetailCard.takeDate = takeDate;
                        userDetailCard.clock = clock;
                        userDetailCard.page = page;
                        userDetailCard.bookNumber = bookNumber;
                        flowLayoutPanel1.Controls.Add(userDetailCard);
                        userDetailCard.Show();
                    }
                    else
                    {

                        if (searchBox.Text.ToLower() == reader["Name"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Surname"].ToString().ToLower() || searchBox.Text.ToLower() == reader["CountryIdNo"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Email"].ToString().ToLower() || searchBox.Text.ToLower() == reader["Address"].ToString().ToLower() || searchBox.Text.ToLower() == reader["School"].ToString().ToLower() || searchBox.Text.ToLower() == reader["HousePhone"].ToString().ToLower() || searchBox.Text == reader["Phone"].ToString() || searchBox.Text == reader["Name"].ToString() + " " + reader["Surname"])
                        {
                            userDetailCard.TopLevel = false;
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["ProfilePicture"]);
                            //MemoryStream mem = new MemoryStream(data);
                            userDetailCard.photoPath = data;
                            userDetailCard.Id = Convert.ToInt32(reader["Id"]);
                            userDetailCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                            userDetailCard.emailLabel.Text = reader["Email"].ToString();
                            userDetailCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                            userDetailCard.medal = Convert.ToInt32(reader["Medal"]);
                            userDetailCard.schoolNameLabel.Text = reader["School"].ToString();
                            userDetailCard.addressDetailLabel.Text = reader["Address"].ToString();
                            userDetailCard.pageNumberLabel.Text = reader["totalPage"].ToString();
                            userDetailCard.addReturn = addReturn;
                            userDetailCard.bookId = bookId;
                            userDetailCard.takeDate = takeDate;
                            userDetailCard.clock = clock;
                            userDetailCard.page = page;
                            userDetailCard.bookNumber = bookNumber;
                            flowLayoutPanel1.Controls.Add(userDetailCard);
                            userDetailCard.Show();
                        }
                        if (reader["Email"].ToString() == filterCombobox.Text || reader["CountryIdNo"].ToString() == filterCombobox.Text && filterCombobox.Text != "")
                        {
                            userDetailCard.TopLevel = false;
                            Byte[] data = new Byte[0];
                            data = (Byte[])(reader["ProfilePicture"]);
                            userDetailCard.photoPath = data;
                            userDetailCard.Id = Convert.ToInt32(reader["Id"]);
                            userDetailCard.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                            userDetailCard.emailLabel.Text = reader["Email"].ToString();
                            userDetailCard.scoreRatingStar.Value = float.Parse(reader["Score"].ToString());
                            userDetailCard.medal = Convert.ToInt32(reader["Medal"]);
                            userDetailCard.schoolNameLabel.Text = reader["School"].ToString();
                            userDetailCard.addressDetailLabel.Text = reader["Address"].ToString();
                            userDetailCard.pageNumberLabel.Text = reader["totalPage"].ToString();
                            userDetailCard.addReturn = addReturn;
                            userDetailCard.bookId = bookId;
                            userDetailCard.takeDate = takeDate;
                            userDetailCard.clock = clock;
                            userDetailCard.page = page;
                            userDetailCard.bookNumber = bookNumber;
                            flowLayoutPanel1.Controls.Add(userDetailCard);
                            userDetailCard.Show();
                        }

                    }

                }
            }
            reader.Close();
            sqlConnection.Close();
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
                    loadUser(true);
                }
                else
                {
                    loadDetailUser(true);
                }
            }
            else
            {
                refreshButton.PerformClick();
            }
        }

        private void thumbSortButton_Click(object sender, EventArgs e)
        {
            loadUser(false);
            thumbSortButton.ShadowDecoration.Enabled = true;
            listSortButton.ShadowDecoration.Enabled = false;
            sortingChange = false;
            thumbSortButton.ShadowDecoration.Color = foreColor;
        }

        private void listSortButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Enabled = false;
            sortingChange = true;
            loadDetailUser(false);
            listSortButton.ShadowDecoration.Color = foreColor;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            filterCombobox.Text = "";
            IssearchBoxClear = false;
            if (!sortingChange)
            {
                loadUser(false);
            }
            else
            {
                loadDetailUser(false);
            }
        }

        private void filterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sortingChange)
            {
                loadUser(true);
            }
            else
            {
                loadDetailUser(true);
            }
        }
    }
}
