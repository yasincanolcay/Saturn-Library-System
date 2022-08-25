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
    public partial class AddReminder : Form
    {
        public bool editMode = false;
        string undoNote = "";
        DateTime dateValue = DateTime.Now;
        string timeValue = "";

        DateTime undodateValue = DateTime.Today;
        string undotimeValue = "...";
        public int Id = 0;
        int isRead = 0;
        public AddReminder()
        {
            InitializeComponent();
        }

        private void clearPicturebox_Click(object sender, EventArgs e)
        {
            try
            {
                undodateValue = datePicker.Value;
                undotimeValue = timePicker.Text;
                undoNote = noteBox.Text;
                timePicker.Text = timeValue;
                datePicker.Value = dateValue;
                timePicker.Text = timeValue;
                noteBox.Clear();
                undoPicturebox.Visible = true;
            }
            catch
            {
            }
        }

        private void undoPicturebox_Click(object sender, EventArgs e)
        {
            try
            {
                if (undoNote != string.Empty)
                {
                    noteBox.Text = undoNote;
                }
                undoPicturebox.Visible = false;
                datePicker.Value = undodateValue;
                timePicker.Text = undotimeValue;
            }
            catch
            {
            }
        }

        private void noteBox_TextChanged(object sender, EventArgs e)
        {
            goingto:
            try
            {
                if (noteBox.Text != string.Empty)
                {
                    clearPicturebox.Visible = true;
                }
            }
            catch 
            {
                goto goingto;
            }
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            clearPicturebox.Visible = true;
            undoPicturebox.Visible = true;
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            clearPicturebox.Visible = true;
            undoPicturebox.Visible = true;
        }

        private void AddReminder_Load(object sender, EventArgs e)
        {
            gonigto:
            try
            {
                if (editMode)
                {
                    createButton.Text = "Kaydet";
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection;
                    command.CommandText = "SELECT * From [Reminders]";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Id"]) == Id)
                        {
                            datePicker.Value = DateTime.Parse(reader["Date"].ToString());
                            timePicker.Text = reader["Time"].ToString();
                            headerBox.Text = reader["Header"].ToString();
                            noteBox.Text = reader["Note"].ToString();
                            isRead = Convert.ToInt32(reader["isRead"]);
                            dateValue = datePicker.Value;
                            timeValue = timePicker.Text;
                            undodateValue = datePicker.Value;
                            undotimeValue = timePicker.Text;
                        }
                    }
                    undoPicturebox.Visible = false;
                }
                dateValue = datePicker.Value;
                timeValue = timePicker.Text;
            }
            catch
            {
                goto gonigto;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            goingto:
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "'" + Application.StartupPath + "\\SaturnDatabase.mdf'" + ";Integrated Security=True");

                string query = "";
                if (!editMode)
                {
                    query = "INSERT INTO [Reminders] (Header,Note,Date,Time,isRead) VALUES (@header,@note,@date,@time,@isread)";
                }
                else
                {
                    query = "UPDATE Reminders SET Header=@header,Note=@note,Date=@date,Time=@time,isRead=@isread where Id=@id";
                }
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Clear();
                    if (editMode)
                        command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@header", headerBox.Text);
                    command.Parameters.AddWithValue("@note", noteBox.Text);
                    command.Parameters.AddWithValue("@date", datePicker.Value);
                    command.Parameters.AddWithValue("@time", timePicker.Text);
                    command.Parameters.AddWithValue("@isread", isRead);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                createButton.Visible = false;
                loadingProgress.Visible = true;
                loadingProgress.Start();
                loadingTimer.Enabled = true;
                loadingTimer.Start();
            }
            catch
            {
                goto goingto;
            }
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            gonigto:
            try
            {
                loadingProgress.Stop();
                loadingProgress.Visible = false;
                loadingProgress.Dispose();
                createButton.Visible = true;
                loadingTimer.Enabled = false;
                loadingTimer.Stop();
                loadingTimer.Dispose();
            }
            catch
            {
                goto gonigto;
            }
        }
    }
}
