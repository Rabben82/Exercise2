using Exercise2.Enums;
using Exercise2.ProgramLogic;

namespace Exercise2.Interface;

public class MainMenu
{
    private bool waitForKeyPress = true;
    private bool isQuitRequested = true;
    private MenuOption userInputOption;
    public UserInterface UserInterface { get; private set; }
    public MainMenuLogic MainMenuLogic { get; private set; }
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
                        isQuitRequested = Quit();
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


        } while (isQuitRequested);
    }

    public bool Quit()
    {
        isQuitRequested = false;
        UserInterface.DisplayMessage("Goodbye :)");
        Environment.Exit(0);
        return isQuitRequested;
    }
    public void CheckAgeGroup()
    {
        UserInterface.ClearConsole();
        UserInterface.DisplayMessage("What's your age?: ");
        MainMenuLogic.CheckPrice();
        UserInterface.DisplayMessage("Press any key to return to the main menu!", waitForKeyPress);
    }
    public void CalculatePrice()
    {
        UserInterface.ClearConsole();
        UserInterface.DisplayMessage("How many are attending the cinema?");
        var price = MainMenuLogic.GetPriceOfCompany();
        UserInterface.DisplayMessage($"The total price for the company is: {price}kr\nPress any key to return to the main menu.", waitForKeyPress);
    }
    public void IterateWord()
    {
        UserInterface.ClearConsole();
        UserInterface.DisplayMessage("Write something you wanna repeat ten times.");
        var result = MainMenuLogic.Iteration();
        PrintResult(result);
        UserInterface.DisplayMessage("Press any key to get back to main menu.", waitForKeyPress);
    }
    public void PrintThirdWordInSentence()
    {
        UserInterface.ClearConsole();
        UserInterface.DisplayMessage("Write a sentence you wanna find the third word in.");
        var result = MainMenuLogic.FindWord();
        PrintResult(result);
        UserInterface.DisplayMessage("\nPress any key to get back to main menu.", waitForKeyPress);
    }
    //prints the result of iterations to the console
    public void PrintResult(List<string> result)
    {
        foreach (var items in result)
        {
            UserInterface.DisplayMessage(items);
        }
    }

}