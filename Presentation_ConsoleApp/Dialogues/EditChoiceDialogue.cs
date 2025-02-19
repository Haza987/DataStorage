namespace Presentation_ConsoleApp.Dialogues;

public class EditChoiceDialogue(FindCustomerEditDialogue findCustomerDialogue, FindProjectEditDialogue findProjectDialogue)
{
    private readonly FindCustomerEditDialogue _findCustomerDialogue = findCustomerDialogue;
    private readonly FindProjectEditDialogue _findProjectDialogue = findProjectDialogue;

    public async Task EditChoice()
    {

        Console.Clear();
        Console.WriteLine("---------- EDIT ----------");
        Console.WriteLine("What do you want to edit?");
        Console.WriteLine("1. Edit project");
        Console.WriteLine("2. Edit customer");
        Console.WriteLine("3. Go back to the main menu");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await _findCustomerDialogue.FindCustomer(true);
                break;

            case "2":
                await _findProjectDialogue.FindProject(true);
                break;

            case "3":
                Console.WriteLine("Go back to the main menu");
                break;

            default:
                Console.WriteLine("Invalid option. Press any key to try again.");
                Console.ReadKey();
                break;
        }
    }
}