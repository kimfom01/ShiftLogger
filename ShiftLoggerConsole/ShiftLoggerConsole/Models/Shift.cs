using System.Text.Json.Serialization;

namespace ShiftLoggerConsole.Models;

public class Shift
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }
}