using Exercise2.Enums;
using Exercise2.ProgramLogic;

namespace Exercise2.Interface;

public class MainMenu
{
    private bool isTrue = true;
    private MenuOption userInputOption;
    public UserInterface UserInterface { get; private set; }
    public MainMenuLogic MainMenuLogic { get; set; }
    public MainMenu(UserInterface userInterface, MainMenuLogic mainMenuLogic)
    {
        UserInterface = userInterface;
        MainMenuLogic = mainMenuLogic;
    }

    public void Run()
    {
        do
        {
            UserInterface.DisplayMenu();

            string userInput = UserInterface.GetUserInput();

            if (Enum.TryParse(userInput, out userInputOption))
            {
                switch (userInputOption)
                {
                    case MenuOption.Quit:
                        isTrue = Quit();
                        break;
                    case MenuOption.CheckAgeGroup:
                        CheckAgeGroup();
                        break;
                    case MenuOption.CalculatePriceForGroup:
                        CalculatePrice();
                        break;
                    case MenuOption.IterateWord:
                        IterateWord();
                        break;
                    case MenuOption.FindTheThirdWord:
                        PrintThirdWordInSentence();
                        break;
                    default:
                        UserInterface.DisplayMessage("Wrong input, you need to enter a value that matches the menu!");
                        break;
                }
            }
            else
            {
                UserInterface.DisplayMessage("Wrong input, you need to enter a value that matches the menu!\nPress any key to continue...");
            }


        } while (isTrue);
    }

    public bool Quit()
    {
        isTrue = false;
        Console.WriteLine("Goodbye :)");
        Environment.Exit(0);
        return isTrue;
    }
    public void CheckAgeGroup()
    {
        Console.Clear();
        Console.WriteLine("What is your age?: ");
        MainMenuLogic.CheckPrice();
        Console.WriteLine("Press any key to return to the main menu!");
        Console.ReadKey();
    }
    public void CalculatePrice()
    {
        Console.Clear();
        Console.WriteLine("How many are attending the cinema?");
        var price = MainMenuLogic.GetPrice();
        Console.WriteLine($"The total price for the company is: {price}");
        Console.ReadKey();
    }
    public void IterateWord()
    {
        Console.Clear();
        Console.WriteLine("Write something you wanna repeat ten times.");
        var result = MainMenuLogic.Iteration();
        PrintResult(result);
        Console.WriteLine("Press any key to get back to main menu.");
        Console.ReadKey();
    }
    public void PrintThirdWordInSentence()
    {
        Console.Clear();
        Console.WriteLine("Write a sentence you wanna find the third word in.");
        var result = MainMenuLogic.FindWord();
        PrintResult(result);
        Console.WriteLine("\nPress any key to get back to main menu.");
        Console.ReadKey();
    }

    public void PrintResult(List<string> result)
    {
        foreach (var items in result)
        {
            Console.WriteLine(items);
        }
    }

}