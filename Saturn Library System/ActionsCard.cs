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
    public partial class ActionsCard : Form
    {
        private MaterialEffect effect = new MaterialEffect();

        public MaterialEffect Effect { get => effect; set => effect = value; }

        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public bool admin = false;
        public bool moderator = false;
        public ActionsCard()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Effect.Close();
            this.Close();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddUser usercard = new AddUser();
                usercard.BackColor = lightColor;
                usercard.nameTextbox.FillColor = lightColor;
                usercard.surnameBox.FillColor = lightColor;
                usercard.countryIdBox.FillColor = lightColor;
                usercard.schoolBox.FillColor = lightColor;
                usercard.phoneNumberbox.FillColor = lightColor;
                usercard.housePhoneBox.FillColor = lightColor;
                usercard.addressBox.FillColor = lightColor;
                usercard.languageBox.FillColor = lightColor;
                usercard.emailBox.FillColor = lightColor;
                usercard.Show();
                Effect.Close();
                this.Close();
            }
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddWriter writercard = new AddWriter();
                writercard.BackColor = lightColor;
                writercard.nameTextbox.FillColor = lightColor;
                writercard.surnameBox.FillColor = lightColor;
                writercard.linksBox.FillColor = lightColor;
                writercard.phoneNumberbox.FillColor = lightColor;
                writercard.genusBox.FillColor = lightColor;
                writercard.cityBox.FillColor = lightColor;
                writercard.infoBox.FillColor = lightColor;
                writercard.languageBox.FillColor = lightColor;
                writercard.emailBox.FillColor = lightColor;
                writercard.Show();
                Effect.Close();
                this.Close();
            }
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddPublishHouse publishHouse = new AddPublishHouse();
                publishHouse.BackColor = lightColor;
                publishHouse.nameTextbox.FillColor = lightColor;
                publishHouse.certificateBox.FillColor = lightColor;
                publishHouse.linksBox.FillColor = lightColor;
                publishHouse.contactBox.FillColor = lightColor;
                publishHouse.addressBox.FillColor = lightColor;
                publishHouse.infoBox.FillColor = lightColor;
                publishHouse.extraBox.FillColor = lightColor;
                publishHouse.Show();
                Effect.Close();
                this.Close();
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (admin || moderator)
            {
                AddReminder reminder = new AddReminder();
                reminder.BackColor = lightColor;
                reminder.datePicker.FillColor = powColor;
                reminder.datePicker.ForeColor = foreColor;
                reminder.timePicker.FillColor = powColor;
                reminder.timePicker.ForeColor = foreColor;
                reminder.headerBox.FillColor = powColor;
                reminder.noteBox.FillColor = powColor;
                reminder.createButton.FillColor = powColor;
                reminder.Show();
                Effect.Close();
                this.Close();
            }
        }
    }
}
