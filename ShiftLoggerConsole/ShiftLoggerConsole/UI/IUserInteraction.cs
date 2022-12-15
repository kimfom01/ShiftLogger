namespace ShiftLoggerConsole.UI;

public interface IUserInteraction
{
    public Task DisplayAllShifts();
    public Task DisplaySingleShift();
    public Task AddShift();
    public Task UpdateShift();
    public Task DeleteShift();
}