using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Data;

public interface IDataAccess
{
    public List<Shift> GetShifts();
    public Shift GetShift(int id);
    public void AddShift(Shift shift);
    public void UpdateShift(int id, Shift shift);
    public void DeleteShift(int id);
}