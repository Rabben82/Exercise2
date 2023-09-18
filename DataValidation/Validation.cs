using Exercise2.Interface;

namespace Exercise2.DataValidation;

public class Validation
{
    public UserInterface UserInterface { get; private set; }
    public Validation(UserInterface userInterface)
    {
        UserInterface = userInterface;
    }
    //Checks if the user has given us a valid number
    public int CheckIfInputIsValidNumber(string prompt, int maxNumber)
    {
        string userInput = UserInterface.GetUserInput();

        int number;
        bool isValidInput = false;

        do
        {
            if (!int.TryParse(userInput, out number) || number <= 0 || number > maxNumber)
            {
                UserInterface.DisplayMessage(prompt);
                userInput = UserInterface.GetUserInput();
            }

            else
            {
                isValidInput = true;
            }

        } while (!isValidInput);

        return number;
    }
    //Checks if the user has given us a correct formatted string
    public string CheckIfInputIsString(string userInput)
    {
        bool isTrue = false;
        var characters = userInput.ToCharArray();
        do
        {
            if (string.IsNullOrWhiteSpace(userInput) || characters.Length < 2)
            {
                UserInterface.DisplayMessage("Cant be null or whitespace, and a word needs to be at least 2 characters, try again.");
                userInput = UserInterface.GetUserInput();
                characters = userInput.ToCharArray();
            }
            else if (int.TryParse(userInput, out int number))
            {
                UserInterface.DisplayMessage("Cant be a number, must be text try again.");
                userInput = UserInterface.GetUserInput();
            }
            else
            {
                isTrue = true;
            }
        } while (!isTrue);

        return userInput;
    }
}