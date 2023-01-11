using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using MySqlConnector;

// ProcessStartInfo startInfo = new ProcessStartInfo();
// startInfo.FileName = "systemctl";
// // Process.Start(startInfo.FileName);
//
//
// Console.WriteLine("Jaka usługa ci interesuje.");
// string NazwaUslugi = Console.ReadLine();
//
// Console.WriteLine("Jaka Operacja: ");
// Console.WriteLine("1. Do sprawdzenia statusu");
// Console.WriteLine("2. Start usługi");
// Console.WriteLine("3. Stop usługi");
// Console.WriteLine("4, Restart usługi");
// string operacja = Console.ReadLine();
//
// string polecenie = "";
//
// switch (operacja)
// {
//     case "1":
//         polecenie = "status";
//         break;
//     case "2":
//         polecenie = "start";
//         break;
//     case "3":
//         polecenie = "stop";
//         break;
//     case "4":
//         polecenie = "restart";
//         break;
//     default:
//         Console.WriteLine("Nieprawidłowa operacja");
//         break;
// }
//
// if (!string.IsNullOrEmpty(polecenie))
// {
//     startInfo.Arguments = $"{polecenie} {NazwaUslugi}";
//     startInfo.UseShellExecute = false;
//     startInfo.RedirectStandardOutput = true;
//     
//     Process process = Process.Start(startInfo);
//     string output = process.StandardOutput.ReadToEnd();
//     process.WaitForExit();
//     Console.WriteLine(output);
// }




string connectionString = "server=localhost;user=root;database=uslugi";
    try
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Połączono");
            // sluzy to do oczytu z bazy danych 
            MySqlCommand command = new MySqlCommand("select * from testowa", connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() });
            }
            reader.Close();
            foreach (string[] s in data)
                Console.WriteLine(string.Join("\t", s));
        }
    }  
    catch (MySqlException ex)
    {
        Console.WriteLine("Błąd połączenia: " + ex.Message);
    }

    



