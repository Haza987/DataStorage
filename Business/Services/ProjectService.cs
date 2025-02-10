using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<bool> CreateProjectAsync(ProjectEntity project)
    {
        return await _projectRepository.CreateAsync(project);
    }

    public async Task<IEnumerable<ProjectEntity>?> GetAllProjectsAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<ProjectEntity?> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _projectRepository.GetAsync(expression);
    }

    public async Task<bool> UpdateProjectAsync(ProjectEntity project)
    {
        return await _projectRepository.UpdateAsync(project);
    }

    public async Task<bool> DeleteProjectAsync(ProjectEntity project)
    {
        return await _projectRepository.DeleteAsync(project);
    }

    public async Task<bool> ProjectExistsAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _projectRepository.ExistsAsync(expression);
    }
}
