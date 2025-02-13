using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerDto
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;
}
