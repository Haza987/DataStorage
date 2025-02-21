namespace Presentation_ConsoleApp.Dialogues;

public class ExitDialogue
{
    public void ExitApp()
    {
        Console.Clear();
        Console.WriteLine("-------- EXIT APPLICATION --------\n");
        Console.WriteLine("Are you sure you want to exit the application? (Y/N)");
        var option = Console.ReadLine();

        switch (option!.ToUpper())
        {
            case "Y":
                Environment.Exit(0);
                break;

            case "N":
                break;

            default:
                Console.Clear();
                Console.WriteLine("Invalid option. Please try again.");
                Console.ReadKey();
                break;
        }

    }
}