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

    public DbSet<HabitRecord> HabitRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HabitRecord>()
            .HasOne(record => record.Habit)
            .WithMany(habit => habit.HabitRecords)
            .HasForeignKey(record => record.HabitId);

        modelBuilder.Entity<HabitRecord>()
            .HasIndex(record => new
            {
                record.HabitId,
                record.CompletedDate
            })
            .IsUnique();
    }
}