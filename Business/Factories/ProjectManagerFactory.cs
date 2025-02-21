using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectManagerFactory
{
    public static ProjectManager CreateModel(ProjectManagerEntity pmEntity) => new()
    {
        Id = pmEntity.Id,
        FullName = $"{pmEntity.FirstName} {pmEntity.LastName}",
        Email = pmEntity.Email,
        PhoneNumber = pmEntity.PhoneNumber,
    };
}