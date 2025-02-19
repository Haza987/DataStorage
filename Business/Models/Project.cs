namespace Business.Models;

public class Project
{
    public string ProjectNumber { get; set; } = null!;
    public string ProjectName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public int ProjectManagerId { get; set; }
    public int ServiceId { get; set; }
}
