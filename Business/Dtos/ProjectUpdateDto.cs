using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectUpdateDto
{
    public string? ProjectName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }
    public decimal? TotalPrice { get; set; }
    public int? CustomerId { get; set; }
    public int? ProjectManagerId { get; set; }
    public int? ServiceId { get; set; }
}
