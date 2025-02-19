using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository projectManagerRepository) : IProjectManagerService
{
    private readonly IProjectManagerRepository _projectManagerRepository = projectManagerRepository;

    public async Task<IEnumerable<ProjectManager>?> GetAllProjectManagersAsync()
    {
        var projectEntities = await _projectManagerRepository.GetAllAsync();
        var projects = projectEntities?.Select(ProjectManagerFactory.CreateModel);
        return projects;
    }

    public async Task<ProjectManager?> GetProjectManagerByIdAsync(int id)
    {
        var projectManagerEntity = await _projectManagerRepository.GetAsync(x => x.Id == id);

        if (projectManagerEntity == null)
        {
            Console.WriteLine("Project manager not found");
            return null;
        }

        var projectManager = ProjectManagerFactory.CreateModel(projectManagerEntity);
        return projectManager;
    }
}
