using Exercise2.DataValidation;
using Exercise2.Interface;
using Exercise2.ProgramLogic;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            Validation validation = new Validation(userInterface);
            MainMenuLogic mainMenuLogic = new MainMenuLogic(validation, userInterface);
            MainMenu mainMenu = new MainMenu(userInterface, mainMenuLogic);

            mainMenu.Run();
        }
    }
}