namespace DailyHabitTracker.API.DTOs.HabitDTOs;

public class HabitHistoryResponseDTO
{
    public int Id { get; set; }

    public int HabitId { get; set; }

    public string HabitName { get; set; } = string.Empty;

    public DateOnly CompletedDate { get; set; }
}