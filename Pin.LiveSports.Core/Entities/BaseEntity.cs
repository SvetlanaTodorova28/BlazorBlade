using System.ComponentModel.DataAnnotations;

namespace Pin.LiveSports.Core.Entities;

public class BaseEntity{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}