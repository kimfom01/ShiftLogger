using ShiftLoggerConsole.Models;

namespace ShiftLoggerConsole.Services;

public interface IApiConnectionService
{
    public Task<List<Shift>> GetAllShifts();
}