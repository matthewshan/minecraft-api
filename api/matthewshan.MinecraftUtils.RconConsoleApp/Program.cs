using CoreRCON;
using dotenv.net;
using System.Net;
using System.Text.RegularExpressions;

DotEnv.Load();

string ip = Environment.GetEnvironmentVariable("MC_IP") ?? throw new Exception("Need MC_IP Enviroment Variable Set...");
string port = Environment.GetEnvironmentVariable("MC_RCON_PORT") ?? throw new Exception("Need MC_RCON_PORT Enviroment Variable Set...");
string pass = Environment.GetEnvironmentVariable("MC_RCON_PASSWORD") ?? throw new Exception("Need MC_RCON_PASSWORD Enviroment Variable Set...");

// Connect to a server
using var rcon = new RCON(IPAddress.Parse(ip), ushort.Parse(port), pass);
await rcon.ConnectAsync();

while (true)
{
    Console.Write("\n> ");
    string command = Console.ReadLine();
    if (command == "exit")
    {
        break;
    }
    string commandResponse = await rcon.SendCommandAsync(command);
    string cleanedCommandResponse = Regex.Replace(commandResponse, @"§[0-9a-fk-or]", "", RegexOptions.IgnoreCase);
    Console.WriteLine(cleanedCommandResponse);
}

