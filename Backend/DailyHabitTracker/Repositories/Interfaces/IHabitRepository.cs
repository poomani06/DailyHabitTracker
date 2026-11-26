
using DailyHabitTracker.API.Models;

namespace DailyHabitTracker.API.Repositories.Interfaces;

public interface IHabitRepository
{
    Task<List<Habit>> GetAllAsync();

    Task<Habit?> GetByIdAsync(int id);

    Task<Habit> AddAsync(Habit habit);

    Task UpdateAsync(Habit habit);

    Task DeleteAsync(Habit habit);
}
