namespace Presentation_ConsoleApp.Dialogues;

public class EditDeleteChoiceDialogue(EditChoiceDialogue editChioceDialogue, DeleteChoiceDialogue deleteChoiceDialogue)
{
    private readonly EditChoiceDialogue _editChioceDialogue = editChioceDialogue;
    private readonly DeleteChoiceDialogue _deleteChoiceDialogue = deleteChoiceDialogue;

    public async Task EditOrDelete()
    {
        Console.Clear();
        Console.WriteLine("---------- EDIT OR DELETE ----------");

        Console.WriteLine("What do you want to do? Edit or delete.");
        Console.WriteLine("1. Edit");
        Console.WriteLine("2. Delete");
        Console.WriteLine("3. Go back to the main menu");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1":
                await _editChioceDialogue.EditChoice();
                break;

            case "2":
                await _deleteChoiceDialogue.DeleteChoice();
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
