using System.Diagnostics;
using MySqlConnector;


namespace ZadaniDodatkowePraktyki1;

public class Database
{
    string bazadanych = "uslugi";
    string connectionString = "server=localhost;user=root;database=uslugi";

    public void database()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connect to database " + bazadanych + "!\n");
                // sluzy to do oczytu z bazy danych -----------------------------------------------------------
                MySqlCommand command = new MySqlCommand("select * from testowa", connection);
                MySqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[]
                        { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() });
                }

                reader.Close();
                foreach (string[] s in data)
                    Console.WriteLine(string.Join("\t", s));
                //-----------------------------------------------------------------------------------------

                //WCZYTYWANIE TABELI -----------------------------------------------------------------------
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("No Connect to Mysql: " +"/n"+ ex.Message);
        }
    }
}
