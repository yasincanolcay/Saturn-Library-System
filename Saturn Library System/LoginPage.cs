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
    public partial class LoginPage : Form
    {
        int users = 0;
        private bool addNewUser = false;

        public bool AddNewUser { get => addNewUser; set => addNewUser = value; }

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            if (!addNewUser)
            {
                DatabaseControl();
            }
            else
            {
                loadRegisterPage();
            }
        }
        private void DatabaseControl()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+"'"+Application.StartupPath+"\\SaturnDatabase.mdf'"+";Integrated Security=True");

            using (SqlCommand command = new SqlCommand("SELECT * From [LoginUsers]",sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users++;
                }
                reader.Close();
                sqlConnection.Close();
                if (users!=0)
                {
                    LoginCard login = new LoginCard();
                    login.TopLevel = false;
                    login.Dock = DockStyle.Fill;
                    login.page = this;
                    loginpagePanel.Controls.Clear();
                    loginpagePanel.Controls.Add(login);
                    login.Show();
                }
                else
                {
                    loadRegisterPage();
                }
            }
        }
        private void loadRegisterPage()
        {
            RegisterCard register = new RegisterCard();
            register.TopLevel = false;
            register.Dock = DockStyle.Fill;
            register.LoginPanel = loginpagePanel;
            register.AddNewUser = addNewUser;
            loginpagePanel.Controls.Clear();
            loginpagePanel.Controls.Add(register);
            register.Show();
        }
    }
}
