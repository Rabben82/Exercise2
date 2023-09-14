namespace Exercise2
{
    internal class Program
    {
        private const string menuQuit = "0";
        private static string userInput = string.Empty;
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
                        isTrue = true;
                        Console.WriteLine("Goodbye :)");
                        Environment.Exit(0);
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
        }
    }
}