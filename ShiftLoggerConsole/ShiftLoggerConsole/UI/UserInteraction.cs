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
}