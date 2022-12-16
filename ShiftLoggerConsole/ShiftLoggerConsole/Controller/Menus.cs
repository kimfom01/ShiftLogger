namespace ShiftLoggerConsole.UI;

public class Menus
{
    public void DisplayMainMenu()
    {
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("---------------------------\n");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("v to View All Shifts");
        Console.WriteLine("r to Record a Shift");
        Console.WriteLine("u to Update a Shift End Time");
        Console.WriteLine("d to Delete a Shift");
        Console.WriteLine("c to Close Application\n");
        Console.WriteLine("Enter choice and hit Enter");
        Console.Write("Your choice? ");
    }
}