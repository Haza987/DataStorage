using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IProjectManagerService
    {
        Task<bool> CreateProjectManagerAsync(ProjectManagerEntity projectManager);
        Task<bool> DeleteProjectManagerAsync(ProjectManagerEntity projectManager);
        Task<IEnumerable<ProjectManagerEntity>?> GetAllProjectManagersAsync();
        Task<ProjectManagerEntity?> GetProjectManagerAsync(Expression<Func<ProjectManagerEntity, bool>> expression);
        Task<bool> ProjectManagerExistsAsync(Expression<Func<ProjectManagerEntity, bool>> expression);
        Task<bool> UpdateProjectManagerAsync(ProjectManagerEntity projectManager);
    }
}