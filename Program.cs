using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise2
{
    internal class Program
    {
        private const string menuQuit = "0";
        private const string menuAge = "1";
        private const string menuPriceForCompany = "2";
        private const string menuIterate = "3";
        private const string menuThirdWord = "4";
        private static string userInput = string.Empty;
        private static int sum;
        private static uint[] numberOfPersons = new uint[20];
        public static int Age { get; set; }


        static void Main(string[] args)
        {
            bool isTrue = false;

            do
            {
                Menu();

                userInput = Console.ReadLine()!;

                switch (userInput)
                {
                    case menuQuit:
                        isTrue = Quit();
                        break;
                    case menuAge:
                        CheckAgeGroup();
                        break;
                    case menuPriceForCompany:
                        CalculatePrice();
                        break;
                    case menuIterate:
                        Iterate();
                        break;
                    case menuThirdWord:
                        FindTheThirdWord();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, press any key to try again!");
                        Console.ReadKey();
                        break;
                }
            } while (!isTrue);
        }
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the main menu!\n");
            Console.WriteLine("To make a selection, enter the number corresponding to your choice:");
            Console.WriteLine("0. Quit!");
            Console.WriteLine("1. Check age group");
            Console.WriteLine("2. Buy cinema tickets");
            Console.WriteLine("3. Iterate 10 times");
            Console.WriteLine("4. The third word");
        }
        private static bool Quit()
        {
            bool isTrue;
            isTrue = true;
            Console.WriteLine("Goodbye :)");
            Environment.Exit(0);
            return isTrue;
        }
        private static void CheckAgeGroup()
        {
            Console.Clear();
            Console.WriteLine("What is your age?: ");
            int userInput = int.Parse(Console.ReadLine()!);
            CheckAge(userInput);
            Console.WriteLine("Press any key to return to the main menu!");
            Console.ReadKey();
        }
        public static int CheckAge(int number)
        {
            Age = number;

            if (Age < 20)
            {
                Console.WriteLine($"Youth-price: 80kr");
                return 80;
            }
            else if (Age > 64)
            {
                Console.WriteLine($"Pensioner-price: 90kr");
                return 90;
            }
            else
            {
                Console.WriteLine($"Standard-price: 120kr");

            }
            return 120;
        }
        public static void CalculatePrice()
        {
            Console.Clear();
            Console.WriteLine("How many are attending the cinema?");
            uint user = uint.Parse(Console.ReadLine()!);
            numberOfPersons = new uint[user];
            Console.Clear();
            Console.WriteLine($"{numberOfPersons.Length} are attending.");

            for (int i = 0; i < numberOfPersons.Length; i++)
            {
                Console.WriteLine($"Whats the age of the visitor nr.{i + 1}?");
                string checkAgeGroup = Console.ReadLine()!;
                int age = CheckIfInputIsValid(checkAgeGroup);
                var price = CheckAge(age);
                sum += price;
            }

            Console.WriteLine($"The total price for the company is: {sum}");
            Console.ReadKey();
        }
        private static void Iterate()
        {
            Console.Clear();
            Console.WriteLine("Write something you wanna repeat ten times.");
            string repeat = Console.ReadLine()!;

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}.{repeat}, ");
            }

            Console.ReadKey();
        }
        private static void FindTheThirdWord()
        {
            Console.Clear();
            Console.WriteLine("Write a sentence you wanna find the third word in");

            string input = Console.ReadLine()!;
            var thirdWord = input.Split(" ", input.Length);

            for (int i = 0; i < thirdWord.Length; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine(thirdWord[i]);
                }
                else
                {
                    Console.WriteLine(i + 1);
                }
            }

            Console.WriteLine("Press any key to get back to main menu");
            Console.ReadKey();
        }
        public static int CheckIfInputIsValid(string user)
        {
            int number;
            bool isValidInput = false;

            do
            {

                if (!int.TryParse(user, out number) || number <= 0 || number > 110)
                {
                    Console.WriteLine("Not a valid number, try again");
                    user = Console.ReadLine()!;
                }
                else
                {
                    isValidInput = true;
                }

            } while (!isValidInput);

            return number;
        }
    }
}