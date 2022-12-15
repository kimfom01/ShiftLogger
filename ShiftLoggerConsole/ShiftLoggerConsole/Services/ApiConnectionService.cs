using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using ShiftLoggerConsole.Models;

namespace ShiftLoggerConsole.Services;

public class ApiConnectionService : IApiConnectionService
{
    private readonly HttpClient _httpClient;

    public ApiConnectionService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.BaseAddress = new Uri(configuration.GetSection("BaseUrl").Value!);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Shift>> GetAllShifts()
    {
        List<Shift> shiftList = new();
        try
        {
            using (var response = await _httpClient.GetAsync(""))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                shiftList = await JsonSerializer.DeserializeAsync<List<Shift>>(stream);
        
                return shiftList;
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        return shiftList;
    }
}