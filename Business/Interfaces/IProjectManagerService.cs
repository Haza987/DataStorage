using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectManagerService
    {
        Task<IEnumerable<ProjectManager>?> GetAllProjectManagersAsync();
        Task<ProjectManager?> GetProjectManagerByIdAsync(int id);
    }
}