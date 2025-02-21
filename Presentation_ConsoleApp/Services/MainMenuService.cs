using Presentation_ConsoleApp.Dialogues;
using Presentation_ConsoleApp.Interfaces;

namespace Presentation_ConsoleApp.Services;

public class MainMenuService(
    AddProjectDialogue addProjectDialogue,
    AddCustomerDialogue addCustomerDialogue,
    ViewChoiceDialogue viewChoiceDialogue,
    EditDeleteChoiceDialogue editDeleteChoiceDialogue,
    ExitDialogue exitDialogue) : IMainMenuService
{
    private readonly AddProjectDialogue _addProjectDialogue = addProjectDialogue;
    private readonly AddCustomerDialogue _addCustomerDialogue = addCustomerDialogue;
    private readonly ViewChoiceDialogue _viewChoiceDialogue = viewChoiceDialogue;
    private readonly EditDeleteChoiceDialogue _editDeleteChoiceDialogue = editDeleteChoiceDialogue;
    private readonly ExitDialogue _exitDialogue = exitDialogue;

    public async Task MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------ Main Menu ------");
            Console.WriteLine("1. Add new project");
            Console.WriteLine("2. Add new customer");
            Console.WriteLine("3. Browse records");
            Console.WriteLine("4. Edit projects and customers");
            Console.WriteLine("5. Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _addProjectDialogue.AddProject();
                    break;

                case "2":
                    await _addCustomerDialogue.AddCustomer();
                    break;

                case "3":
                    await _viewChoiceDialogue.ViewChoice();
                    break;

                case "4":
                    await _editDeleteChoiceDialogue.EditOrDelete();
                    break;

                case "5":
                    _exitDialogue.ExitApp();
                    return;

                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}