using ShiftLoggerApi.DataContext;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Data;

public class EntityFrameworkDataAccess : IDataAccess
{
    private readonly ShiftContext _shiftContext;

    public EntityFrameworkDataAccess(ShiftContext shiftContext)
    {
        _shiftContext = shiftContext;
    }
    
    public List<Shift> GetShifts()
    {
        throw new NotImplementedException();
    }

    public Shift GetShift(int id)
    {
        throw new NotImplementedException();
    }

    public void AddShift(Shift shift)
    {
        throw new NotImplementedException();
    }

    public void UpdateShift(int id, Shift shift)
    {
        throw new NotImplementedException();
    }

    public void DeleteShift(int id)
    {
        throw new NotImplementedException();
    }
}