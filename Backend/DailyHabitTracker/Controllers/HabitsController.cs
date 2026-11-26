
using DailyHabitTracker.API.DTOs.HabitDTOs;
using DailyHabitTracker.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyHabitTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly IHabitService _service;

    public HabitsController(IHabitService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var habits = await _service.GetAllAsync();

        return Ok(habits);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var habit = await _service.GetByIdAsync(id);

        if (habit == null)
            return NotFound(new { message = "Habit not found." });

        return Ok(habit);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHabitDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest(new { message = "Habit name is required." });

        var habit = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = habit.Id },
            habit
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateHabitDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest(new { message = "Habit name is required." });

        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound(new { message = "Habit not found." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound(new { message = "Habit not found." });

        return NoContent();
    }
}
