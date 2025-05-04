using Elevator.App.AppState;
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static void Main(string[] args)
    {
        var appState = new AppState();
        var builder = new ConfigurationBuilder()
            .SetBasePath("C://Users//mraliphaswa//source//repos//Elevator.App//Elevator.App")
            .AddJsonFile("elevatorconfiguration.json", optional: false, reloadOnChange: true);
        IConfiguration configuration = builder.Build();

        var elevators = configuration.GetSection("Elevators").Get<List<string>>();
        var floors = configuration.GetSection("Floors").Get<List<List<int>>>();
        Console.WriteLine("Console API App is running.");

        while (true)
        {
            Console.Write("Enter the floor.");
            var input = Console.ReadLine()?.Trim();

            switch (input?.ToLower())
            {
                case "status":
                    Console.WriteLine($"Current status: {appState.Status}");
                    break;
                case "set":
                    Console.Write("Enter new status: ");
                    var newStatus = Console.ReadLine();
                    appState.Status = newStatus ?? "";
                    Console.WriteLine("Status updated.");
                    break;
                case "help":
                    Console.WriteLine("Commands: status, set, quit");
                    break;
                case "quit":
                    Console.WriteLine("Shutting down...");
                    return;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for available commands.");
                    break;
            }
        }
    }
}

