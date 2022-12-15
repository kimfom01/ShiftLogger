using ShiftLoggerConsole.UI;

namespace ShiftLoggerConsole;

public class Startup : IStartup
{
    private readonly IUserInteraction _userInteraction;

    public Startup(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }
    public async Task Run()
    {
        await _userInteraction.DisplayAllShifts();
    }
}