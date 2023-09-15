namespace Exercise2.DataValidation;

public class Validation
{
    //Checks if the user has given us a valid number
    public int CheckIfInputIsValidNumber(string prompt, int maxNumber)
    {
        string userInput = Console.ReadLine() ?? string.Empty;

        int number;
        bool isValidInput = false;

        do
        {
            if (!int.TryParse(userInput, out number) || number <= 0 || number > maxNumber)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine() ?? string.Empty;
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
                Console.WriteLine("Cant be null or whitespace, and a word needs to be at least 2 characters, try again.");
                userInput = Console.ReadLine() ?? string.Empty;
                characters = userInput.ToCharArray();
            }
            else if (int.TryParse(userInput, out int number))
            {
                Console.WriteLine("Cant be a number, must be text try again.");
                userInput = Console.ReadLine() ?? string.Empty;
            }
            else
            {
                isTrue = true;
            }
        } while (!isTrue);

        return userInput;
    }
}