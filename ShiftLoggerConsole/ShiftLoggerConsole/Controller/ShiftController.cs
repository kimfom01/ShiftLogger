using ShiftLoggerConsole.Models;
using ShiftLoggerConsole.Services;
using ShiftLoggerConsole.UI;
using ShiftLoggerConsole.UserInput;

namespace ShiftLoggerConsole.Controller;

public class ShiftController : IShiftController
{
    private readonly IApiConnectionService _apiConnectionService;
    private readonly Menus _menus;
    private readonly IInput _input;

    public ShiftController(IApiConnectionService apiConnectionService, Menus menus, IInput input)
    {
        _apiConnectionService = apiConnectionService;
        _menus = menus;
        _input = input;
    }

    public async Task Start()
    {
        _menus.DisplayMainMenu();
        var choice = _input.GetInput();
        while (choice != "c")
        {
            switch (choice)
            {
                case "a":
                    await DisplayAllShifts();
                    break;
                case "v":
                    await DisplaySingleShift();
                    break;     
                case "s":
                    await StartShift();
                    break;
                case "e":
                    await EndShift();
                    break;
                case "d":
                    await DeleteShift();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice!");
                    Continue();
                    break;
            }            
            
            _menus.DisplayMainMenu();
            choice = _input.GetInput();
        }
    }
    
    private void Continue()
    {
        Console.WriteLine("Press any Enter to continue");
        Console.ReadLine();
    }

    private async Task DisplayAllShifts()
    {
        var shifts = await _apiConnectionService.GetAllShifts();

        foreach (var shift in shifts)
        {
            Console.WriteLine(shift.Id);
            Console.WriteLine(shift.Name);
            Console.WriteLine(shift.StartTime);
            Console.WriteLine(shift.EndTime);
            Console.WriteLine(shift.Duration);
        }

        Continue();
    }

    private async Task DisplaySingleShift()
    {
        Console.WriteLine("You need to enter an id to get the shift");
        var id = _input.GetId();
        var shift = await _apiConnectionService.GetShiftById(id);
        
        // TODO: verify that shift is not null otherwise display "not found!"

        Console.WriteLine(shift.Id);
        Console.WriteLine(shift.Name);
        Console.WriteLine(shift.StartTime);
        Console.WriteLine(shift.EndTime);
        Console.WriteLine(shift.Duration);
        
        Continue();
    }

    private async Task StartShift()
    {
        Console.WriteLine("To record a shift we need a name of the staff: ");
        var name = _input.GetName();
        var shift = new Shift { Name = name, StartTime = DateTime.Now };
        await _apiConnectionService.AddShift(shift);
        
        Continue();
    }

    private async Task EndShift()
    {
        // display all shifts so user can know the id to update
        Console.WriteLine("To end a shift, we need an id");
        var id = _input.GetId();
        var shift = await _apiConnectionService.GetShiftById(id);
        shift.EndTime = DateTime.Now;
        shift.Duration = GetDuration(shift.StartTime, DateTime.Now);
        await _apiConnectionService.UpdateShift(id, shift);
        
        Continue();
    }

    private async Task DeleteShift()
    {
        Console.WriteLine("To delete a shift, we need an id");
        var id = _input.GetId();
        await _apiConnectionService.DeleteShift(id);
        
        Continue();
    }

    private string GetDuration(DateTime startTime, DateTime endTime)
    {
        var timeSpan = endTime - startTime;
        var duration = timeSpan.Hours;
        return duration.ToString();
    }
}