using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectEntity project);
        Task<IEnumerable<ProjectEntity>?> GetAllProjectsAsync();
        Task<ProjectEntity?> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<bool> UpdateProjectAsync(ProjectEntity project);
        Task<bool> DeleteProjectAsync(ProjectEntity project);
        Task<bool> ProjectExistsAsync(Expression<Func<ProjectEntity, bool>> expression);
    }
}