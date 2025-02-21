using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    
    // Create project
    public async Task<bool> CreateProjectAsync(ProjectDto project)
    {
        await _projectRepository.BeginTransactionAsync();
        try
        {
            if(await _projectRepository.ExistsAsync(x => x.ProjectName == project.ProjectName))
            {
                Console.WriteLine("Project name already exists");
                return false;
            }

            // This get the last project number
            var highestPN = await _projectRepository.GetAllAsync();
            var lastPN = highestPN!
                .Select(x => int.Parse(x.ProjectNumber.Substring(2)))
                .DefaultIfEmpty(100)
                .Max();

            // This increments and formats the project number
            var nextPN = lastPN + 1;
            var newPN = $"P-{nextPN}";

            // This creates the new project entity with the new project number
            var projectEntity = ProjectFactory.CreateEntity(project);
            projectEntity.ProjectNumber = newPN;

            // This saves the project. 
            var result = await _projectRepository.CreateAsync(projectEntity);
            await _projectRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create project {ex.Message}");
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }

    // Read all projects
    public async Task<IEnumerable<Project>?> GetAllProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAllAsync();
        var projects = projectEntities?.Select(ProjectFactory.CreateModel);
        return projects;
    }

    // Read one project
    public async Task<Project?> GetProjectByNumberAsync(string projectNumber)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);

        if (projectEntity == null)
        {
            Console.WriteLine("Project not found");
            return null;
        }

        var project = ProjectFactory.CreateModel(projectEntity);
        return project;
    }

    // Update project
    public async Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateDto updateDto)
    {
        await _projectRepository.BeginTransactionAsync();
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);

        if (projectEntity == null)
        {
            Console.WriteLine("Project not found");
            return false;
        }

        try
        {
            projectEntity = ProjectFactory.Update(projectEntity, updateDto);
            var result = await _projectRepository.UpdateAsync(projectEntity);
            await _projectRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update project {ex.Message}");
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }

    // Delete project
    public async Task<bool> DeleteProjectAsync(string projectNumber)
    {
        await _projectRepository.BeginTransactionAsync();
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);

        if (projectEntity == null)
        {
            Console.WriteLine("Project not found");
            return false;
        }

        try
        {
            var result = await _projectRepository.DeleteAsync(projectEntity);
            await _projectRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete project {ex.Message}");
            await _projectRepository.RollbackTransactionAsync();
            return false;
        }
    }
}