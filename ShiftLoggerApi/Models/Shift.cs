using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApi.Models;

public class Shift
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; } = null;
    public string? Duration { get; set; } = null;
}