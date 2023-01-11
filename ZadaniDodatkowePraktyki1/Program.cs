﻿using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using MySqlConnector;
using ZadaniDodatkowePraktyki1;

ProcessStartInfo startInfo = new ProcessStartInfo();
startInfo.FileName = "systemctl";
Process.Start(startInfo.FileName);


Console.WriteLine("Jaka usługa ci interesuje.");
string NazwaUslugi = Console.ReadLine();

Console.WriteLine("Jaka Operacja: ");
Console.WriteLine("1. Do sprawdzenia statusu");
Console.WriteLine("2. Start usługi");
Console.WriteLine("3. Stop usługi");
Console.WriteLine("4, Restart usługi");
string operacja = Console.ReadLine();

string polecenie = "";

switch (operacja)
{
    case "1":
        polecenie = "status";
        break;
    case "2":
        polecenie = "start";
        break;
    case "3":
        polecenie = "stop";
        break;
    case "4":
        polecenie = "restart";
        break;
    default:
        Console.WriteLine("Nieprawidłowa operacja");
        break;
}

if (!string.IsNullOrEmpty(polecenie))
{
    startInfo.Arguments = $"{polecenie} {NazwaUslugi}";
    startInfo.UseShellExecute = false;
    startInfo.RedirectStandardOutput = true;

    Process process = Process.Start(startInfo);
    string output = process.StandardOutput.ReadToEnd();
            var processorName = output.Split('\n');
    foreach (var VARIABLE in COLLECTION)
    {
        
    }
    process.WaitForExit();
    Console.WriteLine(output);
}

Database database = new Database();
database.database();



    



