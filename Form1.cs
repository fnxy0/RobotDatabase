using System.Runtime.InteropServices;
namespace FinalProject
{
    public partial class Form1 : Form
    {

        private int borderSize = 2;
        public Form1()
        {
            InitializeComponent();
            CollapseMenu();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(98, 102, 244);
        }
        //Drag Form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200)
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }


        private void iconButton5_Click(object sender, EventArgs e)
        {

            addRobotsControl1.Show();
            robotsearchControl1.Hide();
            panel2.Hide();
            dashboardlabel.Hide();
            addlabel.Show();
            searchlabel.Hide();


        }
        private void iconButton4_Click(object sender, EventArgs e)
        {

            panel2.Hide();
            robotsearchControl1.Show();
            addRobotsControl1.Hide();
            dashboardlabel.Hide();
            addlabel.Hide();
            searchlabel.Show();
        }


        private void iconButton3_Click(object sender, EventArgs e)
        {
            panel2.Show();
            addRobotsControl1.Hide();
            robotsearchControl1.Hide();
            dashboardlabel.Show();
            addlabel.Hide();
            searchlabel.Hide();

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            PROVIDERSDAO providersDAO = new PROVIDERSDAO();
            label1.Text = providersDAO.getProvidersCount().ToString();
            label2.Text = providersDAO.getRobotsCount().ToString();
        }
    }
}