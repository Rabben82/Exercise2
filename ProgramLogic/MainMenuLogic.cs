using Exercise2.DataValidation;
using Exercise2.Enums;
using Exercise2.Interface;

namespace Exercise2.ProgramLogic;

public class MainMenuLogic
{
    private const int MaxAge = 110;
    private const int MaxGroupSize = 10;
    private const int PrintIndexFromPosition1 = 1;
    private const int MinWords = 3;

    private int sum;
    private int[] numberOfPersons = new int[MaxGroupSize];
    public int Age { get; set; }
    public Validation Validation { get; private set; }
    public UserInterface UserInterface { get; private set; }
    public MainMenuLogic(Validation validation, UserInterface userInterface)
    {
        Validation = validation;
        UserInterface = userInterface;
    }

    //Checks the price based on the age group
    public int CheckPrice()
    {
        var validAge = Validation.CheckIfInputIsValidNumber("Not a valid age, can't be 0 and not older than 110\nTry again!", MaxAge);

        Age = validAge;

        //I had refactored this to an switch instead of if/else, but since it was part of the assignment i leave it ;)
        if (Age < (int)AgeGroup.Child)
        {
            UserInterface.DisplayMessage("You are a child and are eligible for a free ticket");
            return (int)AgeGroupPrice.Free;
        }
        else if (Age > (int)AgeGroup.Centenarian)
        {
            UserInterface.DisplayMessage("You are over 100 years old and are eligible for a free ticket");
            return (int)AgeGroupPrice.Free;
        }
        else if (Age < (int)AgeGroup.Youth)
        {
            UserInterface.DisplayMessage($"Youth-price: 80kr");
            return (int)AgeGroupPrice.Youth;
        }
        else if (Age > (int)AgeGroup.Pensioner)
        {
            UserInterface.DisplayMessage($"Pensioner-price: 90kr");
            return (int)AgeGroupPrice.Pensioner;
        }
        else
        {
            UserInterface.DisplayMessage($"Standard-price: 120kr");

        }
        return (int)AgeGroupPrice.Standard;
    }

    //Get's the price of the based on the age group and people in the company
    public int GetPriceOfCompany()
    {
        int validCompany = Validation.CheckIfInputIsValidNumber("Not a valid number, a company needs to be 1-10.\nTry again!", MaxGroupSize);
        sum = 0;//reset the total price of the company back to zero before calculating

        numberOfPersons = new int[validCompany];
        UserInterface.ClearConsole();
        UserInterface.DisplayMessage($"{numberOfPersons.Length} are attending.");

        for (int i = 0; i < numberOfPersons.Length; i++)
        {
            UserInterface.DisplayMessage($"Whats the age of the visitor nr.{i + PrintIndexFromPosition1}?");
            var price = CheckPrice();
            sum += price;
        }

        return sum;
    }

    //Find the third word in a sentence inputted by the user
    public List<string> FindWord()
    {
        bool isTrue = false;
        string[] words;
        do
        {
            string userInput = UserInterface.GetUserInput();
            var sentence = Validation.CheckIfInputIsString(userInput);

            // Split the sentence into words using a single space as the separator and removes any additional spaces
            words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //check if the sentence is at least 3 words long
            if (words.Length < MinWords)
            {
                UserInterface.DisplayMessage("The sentence need to contain at least three words, try again.");
            }
            else
            {
                isTrue = true;
            }

        } while (!isTrue);


        List<string> wordsList = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {

            if (i == 2)
            {
                wordsList.Add(words[i]);
            }
            else
            {
                wordsList.Add($"{i + PrintIndexFromPosition1}");
            }
        }

        return wordsList;
    }

    //Iterates through 10times of a word that has been inputted by the user
    public List<string> Iteration()
    {
        string userInput = UserInterface.GetUserInput();

        var validString = Validation.CheckIfInputIsString(userInput);

        List<string> iterationList = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            iterationList.Add($"{i + PrintIndexFromPosition1}.{validString}");
        }

        return iterationList;
    }
}