using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Saturn_Library_System
{
    public partial class UserInfoDialog : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");
        public MaterialEffect effect = new MaterialEffect();
        public int Id = 0;
        bool editMode = false;
        public string updateParameter = "";
        public bool admin = false;
        public bool moderator = false;
        public UserInfoDialog()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            effect.Close();
            this.Close();
        }

        private void editPicturebox_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                Thread editThread = new Thread(new ThreadStart(editInfo));
                editThread.Start();
            }
        }
        private void editInfo()
        {
            try
            {
                if (!editMode)
                {
                    infoDetailBox.ReadOnly = false;
                    editPicturebox.Image = Image.FromFile("usercardImages/save_30px.png");
                    editMode = true;
                }
                else
                {
                    editPicturebox.Image = Image.FromFile("usercardImages/edit_50px.png");
                    editMode = false;
                    string query = "UPDATE Users SET" + " " + updateParameter + "= @parameters where Id = @id";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@parameters", infoDetailBox.Text);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    infoDetailBox.ReadOnly = true;
                }
            }
            catch
            {
                MaterialEffect effect = new MaterialEffect();
                effect.Show();
                WarningCard warning = new WarningCard();
                warning.effect = effect;
                warning.errorMode = true;
                warning.fullNameLabel.Text = "HATA";
                warning.emailLabel.Text = "Düzenleme işlemi başarısız oldu, lütfen tekrar deneyiniz.";
                warning.ShowDialog();
            }
        }

        private void UserInfoDialog_Load(object sender, EventArgs e)
        {
            if (!admin && !moderator)
            {
                editPicturebox.Visible = false;
                editPicturebox.Enabled = false;
            }
        }
    }
}