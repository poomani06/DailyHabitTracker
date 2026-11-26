
using System.ComponentModel.DataAnnotations;

namespace DailyHabitTracker.API.DTOs.HabitDTOs;

public class CreateHabitDTO
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
}
