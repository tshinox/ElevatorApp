using Elevator.App.AppState;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var appState = new AppState();
        var builder = new ConfigurationBuilder()
            .SetBasePath("C://Users//mraliphaswa//source//repos//Elevator.App//Elevator.App")
            .AddJsonFile("elevatorconfiguration.json", optional: false, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        HttpClient client = new HttpClient();
        var elevators = configuration.GetSection("Elevators").Get<List<string>>();
        var floors = configuration.GetSection("Floors").Get<List<List<int>>>();
        Console.WriteLine("Console API App is running.");
        Console.WriteLine("Elevator name list:");
        
        foreach(var elevator in elevators)
        {
            Console.WriteLine(elevator);
        }
        
        while (true)
        {
            Console.WriteLine("");
            Console.Write("Enter the elevator.");
            var elevator = Console.ReadLine()?.Trim();

            Console.Write("Enter the floor.");
            var floor = Console.ReadLine()?.Trim();

            try
            {
                if (floors[elevators.IndexOf(elevator)].Contains(Convert.ToInt32(floor)))
                {

                }
                else
                {
                    Console.WriteLine("Floor doesn't exist for the selected elevator.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

