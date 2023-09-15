using Exercise2.Interface;
using Exercise2.ProgramLogic;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            MainMenuLogic mainMenuLogic = new MainMenuLogic();
            MainMenu mainMenu = new MainMenu(userInterface, mainMenuLogic);

            mainMenu.Run();
        }
    }
}