using Exercise2.DataValidation;
using Exercise2.Enums;

namespace Exercise2.ProgramLogic;

public class MainMenuLogic
{
    private const int MaxAge = 110;
    private const int MaxGroupSize = 10;
    private const int PrintIndexFromPosition1 = 1;
    private const int MinWords = 3;
    private int sum;
    private int[] numberOfPersons = new int[MaxGroupSize];
    private readonly Validation validation = new Validation();
    public int Age { get; set; }
    public int CheckPrice()
    {
        var validAge = validation.CheckIfInputIsValidNumber("Not a valid age, can't be 0 and not older than 110", MaxAge);

        Age = validAge;

        //I had refactored this to an switch instead of if/else, but since it was part of the assignment i leave it ;)
        if (Age < (int)AgeGroup.Child)
        {
            Console.WriteLine("You are a child and are eligible for a free ticket");
            return (int)AgeGroupPrice.Free;
        }
        else if (Age > (int)AgeGroup.Centenarian)
        {
            Console.WriteLine("You are over 100 years old and are eligible for a free ticket");
            return (int)AgeGroupPrice.Free;
        }
        else if (Age < (int)AgeGroup.Youth)
        {
            Console.WriteLine($"Youth-price: 80kr");
            return (int)AgeGroupPrice.Youth;
        }
        else if (Age > (int)AgeGroup.Pensioner)
        {
            Console.WriteLine($"Pensioner-price: 90kr");
            return (int)AgeGroupPrice.Pensioner;
        }
        else
        {
            Console.WriteLine($"Standard-price: 120kr");

        }
        return (int)AgeGroupPrice.Standard;
    }
    public int GetPrice()
    {
        int validCompany = validation.CheckIfInputIsValidNumber("Not a valid number, a company needs to be 1-10.", MaxGroupSize);
        sum = 0;//reset the total price of the company back to zero before calculating

        numberOfPersons = new int[validCompany];
        Console.Clear();
        Console.WriteLine($"{numberOfPersons.Length} are attending.");

        for (int i = 0; i < numberOfPersons.Length; i++)
        {
            Console.WriteLine($"Whats the age of the visitor nr.{i + PrintIndexFromPosition1}?");
            var price = CheckPrice();
            sum += price;
        }

        return sum;
    }

    public List<string> FindWord()
    {
        bool isTrue = false;
        string[] words;
        do
        {
            string userInput = Console.ReadLine() ?? string.Empty;
            var sentence = validation.CheckIfInputIsString(userInput);

            // Split the sentence into words using a single space as the separator and removes any additional spaces
            words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //check if the sentence is at least 3 words long
            if (words.Length < MinWords)
            {
                Console.WriteLine("The sentence need to contain at least three words, try again.");
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
    public List<string> Iteration()
    {
        string userInput = Console.ReadLine() ?? string.Empty;

        var validString = validation.CheckIfInputIsString(userInput);

        List<string> iterationList = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            iterationList.Add($"{i + PrintIndexFromPosition1}.{validString}");
        }

        return iterationList;
    }
}