namespace Data.Entities;

public class ServiceEntity
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public decimal HourlyRate { get; set; }
}
