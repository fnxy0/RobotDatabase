using MySql.Data.MySqlClient;

namespace FinalProject
{
    public partial class AddRobotsControl : UserControl
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=projectdb";

        public AddRobotsControl()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_companyname.Text == "")
                {
                    MessageBox.Show("Company name cannot be null");
                }
                else
                {
                    PROVIDERS provider = new PROVIDERS
                    {
                        ProviderName = txt_companyname.Text,
                        ImageURL = txt_imageurl.Text
                    };


                    PROVIDERSDAO providerDAO = new PROVIDERSDAO();
                    int result = providerDAO.AddOneCompany(provider);
                    MessageBox.Show(result + " new company inserted!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void iconButton2_Click(object sender, EventArgs e)
        {
             int ident=0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * from providernames WHERE COMPANYNAME LIKE @company", connection);
            command.Parameters.AddWithValue("@company", comboBox1.Text);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                { 
                    ident = reader.GetInt32(0);
                }
            }
                connection.Close();

             try
             {
            int j = 0;
            if (comboBox2.Text == "Industrial") j = 1; 
                else j = 2;
                Robots Robot = new Robots
                {

                    Name = txt_robotname.Text,
                    Payload = Convert.ToInt32(txt_payload.Text),
                    Reach = Convert.ToInt32(txt_reach.Text),
                    Weight = Convert.ToInt32(txt_robotweight.Text),
                    Axesnumber = Convert.ToInt32(txt_axes.Text),
                    RobotUsage = txt_usage2.Text,
                    Type = comboBox2.Text,
                    Price = Convert.ToInt32(txt_price.Text),
                    Companyname = ident,
                    TypeRobot = j
                };
                PROVIDERSDAO providerDAO = new PROVIDERSDAO();
                int result = providerDAO.AddOneRobot(Robot);
                MessageBox.Show(result + " new robot inserted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `COMPANYNAME`  FROM `providernames`", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
            connection.Close();
        }
    }
}
