using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository ProjectManagerRepository) : IProjectManagerService
{
    private readonly IProjectManagerRepository _projectManagerRepository = ProjectManagerRepository;

    public async Task<bool> CreateProjectManagerAsync(ProjectManagerEntity projectManager)
    {
        return await _projectManagerRepository.CreateAsync(projectManager);
    }

    public async Task<IEnumerable<ProjectManagerEntity>?> GetAllProjectManagersAsync()
    {
        return await _projectManagerRepository.GetAllAsync();
    }

    public async Task<ProjectManagerEntity?> GetProjectManagerAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        return await _projectManagerRepository.GetAsync(expression);
    }

    public async Task<bool> UpdateProjectManagerAsync(ProjectManagerEntity projectManager)
    {
        return await _projectManagerRepository.UpdateAsync(projectManager);
    }

    public async Task<bool> DeleteProjectManagerAsync(ProjectManagerEntity projectManager)
    {
        return await _projectManagerRepository.DeleteAsync(projectManager);
    }

    public async Task<bool> ProjectManagerExistsAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        return await _projectManagerRepository.ExistsAsync(expression);
    }
}
