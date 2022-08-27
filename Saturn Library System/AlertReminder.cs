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
    public partial class AlertReminder : Form
    {
        public MaterialEffect effect = new MaterialEffect();
        public int Id = 0;
        public AlertReminder()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }

        private void AlertReminder_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                string query = "UPDATE Reminders SET isRead=@read where Id=@id";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@read", 1);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
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
