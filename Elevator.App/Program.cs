using Azure;
using Elevator.App.AppState;
using Elevator.App.Models.DTOs.Requests;
using Elevator.App.Models.DTOs.Results;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class Program
{
    private static void Main(string[] args)
    {
        var appState = new AppState();
        HttpClient client = new HttpClient();
        Console.WriteLine("Elevator App is running.");
        
        while (true)
        {
            Console.Write("Enter the Building.");
            var building = Console.ReadLine()?.Trim();
            Console.Write("Enter the Elevator Name.");
            var elevatorName = Console.ReadLine()?.Trim();
            Console.Write("Enter the floor.");
            var floor = Console.ReadLine()?.Trim();
            Console.Write("Enter the .");
            var passengers = Console.ReadLine()?.Trim();
            Console.Write("Enter the floor.");
            var Weight = Console.ReadLine()?.Trim();

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public async Task<GetAvailableElevatorsResult> GetElevator(HttpClient client, int floorNo)
    {
        var response = await client.PostAsJsonAsync($"https://localhost:7029/api/Location/CallElevator?FloorNo={floorNo}",
                    new StringContent("", Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAvailableElevatorsResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
    public async Task<GetAvailableElevatorsResult> CheckPassengerLimit(HttpClient client, DestinationRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var response = await client.PostAsJsonAsync("https://localhost:7150/api/Limit/CheckPassengerLimit",
                    new StringContent(json, Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAvailableElevatorsResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
    public async Task<GetAvailableElevatorsResult> CheckWeightLimit(HttpClient client, DestinationRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var response = await client.PostAsJsonAsync("https://localhost:7150/api/Limit/CheckWeightLimit",
                    new StringContent(json, Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAvailableElevatorsResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
    public async Task<GetAvailableElevatorsResult> GetElevatorStatus(HttpClient client, string elevatorName)
    {
        var response = await client.PostAsJsonAsync($"https://localhost:7053/api/Elevator/GetElevatorStatus?ElevatorName={elevatorName}",
                    new StringContent("", Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAvailableElevatorsResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
    public async Task<GetAvailableElevatorsResult> GetElevatorDestination(HttpClient client, string elevatorName)
    {
        var response = await client.PostAsJsonAsync($"https://localhost:7053/api/Elevator/GetDestination?ElevatorName={elevatorName}",
                    new StringContent("", Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAvailableElevatorsResult>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return result;
    }
}
