namespace Presentation_ConsoleApp.Dialogues;

public class ViewChoiceDialogue(ViewAllProjects viewAllProjects, ViewAllCustomers viewAllCustomers, ViewAllProjectManagers viewAllProjectManagers, ViewAllServices viewAllServices, ViewProjectByNumberDialogue ViewProjectByNumberDialogue, ViewCustomerByIdDialogue viewCustomerByIdDialogue) 
{
    private readonly ViewAllProjects _viewAllProjects = viewAllProjects;
    private readonly ViewAllCustomers _viewAllCustomers = viewAllCustomers;
    private readonly ViewAllProjectManagers _viewAllProjectManagers = viewAllProjectManagers;
    private readonly ViewAllServices _viewAllServices = viewAllServices;
    private readonly ViewProjectByNumberDialogue _viewProjectByNumberDialogue = ViewProjectByNumberDialogue;
    private readonly ViewCustomerByIdDialogue _viewCustomerByIdDialogue = viewCustomerByIdDialogue;

    public async Task ViewChoice()
    {
        Console.Clear();
        Console.WriteLine("---------- VIEW CHOICES ----------");
        Console.WriteLine("1. View all projects");
        Console.WriteLine("2. View specific project");
        Console.WriteLine("3. View all customers");
        Console.WriteLine("4. View specific customer");
        Console.WriteLine("5. View all project managers");
        Console.WriteLine("6. View all services");
        var input = Console.ReadLine()!;

        switch (input)
        { 
            case "1":
                await _viewAllProjects.GetAllProjects();
                break;

            case "2":
                await _viewProjectByNumberDialogue.ViewProjectByNumber();
                break;

            case "3":
                await _viewAllCustomers.GetAllCustomers();               
                break;

            case "4":
                await _viewCustomerByIdDialogue.ViewCustomerById();     
                break;


            case "5":
                await _viewAllProjectManagers.GetAllProjectManagers();
                break;


            case "6":
                await _viewAllServices.GetAllServices();
                break;


            default:
                Console.WriteLine("Invalid option. Press any key to try again.");
                return;
        }
    }
}