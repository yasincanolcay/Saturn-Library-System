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
    public partial class WritersPage : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool admin = false;
        public bool moderator = false;
        public Panel pageViewerPanel = new Panel();
        public HomePage home = new HomePage();
        bool sorting = false;
        bool searchBoxSourceIsAdded = false;
        bool IssearchBoxClear = false;
        public bool publishHouseMode = false;
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public WritersPage()
        {
            InitializeComponent();
        }

        //Ana sayfaya don
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pageViewerPanel.Controls.Clear();
            pageViewerPanel.Controls.Add(home);
            home.Show();
        }

        private void WritersPage_Load(object sender, EventArgs e)
        {
            if (!publishHouseMode)
            {
                loadWriterCard(false);
            }
            else
            {
                loadPublishHouse(false);
                searchBox.PlaceholderText = "Yayınevi Arayın...";
            }
        }
        private void loadWriterCard(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Writer]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WriterCard card = new WriterCard();
                card.BackColor = lightColor;
                card.guna2Panel1.FillColor = lightColor;
                card.emailLabel.ForeColor = foreColor;
                card.linkLabel.ForeColor = foreColor;
                card.lightColor = lightColor;
                card.admin = admin;
                card.moderator = moderator;
                if (!search)
                {
                    if (!searchBoxSourceIsAdded)
                    {
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Surname"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString()+" "+reader["Surname"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Email"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Phone"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Links"].ToString());
                        filterCombobox.Items.Add(reader["Name"]+" "+reader["Surname"].ToString());
                    }
                    card.TopLevel = false;
                    card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                    card.emailLabel.Text = reader["Email"].ToString();
                    card.linkLabel.Text = reader["Links"].ToString();
                    card.Id = Convert.ToInt32(reader["Id"]);
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["Photo"]);
                    card.photoByte = data;
                    flowLayoutPanel1.Controls.Add(card);
                    card.Show();
                }
                else
                {
                    if(reader["Name"].ToString().ToLower()==searchBox.Text.ToLower()|| reader["Surname"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Name"].ToString().ToLower()+" "+reader["Surname"].ToString().ToLower()==searchBox.Text.ToLower()||reader["Email"].ToString().ToLower()==searchBox.Text.ToLower()||reader["Phone"].ToString().ToLower()==searchBox.Text.ToLower()||reader["Links"].ToString().ToLower()==searchBox.Text.ToLower())
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        card.emailLabel.Text = reader["Email"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Photo"]);
                        card.photoByte = data;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    if(reader["Name"].ToString()+" " + reader["Surname"].ToString() == filterCombobox.Text)
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        card.emailLabel.Text = reader["Email"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Photo"]);
                        card.photoByte = data;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
            searchBoxSourceIsAdded = true;
        }
        private void loadWriterDetailsCard(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [Writer]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                WriterDetailsCard card = new WriterDetailsCard();
                card.BackColor = lightColor;
                card.guna2Panel1.FillColor = lightColor;
                card.emailLabel.ForeColor = foreColor;
                card.linkLabel.ForeColor = foreColor;
                card.guna2ShadowPanel6.FillColor = lightColor;
                card.phoneLabel.ForeColor = foreColor;
                card.genusLabel.ForeColor = foreColor;
                card.languageLabel.ForeColor = foreColor;
                card.powColor = powColor;
                card.lightColor = lightColor;
                card.foreColor = foreColor;
                card.admin = admin;
                card.moderator = moderator;
                if (!search)
                {
                    if (!searchBoxSourceIsAdded)
                    {
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Surname"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString() + " " + reader["Surname"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Email"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Phone"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Links"].ToString());
                        filterCombobox.Items.Add(reader["Name"] + " " + reader["Surname"].ToString());
                    }
                    card.TopLevel = false;
                    card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                    card.emailLabel.Text = reader["Email"].ToString();
                    card.linkLabel.Text = reader["Links"].ToString();
                    card.cityLabel.Text = reader["City"].ToString();
                    card.phoneLabel.Text = reader["Phone"].ToString();
                    card.genusLabel.Text = reader["Genus"].ToString();
                    card.languageLabel.Text = reader["Language"].ToString();
                    card.Id = Convert.ToInt32(reader["Id"]);
                    card.info = reader["Info"].ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["Photo"]);
                    card.photoByte = data;
                    card.home = home;
                    card.pageViewerPanel = pageViewerPanel;
                    card.writersPage = this;
                    flowLayoutPanel1.Controls.Add(card);
                    card.Show();
                }
                else
                {
                    if (reader["Name"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Surname"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Name"].ToString().ToLower() + " " + reader["Surname"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Email"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Phone"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Links"].ToString().ToLower() == searchBox.Text.ToLower())
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        card.emailLabel.Text = reader["Email"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.cityLabel.Text = reader["City"].ToString();
                        card.phoneLabel.Text = reader["Phone"].ToString();
                        card.genusLabel.Text = reader["Genus"].ToString();
                        card.languageLabel.Text = reader["Language"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.info = reader["Info"].ToString();
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Photo"]);
                        card.photoByte = data;
                        card.home = home;
                        card.pageViewerPanel = pageViewerPanel;
                        card.writersPage = this;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    if (reader["Name"].ToString() + " " + reader["Surname"].ToString() == filterCombobox.Text)
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString() + " " + reader["Surname"].ToString();
                        card.emailLabel.Text = reader["Email"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.cityLabel.Text = reader["City"].ToString();
                        card.phoneLabel.Text = reader["Phone"].ToString();
                        card.genusLabel.Text = reader["Genus"].ToString();
                        card.languageLabel.Text = reader["Language"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.info = reader["Info"].ToString();
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Photo"]);
                        card.photoByte = data;
                        card.home = home;
                        card.pageViewerPanel = pageViewerPanel;
                        card.writersPage = this;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
        }
        private void loadPublishHouse(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [PublishHouse]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PublishHouseCard card = new PublishHouseCard();
                card.BackColor = lightColor;
                card.guna2Panel1.FillColor = lightColor;
                card.contactLabel.ForeColor = foreColor;
                card.linkLabel.ForeColor = foreColor;
                card.lightColor = lightColor;
                card.admin = admin;
                card.moderator = moderator;
                if (!search)
                {
                    if (!searchBoxSourceIsAdded)
                    {
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Certificate"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Contact"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Links"].ToString());
                        filterCombobox.Items.Add(reader["Name"]);
                    }
                    card.TopLevel = false;
                    card.fullnameLabel.Text = reader["Name"].ToString();
                    card.contactLabel.Text = reader["Contact"].ToString();
                    card.linkLabel.Text = reader["Links"].ToString();
                    card.Id = Convert.ToInt32(reader["Id"]);
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["Icon"]);
                    card.photoByte = data;
                    flowLayoutPanel1.Controls.Add(card);
                    card.Show();
                }
                else
                {
                    if (reader["Name"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Certificate"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Contact"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Links"].ToString().ToLower() == searchBox.Text.ToLower())
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString();
                        card.contactLabel.Text = reader["Contact"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Icon"]);
                        card.photoByte = data;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    if (reader["Name"].ToString() == filterCombobox.Text)
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString();
                        card.contactLabel.Text = reader["Contact"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Icon"]);
                        card.photoByte = data;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
            searchBoxSourceIsAdded = true;
        }
        private void loadPublishHouseDetails(bool search)
        {
            flowLayoutPanel1.Controls.Clear();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = ("Select * From [PublishHouse]");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PublishHouseDetailCard card = new PublishHouseDetailCard();
                card.BackColor = lightColor;
                card.guna2Panel1.FillColor = lightColor;
                card.contactLabel.ForeColor = foreColor;
                card.linkLabel.ForeColor = foreColor;
                card.guna2ShadowPanel6.FillColor = lightColor;
                card.addressLabel.ForeColor = foreColor;
                card.certificateLabel.ForeColor = foreColor;
                card.extraLabel.ForeColor = foreColor;
                card.powColor = powColor;
                card.lightColor = lightColor;
                card.foreColor = foreColor;
                card.admin = admin;
                card.moderator = moderator;
                if (!search)
                {
                    if (!searchBoxSourceIsAdded)
                    {
                        searchBox.AutoCompleteCustomSource.Add(reader["Name"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Certificate"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Contact"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Links"].ToString());
                        filterCombobox.Items.Add(reader["Name"]);
                    }
                    card.TopLevel = false;
                    card.fullnameLabel.Text = reader["Name"].ToString();
                    card.contactLabel.Text = reader["Contact"].ToString();
                    card.linkLabel.Text = reader["Links"].ToString();
                    card.Id = Convert.ToInt32(reader["Id"]);
                    card.addressLabel.Text = reader["Address"].ToString();
                    card.certificateLabel.Text = reader["Certificate"].ToString();
                    card.extraLabel.Text = reader["Extra"].ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])(reader["Icon"]);
                    card.photoByte = data;
                    card.home = home;
                    card.pageViewerPanel = pageViewerPanel;
                    card.writersPage = this;
                    flowLayoutPanel1.Controls.Add(card);
                    card.Show();
                }
                else
                {
                    if (reader["Name"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Certificate"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Contact"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Links"].ToString().ToLower() == searchBox.Text.ToLower())
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString();
                        card.contactLabel.Text = reader["Contact"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.addressLabel.Text = reader["Address"].ToString();
                        card.certificateLabel.Text = reader["Certificate"].ToString();
                        card.extraLabel.Text = reader["Extra"].ToString();
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Icon"]);
                        card.photoByte = data;
                        card.home = home;
                        card.pageViewerPanel = pageViewerPanel;
                        card.writersPage = this;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                    if (reader["Name"].ToString() == filterCombobox.Text)
                    {
                        card.TopLevel = false;
                        card.fullnameLabel.Text = reader["Name"].ToString();
                        card.contactLabel.Text = reader["Contact"].ToString();
                        card.linkLabel.Text = reader["Links"].ToString();
                        card.Id = Convert.ToInt32(reader["Id"]);
                        card.addressLabel.Text = reader["Address"].ToString();
                        card.certificateLabel.Text = reader["Certificate"].ToString();
                        card.extraLabel.Text = reader["Extra"].ToString();
                        Byte[] data = new Byte[0];
                        data = (Byte[])(reader["Icon"]);
                        card.photoByte = data;
                        card.home = home;
                        card.pageViewerPanel = pageViewerPanel;
                        card.writersPage = this;
                        flowLayoutPanel1.Controls.Add(card);
                        card.Show();
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
            searchBoxSourceIsAdded = true;
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if(searchBox.Text != string.Empty)
            {
                if (filterCombobox.Text.Length > 0)
                {
                    IssearchBoxClear = true;
                    filterCombobox.SelectedItem = default;
                }
                if (!sorting)
                {
                    if (!publishHouseMode)
                    {
                        loadWriterCard(true);
                    }
                    else
                    {
                        loadPublishHouse(true);
                    }
                }
                else
                {
                    if (!publishHouseMode)
                    {
                        loadWriterDetailsCard(true);
                    }
                    else
                    {
                        loadPublishHouseDetails(true);
                    }
                }
            }
            else
            {
                refreshButton.PerformClick();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            filterCombobox.SelectedItem = default;
            IssearchBoxClear = false;
            if (!sorting)
            {
                if (!publishHouseMode)
                {
                    loadWriterCard(false);
                }
                else
                {
                    loadPublishHouse(false);
                }
            }
            else
            {
                if (!publishHouseMode)
                {
                    loadWriterDetailsCard(false);
                }
                else
                {
                    loadPublishHouseDetails(false);
                }
            }
        }

        private void filterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sorting)
            {
                if (!publishHouseMode)
                {
                    loadWriterCard(true);
                }
                else
                {
                    loadPublishHouse(true);
                }
            }
            else
            {
                if (!publishHouseMode)
                {
                    loadWriterDetailsCard(true);
                }
                else
                {
                    loadPublishHouseDetails(true);
                }
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("usercardImages/left_60px_hover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("usercardImages/left_60px.png");

        }

        private void thumbSortButton_Click(object sender, EventArgs e)
        {
            sorting = false;
            thumbSortButton.ShadowDecoration.Enabled = true;
            listSortButton.ShadowDecoration.Enabled = false;
            if (!publishHouseMode)
            {
                loadWriterCard(false);
            }
            else
            {
                loadPublishHouse(false);
            }
        }

        private void listSortButton_Click(object sender, EventArgs e)
        {
            sorting = true;
            listSortButton.ShadowDecoration.Enabled = true;
            thumbSortButton.ShadowDecoration.Enabled = false;
            if (!publishHouseMode)
            {
                loadWriterDetailsCard(false);
            }
            else
            {
                loadPublishHouseDetails(false);
            }
        }
    }
}
