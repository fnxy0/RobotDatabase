using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;


namespace FinalProject
{
    internal class PROVIDERSDAO
    {
        readonly string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=projectdb";
        public List<PROVIDERS> getAllProviders()
        {
            List<PROVIDERS> returnThese = new List<PROVIDERS>();

            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM PROVIDERNAMES", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PROVIDERS a = new PROVIDERS
                    {
                        ID = reader.GetInt32(0),
                        ProviderName = reader.GetString(1),
                        ImageURL = reader.GetString(2)


                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;

        }
        public List<PROVIDERS> searchNames(string searchTerm)
        {
            List<PROVIDERS> returnThese = new List<PROVIDERS>();

            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            String searchWildPhrase = "%" + searchTerm + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM PROVIDERNAMES WHERE COMPANYNAME LIKE @search";
            command.Parameters.AddWithValue("@search", searchWildPhrase);
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PROVIDERS a = new PROVIDERS
                    {
                        ID = reader.GetInt32(0),
                        ProviderName = reader.GetString(1),
                        ImageURL = reader.GetString(2),


                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;

        }
        internal int AddOneCompany(PROVIDERS company)
        {


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `providernames`( `COMPANYNAME`, `IMAGE_LINK`) VALUES (@name, @IMAGELINK)", connection);


            command.Parameters.AddWithValue("@name", company.ProviderName);
            command.Parameters.AddWithValue("@IMAGELINK", company.ImageURL);

            int newRows = command.ExecuteNonQuery();
            connection.Close();
            return newRows;



        }

        public List<Robots> getDetails(int providerID)
        {
            List<Robots> returnThese = new List<Robots>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM DETAILS WHERE providernames_ID = @providernamesid";
            command.Parameters.AddWithValue("@providernamesid", providerID);
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Robots r = new Robots
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Payload = reader.GetInt32(2),
                        Reach = reader.GetInt32(3),
                        Weight = reader.GetInt32(4),
                        Axesnumber = reader.GetInt32(5),
                        RobotUsage = reader.GetString(6),
                        Type = reader.GetString(7),
                        Price = reader.GetInt32(8)

                    };
                    returnThese.Add(r);
                }
            }
            connection.Close();

            return returnThese;
        }

        public List<JObject> getRobotsUsingJoin(int providerID)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT details.ID as robotID, COMPANYNAME, TYPEROBOT, ROBOTNAME, `PAYLOAD`, `REACH`, `WEIGHT`, `AXESNUMBER`, `ROBOTUSAGE`, details.TYPE, `PRICE`  FROM `details` JOIN TYPEOFROBOT ON typeofrobot_ID = typeofrobot.id  JOIN providernames ON providernames_ID = providernames.ID WHERE providernames_ID = @providerID";
            command.Parameters.AddWithValue("@providerID", providerID);
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    JObject newRobot = new JObject();

                    for(int i=0;i< reader.FieldCount;i++)
                    {
                        newRobot.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                   
                    returnThese.Add(newRobot);
                }
            }
            connection.Close();

            return returnThese;
        }

        internal int deleteRobot(int robotID)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM details WHERE `details`.`ID` = @robotID;", connection);


            command.Parameters.AddWithValue("@robotID", robotID);
            

            int result = command.ExecuteNonQuery();
            connection.Close(); 
            return result;
        }

        internal int deleteCompany(int providerID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM providernames WHERE `providernames`.`ID` = @providerID;", connection);


                command.Parameters.AddWithValue("@providerID", providerID);


                int result = command.ExecuteNonQuery();
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            

        }

        internal int AddOneRobot(Robots Robot)
        {


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            
            MySqlCommand command = new MySqlCommand("INSERT INTO details( ROBOTNAME, PAYLOAD, REACH, WEIGHT, AXESNUMBER, ROBOTUSAGE, TYPE, PRICE, providernames_ID, typeofrobot_ID) VALUES (@robotname, @payload, @reach, @weight, @axes, @usage, @type, @price, @providerID, @typeofrobot)", connection);


            command.Parameters.AddWithValue("@robotname", Robot.Name);
            command.Parameters.AddWithValue("@payload", Robot.Payload);
            command.Parameters.AddWithValue("@reach", Robot.Reach);
            command.Parameters.AddWithValue("@weight", Robot.Weight);
            command.Parameters.AddWithValue("@axes", Robot.Axesnumber);
            command.Parameters.AddWithValue("@usage", Robot.RobotUsage);
            command.Parameters.AddWithValue("@type", Robot.Type);
            command.Parameters.AddWithValue("@price", Robot.Price);
            command.Parameters.AddWithValue("@providerID", Robot.Companyname);
            command.Parameters.AddWithValue("@typeofrobot", Robot.TypeRobot);
               


            int newRows = command.ExecuteNonQuery();
            connection.Close();
            return newRows;



        }

        public int getProvidersCount()
        {
            int nrProviders =0;

            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM PROVIDERNAMES", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    nrProviders++;

                }
            }
            connection.Close();

            return nrProviders;

        }

        public int getRobotsCount()
        {
            int nrRobots = 0;

            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM DETAILS", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    nrRobots++;

                }
            }
            connection.Close();

            return nrRobots;

        }

       
    }
}

