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
    public partial class ReminderPage : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public bool admin = false;
        public bool moderator = false;
        bool sorting = false;
        bool isLoadFilter = false;
        bool IssearchBoxClear = false;
        int where = 0;
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public ReminderPage()
        {
            InitializeComponent();
        }

        private void ReminderPage_Load(object sender, EventArgs e)
        {
            loadAllReminder(false);
        }
        private void loadAllReminder(bool search)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = ("Select * From [Reminders]");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!sorting)
                    {
                        where = Convert.ToInt32(reader["isRead"]);
                    }
                    else
                    {
                        where = 0;
                    }
                    if (!isLoadFilter)
                    {
                        searchBox.AutoCompleteCustomSource.Add(reader["Header"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(DateTime.Parse(reader["Date"].ToString()).Month.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Day.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Year.ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Note"].ToString());
                        searchBox.AutoCompleteCustomSource.Add(reader["Time"].ToString());
                        filterCombobox.Items.Add(reader["Header"].ToString());
                    }
                    ReminderCard card = new ReminderCard();
                    card.TopLevel = false;
                    card.guna2Panel1.FillColor = lightColor;
                    card.BackColor = lightColor;
                    card.noteLabel.ForeColor = foreColor;
                    card.powColor = powColor;
                    card.lightColor = lightColor;
                    card.foreColor = foreColor;
                    card.admin = admin;
                    card.moderator = moderator;
                    if (Convert.ToInt32(reader["isRead"]) == 0)
                    {
                        card.statuLabel.Text = "Aktif";
                        card.statuLabel.ForeColor = Color.ForestGreen;
                    }
                    if (where == Convert.ToInt32(reader["isRead"]))
                    {
                        if (!search)
                        {
                            card.Id = Convert.ToInt32(reader["Id"]);
                            card.headerLabel.Text = reader["Header"].ToString();
                            card.dateChip.Text = DateTime.Parse(reader["Date"].ToString()).Month.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Day.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Year.ToString();
                            card.timeChip.Text = reader["Time"].ToString();
                            card.noteLabel.Text = reader["Note"].ToString();
                            flowLayoutPanel1.Controls.Add(card);
                            card.Show();
                        }
                        else
                        {
                            if (reader["Header"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Note"].ToString().ToLower() == searchBox.Text.ToLower() || reader["Date"].ToString().ToLower() == searchBox.Text.ToLower())
                            {
                                card.Id = Convert.ToInt32(reader["Id"]);
                                card.headerLabel.Text = reader["Header"].ToString();
                                card.dateChip.Text = DateTime.Parse(reader["Date"].ToString()).Month.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Day.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Year.ToString();
                                card.timeChip.Text = reader["Time"].ToString();
                                card.noteLabel.Text = reader["Note"].ToString();
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                            }
                            else if (filterCombobox.Text == reader["Header"].ToString() && filterCombobox.Text != string.Empty)
                            {
                                card.Id = Convert.ToInt32(reader["Id"]);
                                card.headerLabel.Text = reader["Header"].ToString();
                                card.dateChip.Text = DateTime.Parse(reader["Date"].ToString()).Month.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Day.ToString() + "/" + DateTime.Parse(reader["Date"].ToString()).Year.ToString();
                                card.timeChip.Text = reader["Time"].ToString();
                                card.noteLabel.Text = reader["Note"].ToString();
                                flowLayoutPanel1.Controls.Add(card);
                                card.Show();
                            }
                        }
                    }
                }
                reader.Close();
                sqlConnection.Close();
                isLoadFilter = true;
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text != string.Empty)
            {
                if (filterCombobox.Text.Length > 0)
                {
                    IssearchBoxClear = true;
                    filterCombobox.SelectedItem = default;
                }
                loadAllReminder(true);
            }
            else
            {
                refreshButton.PerformClick();
            }
        }

        private void filterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0 && !IssearchBoxClear)
            {
                searchBox.Clear();
            }
            loadAllReminder(true);
            IssearchBoxClear = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            filterCombobox.SelectedItem = default;
            loadAllReminder(false);
        }

        private void listSortButton_Click(object sender, EventArgs e)
        {
            if (sorting)
            {
                sorting = false;
                listSortButton.ShadowDecoration.Enabled = false;
            }
            else
            {
                sorting = true;
                listSortButton.ShadowDecoration.Enabled = true;
                listSortButton.ShadowDecoration.Color = foreColor;
            }
            loadAllReminder(false);
        }
    }
}
