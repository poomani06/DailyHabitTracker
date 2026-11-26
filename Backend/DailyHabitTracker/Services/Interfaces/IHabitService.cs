
using DailyHabitTracker.API.DTOs.HabitDTOs;

namespace DailyHabitTracker.API.Services.Interfaces;

public interface IHabitService
{
    Task<List<HabitResponseDTO>> GetAllAsync();

    Task<HabitResponseDTO?> GetByIdAsync(int id);

    Task<HabitResponseDTO> CreateAsync(CreateHabitDTO dto);

    Task<bool> UpdateAsync(int id, UpdateHabitDTO dto);

    Task<bool> DeleteAsync(int id);
}
