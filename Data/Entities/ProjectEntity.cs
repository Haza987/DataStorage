using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string ProjectNumber { get; set; } = null!;
    public string ProjectName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int ProjectManagerId { get; set; }
    public ProjectManagerEntity ProjectManager { get; set; } = null!;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
}