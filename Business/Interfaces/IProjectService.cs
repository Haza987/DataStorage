using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

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