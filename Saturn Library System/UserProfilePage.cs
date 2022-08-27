using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Saturn_Library_System
{
    public partial class UserProfilePage : Form
    {
        //USERS MOUSE CONTROLS

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);



        private const int MOUSEEVENTF_LEFTDOWN = 0x02;

        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;

        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public Panel usersPanel = new Panel();
        public UsersPage page = new UsersPage();
        public bool sortingChange = false;
        public bool isBlocked = false;
        public Color powColor = Color.FromArgb(239, 181, 71);
        public Color lightColor = Color.FromArgb(243, 198, 114);
        public Color foreColor = Color.SaddleBrown;
        public UserProfilePage()
        {
            InitializeComponent();
        }
        
        private void UserProfilePage_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = lightColor;
            detailPanel.BackColor = lightColor;
            levelStarPanel.FillColor = lightColor;
            profilecardShadowPanel.FillColor = lightColor;
            rankPanel.FillColor = lightColor;
            schoolPanel.FillColor = lightColor;
            totalblockPanel.FillColor = lightColor;
            totalbookPanel.FillColor = lightColor;
            totalgivePanel.FillColor = lightColor;
            totallatePanel.FillColor = lightColor;
            totallossPanel.FillColor = lightColor;
            totalpagePanel.FillColor = lightColor;
            trustPanel.FillColor = lightColor;
            usersPanel.BackColor = lightColor;
        }
        private void backPicturebox_Click(object sender, EventArgs e)
        {
            usersPanel.Controls.Clear();
            usersPanel.Controls.Add(page);
            guna2Transition1.Show(page);
        }

        private void morePicturebox_Click(object sender, EventArgs e)
        {
            MouseRightClick();
        }
        public void MouseRightClick()
        {

            int X = Cursor.Position.X;

            int Y = Cursor.Position.Y;

            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Convert.ToUInt32(X), Convert.ToUInt32(Y), 0, 0);
        }

        private void backPicturebox_MouseHover(object sender, EventArgs e)
        {
            backPicturebox.Image = Image.FromFile("usercardImages/left_60px_hover.png");
        }

        private void backPicturebox_MouseLeave(object sender, EventArgs e)
        {
            backPicturebox.Image = Image.FromFile("usercardImages/left_60px.png");

        }
    }
}
