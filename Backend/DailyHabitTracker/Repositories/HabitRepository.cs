
using DailyHabitTracker.API.Data;
using DailyHabitTracker.API.Models;
using DailyHabitTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailyHabitTracker.API.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly ApplicationDbContext _context;

    public HabitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Habit>> GetAllAsync()
    {
        return await _context.Habits
            .OrderByDescending(h => h.CreatedAt)
            .ToListAsync();
    }

    public async Task<Habit?> GetByIdAsync(int id)
    {
        return await _context.Habits
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<Habit> AddAsync(Habit habit)
    {
        await _context.Habits.AddAsync(habit);
        await _context.SaveChangesAsync();

        return habit;
    }

    public async Task UpdateAsync(Habit habit)
    {
        _context.Habits.Update(habit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Habit habit)
    {
        _context.Habits.Remove(habit);
        await _context.SaveChangesAsync();
    }
}
