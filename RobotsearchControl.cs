

using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace FinalProject
{
    public partial class RobotsearchControl : UserControl
    {
        readonly string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=projectdb";
        BindingSource providersBindingSource = new BindingSource();
        BindingSource robotsBindingSource = new BindingSource();
        public RobotsearchControl()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            PROVIDERSDAO providersDAO = new PROVIDERSDAO();
            providersBindingSource.DataSource = providersDAO.getAllProviders();
            dataGridView1.DataSource = providersBindingSource;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            PROVIDERSDAO providersDAO = new PROVIDERSDAO();
            providersBindingSource.DataSource = providersDAO.searchNames(textBox1.Text);
            dataGridView1.DataSource = providersBindingSource;
        }
        bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridView dataGridView = (DataGridView)sender;
                if (dataGridView.CurrentRow != null)
                {
                    int rowClicked = dataGridView.CurrentRow.Index;
                    if (Convert.ToInt32(dataGridView.Rows[rowClicked].Cells[0].Value) > 0)
                    {

                        String imageURL = dataGridView.Rows[rowClicked].Cells[2].Value.ToString()!;
                        if (IsValidURL(imageURL))
                        {
                            pictureBox1.Show();
                            pictureBox1.Load(imageURL);
                        }
                        else pictureBox1.Hide();
                    }


                    PROVIDERSDAO providersDAO = new PROVIDERSDAO();
                    robotsBindingSource.DataSource = providersDAO.getRobotsUsingJoin((int)dataGridView.Rows[rowClicked].Cells[0].Value);
                }

                dataGridView2.DataSource = robotsBindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

            private void iconButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int rowClicked = dataGridView2.CurrentRow.Index;
                int robotID = Convert.ToInt32(dataGridView2.Rows[rowClicked].Cells[0].Value);
                PROVIDERSDAO providerDAO = new PROVIDERSDAO();

                int result = providerDAO.deleteRobot(robotID);

                MessageBox.Show(result + " deleted");

                dataGridView2.DataSource = null;
                providersBindingSource.DataSource = providerDAO.getAllProviders();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete a whole company?", "Caption", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        {
                            int rowClicked = dataGridView1.CurrentRow.Index;

                            int providerID = Convert.ToInt32(dataGridView1.Rows[rowClicked].Cells[0].Value);

                            PROVIDERSDAO providerDAO = new PROVIDERSDAO();

                            int result = providerDAO.deleteCompany(providerID);


                            System.Windows.MessageBox.Show(result + " deleted");

                            dataGridView1.DataSource = null;
                            providersBindingSource.DataSource = providerDAO.getAllProviders();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private bool isCollapsed = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Height += 50;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panel1.Height -= 50;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void trackBar_Payload_Scroll(object sender, EventArgs e)
        {
            payloadValue.Text = trackBar_Payload.Value.ToString();
        }

        private void trackBar_Reach_Scroll(object sender, EventArgs e)
        {
            ReachValue.Text = trackBar_Reach.Value.ToString();
        }

        private void trackBar_Weight_Scroll(object sender, EventArgs e)
        {
            WeightValue.Text = trackBar_Weight.Value.ToString();
        }

        private void trackBar_Price_Scroll(object sender, EventArgs e)
        {
            PriceValue.Text = trackBar_Price.Value.ToString();
        }

        public List<Robots> searchRobots()
        {
            List<Robots> returnThese = new List<Robots>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            int j = 0;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT details.id as robotID, ROBOTNAME, `PAYLOAD`, `REACH`, `WEIGHT`, `AXESNUMBER`, `ROBOTUSAGE`, TYPEROBOT, `PRICE`, providernames.ID FROM `details` JOIN TYPEOFROBOT ON typeofrobot_ID = typeofrobot.id  JOIN providernames ON providernames_ID = providernames.ID  WHERE 'PAYLOAD' <= @PAYLOAD AND 'REACH' <= @REACH AND 'WEIGHT' <= @WEIGHT AND ROBOTUSAGE LIKE @ROBOTUSAGE AND TYPE LIKE @TYPE AND PRICE <= @PRICE";
            command.Parameters.AddWithValue("@PAYLOAD", Convert.ToInt32(payloadValue.Text));
            command.Parameters.AddWithValue("@REACH", Convert.ToInt32(ReachValue.Text));
            command.Parameters.AddWithValue("@WEIGHT", Convert.ToInt32(WeightValue.Text));
            command.Parameters.AddWithValue("@ROBOTUSAGE", combobox_usage2.Text);
            command.Parameters.AddWithValue("@TYPE", combobox_type2.Text);
            command.Parameters.AddWithValue("@PRICE", Convert.ToInt32(PriceValue.Text));
            if (combobox_type2.Text == "Industrial") j = 1;
            else j = 2;
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Robots a = new Robots
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Payload = reader.GetInt32(2),
                        Reach = reader.GetInt32(3),
                        Weight = reader.GetInt32(4),
                        Axesnumber = reader.GetInt32(5),
                        RobotUsage = reader.GetString(6),
                        Type = reader.GetString(7),
                        Price = reader.GetInt32(8),
                        Companyname = reader.GetInt32(9),
                        TypeRobot = j


                    };


                    returnThese.Add(a);
                };


            }
            connection.Close();

            return returnThese;

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            robotsBindingSource.DataSource = searchRobots();
            dataGridView2.DataSource = robotsBindingSource;
        }
    }
}
