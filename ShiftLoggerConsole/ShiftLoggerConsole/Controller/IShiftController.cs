namespace ShiftLoggerConsole.UI;

public interface IShiftController
{
    public Task DisplayAllShifts();
    public Task DisplaySingleShift();
    public Task AddShift();
    public Task UpdateShift();
    public Task DeleteShift();
}