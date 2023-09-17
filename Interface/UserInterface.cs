namespace Exercise2.Interface;

public class UserInterface
{
    public string GetUserInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }
    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the main menu!\n");
        Console.WriteLine("To make a selection, enter the number corresponding to your choice:");
        Console.WriteLine("0. Quit!");
        Console.WriteLine("1. Check age group");
        Console.WriteLine("2. Buy cinema tickets");
        Console.WriteLine("3. Iterate word 10 times");
        Console.WriteLine("4. Find the third word");
    }
    public void DisplayMessage(string message, bool waitForKeyPress = false)
    {
        Console.WriteLine(message);
        if (waitForKeyPress == true)
        {
            Console.ReadKey();
        }
    }

    public void ClearConsole()
    {
        Console.Clear();
    }
}