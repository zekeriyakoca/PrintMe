using System.ComponentModel.DataAnnotations;

namespace PrintMe.Application.Entities;

public class Customer
{
    [Key]
    public string Id { get; set; }
    public string FullName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}