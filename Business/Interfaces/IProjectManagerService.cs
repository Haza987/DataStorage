using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectManagerService
    {
        Task<IEnumerable<ProjectManager>?> GetAllProjectManagersAsync();
    }
}