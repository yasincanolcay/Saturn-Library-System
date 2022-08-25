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
    public partial class ForgetPassword : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public MaterialEffect effect = new MaterialEffect();
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text != string.Empty)
            {
                nextUsername();
            }
        }
        private void nextUsername()
        {
            bool isExists = false;
            int Id = 0;
            string query = "SELECT * From [LoginUsers] where UserName='" + usernameTextbox.Text + "'";
            using(SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"]);
                    isExists = true;
                }
                if (isExists)
                {
                    MaterialEffect effect2 = new MaterialEffect();
                    effect2.Show();
                    ChangePasswordPage change = new ChangePasswordPage();
                    change.Id = Id;
                    change.effect = effect2;
                    change.forgetMode = true;
                    change.ShowDialog();
                    effect.Close();
                    this.Close();
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }
    }
}
