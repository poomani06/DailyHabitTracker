
using DailyHabitTracker.API.DTOs.HabitDTOs;
using DailyHabitTracker.API.Models;
using DailyHabitTracker.API.Repositories.Interfaces;
using DailyHabitTracker.API.Services.Interfaces;

namespace DailyHabitTracker.API.Services;

public class HabitService : IHabitService
{
    private readonly IHabitRepository _repository;

    public HabitService(IHabitRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<HabitResponseDTO>> GetAllAsync()
    {
        var habits = await _repository.GetAllAsync();

        var today = DateOnly.FromDateTime(DateTime.Today);

        var completedIds = await _repository.GetCompletedHabitIdsAsync(today);

        return habits.Select(habit => new HabitResponseDTO
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            CreatedAt = habit.CreatedAt,
            IsCompletedToday = completedIds.Contains(habit.Id)
        }).ToList();
    }

    public async Task<HabitResponseDTO?> GetByIdAsync(int id)
    {
        var habit = await _repository.GetByIdAsync(id);

        return habit == null ? null : MapToDTO(habit);
    }

    public async Task<HabitResponseDTO> CreateAsync(CreateHabitDTO dto)
    {
        var habit = new Habit
        {
            Name = dto.Name.Trim(),
            Description = dto.Description?.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        var createdHabit = await _repository.AddAsync(habit);

        return MapToDTO(createdHabit);
    }

    public async Task<bool> UpdateAsync(int id, UpdateHabitDTO dto)
    {
        var habit = await _repository.GetByIdAsync(id);

        if (habit == null)
            return false;

        habit.Name = dto.Name.Trim();
        habit.Description = dto.Description?.Trim();

        await _repository.UpdateAsync(habit);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var habit = await _repository.GetByIdAsync(id);

        if (habit == null)
            return false;

        await _repository.DeleteAsync(habit);

        return true;
    }

    private static HabitResponseDTO MapToDTO(Habit habit)
    {
        return new HabitResponseDTO
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            CreatedAt = habit.CreatedAt
        };
    }
    public async Task<bool> CompleteTodayAsync(int id)
{
    var habit = await _repository.GetByIdAsync(id);

    if (habit == null)
        return false;

    var today = DateOnly.FromDateTime(DateTime.Today);

    var alreadyCompleted = await _repository.IsCompletedAsync(id, today);

    if (!alreadyCompleted)
    {
        var record = new HabitRecord
        {
            HabitId = id,
            CompletedDate = today
        };

        await _repository.AddRecordAsync(record);
    }

    return true;
}

public async Task<bool> UndoTodayAsync(int id)
{
    var habit = await _repository.GetByIdAsync(id);

    if (habit == null)
        return false;

    var today = DateOnly.FromDateTime(DateTime.Today);

    await _repository.RemoveRecordAsync(id, today);

    return true;
}
    
}
