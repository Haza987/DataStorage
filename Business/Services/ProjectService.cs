using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    // Create project
    public async Task<bool> CreateProjectAsync(ProjectDto project)
    {
        try
        {
            if(await _projectRepository.ExistsAsync(x => x.ProjectName == project.ProjectName))
            {
                Debug.WriteLine("Project name already exists");
                return false;
            }

            var projectEntity = ProjectFactory.CreateEntity(project);

            var result = await _projectRepository.CreateAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
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
            Debug.WriteLine("Project not found");
            return null;
        }

        var project = ProjectFactory.CreateModel(projectEntity);
        return project;
    }

    // Update project
    public async Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateDto updateDto)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);

        if (projectEntity == null)
        {
            Debug.WriteLine("Project not found");
            return false;
        }

        try
        {
            projectEntity = ProjectFactory.Update(projectEntity, updateDto);
            var result = await _projectRepository.UpdateAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to update project {ex.Message}");
            return false;
        }
    }

    // Delete project
    public async Task<bool> DeleteProjectAsync(string projectNumber)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);

        if (projectEntity == null)
        {
            Debug.WriteLine("Project not found");
            return false;
        }

        var result = await _projectRepository.DeleteAsync(projectEntity);
        return result;
    }
}
