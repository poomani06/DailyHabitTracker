
using DailyHabitTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyHabitTracker.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Habit> Habits { get; set; }
}
