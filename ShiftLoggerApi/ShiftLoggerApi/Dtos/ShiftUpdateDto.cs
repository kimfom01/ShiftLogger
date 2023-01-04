namespace ShiftLoggerApi.Dtos;

public class ShiftUpdateDto
{
    public int Id { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Duration { get; set; }
}