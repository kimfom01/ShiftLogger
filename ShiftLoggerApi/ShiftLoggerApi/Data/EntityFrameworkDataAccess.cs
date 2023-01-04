using Microsoft.EntityFrameworkCore;
using ShiftLoggerApi.DataContext;
using ShiftLoggerApi.Dtos;

namespace ShiftLoggerApi.Data;

public class EntityFrameworkDataAccess : IDataAccess
{
    private readonly ShiftContext _shiftContext;

    public EntityFrameworkDataAccess(ShiftContext shiftContext)
    {
        _shiftContext = shiftContext;
    }

    public async Task<List<ShiftReadDto>> GetShiftsAsync()
    {
        var shifts = await _shiftContext.Shifts.ToListAsync();
        var shiftReadDtos = MapDto.MapToReadDtoList(shifts);

        return shiftReadDtos;
    }

    public async Task<ShiftReadDto?> GetShiftByIdAsync(int id)
    {
        var shift = await _shiftContext.Shifts.FirstOrDefaultAsync(x => x.Id == id);
        if (shift is null)
        {
            return null;
        }
        
        var shiftReadDto = MapDto.MapToReadDto(shift);
        return shiftReadDto;
    }

    public async Task<ShiftReadDto> AddShiftAsync(ShiftWriteDto shiftDto)
    {
        var shift = MapDto.MapFromWriteDto(shiftDto);
        await _shiftContext.AddAsync(shift);
        await _shiftContext.SaveChangesAsync();

        var shiftReadDto = MapDto.MapToReadDto(shift);
        
        return shiftReadDto;
    }

    public async Task UpdateShiftAsync(int id, ShiftUpdateDto shiftDto)
    {
        var oldShift = await _shiftContext.Shifts.FirstOrDefaultAsync(x => x.Id == id);
        if (oldShift is null)
        {
            return;
        }
        
        MapDto.MapFromUpdateDto(oldShift, shiftDto);
        await _shiftContext.SaveChangesAsync();
    }

    public async Task DeleteShiftAsync(int id)
    {
        var shift = await _shiftContext.Shifts.FirstOrDefaultAsync(x => x.Id == id);
        if (shift is null)
        {
            return;
        }

        _shiftContext.Remove(shift);
        await _shiftContext.SaveChangesAsync();
    }
}