using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class FindProjectEditDialogue
{
    private readonly IProjectService _projectService;
    private readonly EditProjectDialogue _editDialogue;
    private readonly DeleteDialogue _deleteDialogue;

    public FindProjectEditDialogue(IProjectService projectService, EditProjectDialogue editDialogue, DeleteDialogue deleteDialogue)
    {
        _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        _editDialogue = editDialogue ?? throw new ArgumentNullException(nameof(editDialogue));
        _deleteDialogue = deleteDialogue ?? throw new ArgumentNullException(nameof(deleteDialogue));
    }

    public async Task FindProject(bool isEdit)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- FIND PROJECT TO EDIT ----------");
            Console.WriteLine("Enter the project number you are looking for in format P-000 (Or type M to return to the main menu):");
            var input = Console.ReadLine()!;

            if (input.ToUpper() == "M")
            {
                return;
            }

            if (!string.IsNullOrEmpty(input))
            {
                var project = await _projectService.GetProjectByNumberAsync(input);
                if (project != null)
                {
                    Console.WriteLine($"Project found: {project.ProjectNumber}, {project.ProjectName}");
                    Console.WriteLine("Is this the project you are trying to edit? (Y/N)");
                    var option = Console.ReadLine()!;

                    switch (option.ToUpper())
                    {
                        case "Y":
                            if (isEdit)
                            {
                                await _editDialogue.EditProject(project);
                            }
                            else
                            {
                                await _deleteDialogue.DeleteProject(project);
                            }
                            break;

                        case "N":
                            Console.Clear();
                            Console.WriteLine("---------- LOADING ----------");
                            Console.WriteLine("Returning to project finder...");
                            Console.ReadKey();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("---------- ERROR ----------");
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Project not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
            }
        }
    }
}