namespace Presentation_ConsoleApp.Dialogues;

public class DeleteChoiceDialogue(FindCustomerEditDialogue findCustomerDialogue, FindProjectEditDialogue findProjectDialogue)
{
    private readonly FindCustomerEditDialogue _findCustomerDialogue = findCustomerDialogue;
    private readonly FindProjectEditDialogue _findProjectDialogue = findProjectDialogue;

    public async Task DeleteChoice()
    {

        Console.Clear();
        Console.WriteLine("---------- EDIT ----------");
        Console.WriteLine("What do you want to delete?");
        Console.WriteLine("1. Delete project");
        Console.WriteLine("2. Delete customer");
        Console.WriteLine("3. Go back to the main menu");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await _findProjectDialogue.FindProject(false);
                break;

            case "2":
                await _findCustomerDialogue.FindCustomer(false);
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