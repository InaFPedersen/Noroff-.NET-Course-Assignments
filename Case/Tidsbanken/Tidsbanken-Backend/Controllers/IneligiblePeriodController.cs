using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Admin;
using Tidsbanken_Backend.Services;
using Tidsbanken_Backend.Models.DTOs.IneligiblePeriodDTO;
using Microsoft.AspNetCore.Authorization;

namespace Tidsbanken_Backend.Controllers;

[ApiController]
[Route("Ineligible")]
public class IneligiblePeriodController : ControllerBase
{
    public IneligiblePeriodController(IMapper mapper, TidsbankenDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _service = new GenericDbService<IneligiblePeriod, int>(context, mapper, (x) => x.IneligiblePeriods);
    }
    private readonly IMapper _mapper;
    private readonly TidsbankenDbContext _context;
    private readonly GenericDbService<IneligiblePeriod, int> _service;

    /// <summary>
    /// Administrator - Post request - Create a new ineligible period
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Authorize, HttpPost("Create/")]
    public async Task<IActionResult> Create(CreateIneligiblePeriodDTO dto)
    {
        if (!await this.Extension_IsAdmin(_context))
        {
            return Forbid();
        }
        return await _service.Create(dto);
    }

    /// <summary>
    /// Get request - Read all existing ineligible periods 
    /// </summary>
    /// <returns></returns>
    [Authorize, HttpGet("ReadAll/")]
    public ActionResult<IEnumerable<ReadIneligiblePeriodDTO>> ReadAll()
    {
        return Ok(from period in _service.ReadAll() select _mapper.Map<ReadIneligiblePeriodDTO>(period));
    }

    /// <summary>
    /// Get request - Read a existing ineligible period by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpGet("ReadById/{id}")]
    public Task<ActionResult<ReadIneligiblePeriodDTO>> ReadById(int id)
    {
        return _service.ReadById<ReadIneligiblePeriodDTO>(id);
    }

    /// <summary>
    /// Delete request - Delete a existing ineligible period by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await this.Extension_IsAdmin(_context))
        {
            return Forbid();
        }
        if (await _context.IneligiblePeriods.Where(p => p.Id == id).AnyAsync())
        {
            await _service.Delete(id);
            return Ok();
        }
        return BadRequest();
    }

    /// <summary>
    /// Put request - Update a existing ineligible period by ID.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Authorize, HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateIneligiblePeriodDTO dto)
    {
        if (!await this.Extension_IsAdmin(_context))
        {
            return Forbid();
        }
        var oldPeriod = await _context.IneligiblePeriods.FindAsync(dto.Id);
        if (oldPeriod == null)
        {
            return NotFound();
        }

        _context.Update(oldPeriod);
        _mapper.Map(dto, oldPeriod);

        await _context.SaveChangesAsync();

        return Ok(oldPeriod);
    }

}
