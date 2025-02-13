using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectDto
{
    [Required]
    public string ProjectName { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public decimal TotalPrice { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int ProjectManagerId { get; set; }

    [Required]
    public int ServiceId { get; set; }
}
