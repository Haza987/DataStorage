using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity CreateEntity(ProjectDto projectDto) => new()
    {
        ProjectName = projectDto.ProjectName,
        StartDate = projectDto.StartDate,
        EndDate = projectDto.EndDate,
        Status = projectDto.Status,
        TotalPrice = projectDto.TotalPrice,
        CustomerId = projectDto.CustomerId,
        ProjectManagerId = projectDto.ProjectManagerId,
        ServiceId = projectDto.ServiceId
    };

    public static Project CreateModel(ProjectEntity projectEntity)
    {
        return new Project
        {
            ProjectNumber = projectEntity.ProjectNumber,
            ProjectName = projectEntity.ProjectName,
            StartDate = projectEntity.StartDate,
            EndDate = projectEntity.EndDate,
            Status = projectEntity.Status,
            TotalPrice = projectEntity.TotalPrice,
            CustomerId = projectEntity.CustomerId,
            ProjectManagerId = projectEntity.ProjectManagerId,
            ServiceId = projectEntity.ServiceId
        };
    }

    // GitHub Copilot helped me with this method so that the user can update the fields if they want to.
    // If the fields are left blank then the original values will be used.
    public static ProjectEntity Update(ProjectEntity projectEntity, ProjectUpdateDto projectUpdateDto)
    {
        projectEntity.ProjectName = projectUpdateDto.ProjectName ?? projectEntity.ProjectName;
        projectEntity.StartDate = projectUpdateDto.StartDate ?? projectEntity.StartDate;
        projectEntity.EndDate = projectUpdateDto.EndDate ?? projectEntity.EndDate;
        projectEntity.Status = projectUpdateDto.Status ?? projectEntity.Status;
        projectEntity.TotalPrice = projectUpdateDto.TotalPrice ?? projectEntity.TotalPrice;
        projectEntity.CustomerId = projectUpdateDto.CustomerId ?? projectEntity.CustomerId;
        projectEntity.ProjectManagerId = projectUpdateDto.ProjectManagerId ?? projectEntity.ProjectManagerId;
        projectEntity.ServiceId = projectUpdateDto.ServiceId ?? projectEntity.ServiceId;

        return projectEntity;
    }
}