
using DailyHabitTracker.API.Models;

namespace DailyHabitTracker.API.Repositories.Interfaces;

public interface IHabitRepository
{
    Task<List<Habit>> GetAllAsync();

    Task<Habit?> GetByIdAsync(int id);

    Task<Habit> AddAsync(Habit habit);

    Task UpdateAsync(Habit habit);

    Task DeleteAsync(Habit habit);
    Task<List<int>> GetCompletedHabitIdsAsync(DateOnly date);

    Task<bool> IsCompletedAsync(int habitId, DateOnly date);

    Task AddRecordAsync(HabitRecord record);

    Task RemoveRecordAsync(int habitId, DateOnly date);

    Task<List<HabitRecord>> GetHistoryAsync();
}
