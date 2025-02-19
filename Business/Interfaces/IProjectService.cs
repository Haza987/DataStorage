using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectDto project);
        Task<IEnumerable<Project>?> GetAllProjectsAsync();
        Task<Project?> GetProjectByNumberAsync(string projectNumber);
        Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateDto updateDto);
        Task<bool> DeleteProjectAsync(string projectNumber);
    }
}