using ShiftLoggerConsole.Models;
using ShiftLoggerConsole.Services;

namespace ShiftLoggerConsole.UI;

public class UserInteraction : IUserInteraction
{
    private readonly IApiConnectionService _apiConnectionService;

    public UserInteraction(IApiConnectionService apiConnectionService)
    {
        _apiConnectionService = apiConnectionService;
    }

    public async Task DisplayAllShifts()
    {
        var shifts = await _apiConnectionService.GetAllShifts();

        foreach (var shift in shifts)
        {
            Console.WriteLine(shift.Id);
            Console.WriteLine(shift.Name);
            Console.WriteLine(shift.StartTime);
        }
    }

    public async Task DisplaySingleShift()
    {
        var shift = await _apiConnectionService.GetShiftById(2);

        Console.WriteLine(shift.Id);
        Console.WriteLine(shift.Name);
        Console.WriteLine(shift.StartTime);
    }

    public async Task AddShift()
    {
        var shift = new Shift { Name = "Joshua", StartTime = DateTime.Now };
        await _apiConnectionService.AddShift(shift);
    }

    public async Task UpdateShift()
    {
        var id = 4;
        var shift = new Shift { EndTime = DateTime.Now, Duration = "< 1hr" };
        await _apiConnectionService.UpdateShift(id, shift);
    }

    public async Task DeleteShift()
    {
        var id = 2;
        await _apiConnectionService.DeleteShift(id);
    }
}