using System.ComponentModel.DataAnnotations;

namespace DailyHabitTracker.API.Models;

public class HabitRecord
{
    public int Id { get; set; }

    public int HabitId { get; set; }

    public DateOnly CompletedDate { get; set; }

    public Habit Habit { get; set; } = null!;
    public ICollection<HabitRecord> HabitRecords { get; set; }
    = new List<HabitRecord>();
}