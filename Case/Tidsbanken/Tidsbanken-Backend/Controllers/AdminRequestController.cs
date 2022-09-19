using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Self;
using Tidsbanken_Backend.Models.DTOs.Admin;
using Tidsbanken_Backend.Services;
using Tidsbanken_Backend.Models.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Tidsbanken_Backend.Controllers;
[ApiController]
[Route("Admin/Request")]
public class AdminRequestController : ControllerBase
{

    public AdminRequestController(IMapper mapper, TidsbankenDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _service = new GenericDbService<VacationRequest, int>(context, mapper, (x) => x.VacationRequests);
    }
    private readonly IMapper _mapper;
    private readonly TidsbankenDbContext _context;
    private readonly GenericDbService<VacationRequest, int> _service;

    /// <summary>
    /// Administrator Get request - Read all Vacation Requests by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpGet("ReadById/{id}")]
    public async Task<ActionResult<AdminReadVacationRequestDTO>> ReadById(int id)
    {
        if (!(await this.Extension_IsAdmin(_context)))
        {
            return Forbid();
        }
        return await _service.ReadById<AdminReadVacationRequestDTO>(id);
    }

    /// <summary>
    /// Administrator Get request Read all existing Vacation Requests 
    /// </summary>
    /// <returns></returns>
    [Authorize, HttpGet("ReadAll/")]
    public async Task<ActionResult<IEnumerable<AdminReadVacationRequestDTO>>> ReadAll()
    {
        if (!(await this.Extension_IsAdmin(_context)))
        {
            return Forbid();
        }
        var output = from request in _service.ReadAll() select _mapper.Map<AdminReadVacationRequestDTO>(request);
        return Ok(output);
    }

    /// <summary>
    /// Delete request - Delete Vacation status by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!(await this.Extension_IsAdmin(_context)))
        {
            return Forbid();
        }
        // Delete the request's status
        var status = await (from i in _context.VacationStatuses
                            where i.Id == id
                            select i).FirstOrDefaultAsync();
        if (status == null)
        {
            return NotFound();
        }
        _context.VacationStatuses.Remove(status);

        // delete the request
        return await _service.Delete(id);
    }

    /// <summary>
    /// Get request - Read Vacation Status by request ID
    /// </summary>
    /// <param name="RequestId"></param>
    /// <returns></returns>
    [Authorize, HttpGet("GetStatus/{RequestId}")]
    public async Task<ActionResult<ReadVacationStatusDTO>> GetVacationStatus(int RequestId)
    {
        if (!(await this.Extension_IsAdmin(_context)))
        {
            return Forbid();
        }
        var status = (await _context.VacationRequests
            .Include(i => i.VacationStatus)
            .Where(i => i.Id == RequestId)
            .FirstAsync()).VacationStatus;

        return _mapper.Map<ReadVacationStatusDTO>(status);
    }

    /// <summary>
    /// Put request - Set Vacation status to a vacation request
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    [Authorize, HttpPut("SetStatus")]
    public async Task<IActionResult> SetVacationStatus(AdminUpdateVacationStatusDTO status)
    {
        if (!(await this.Extension_IsAdmin(_context)))
        {
            return Forbid();
        }
        if (!StatusHelper.IsValidStatus(status.Status))
        {
            return BadRequest("Invalid status value. Must be " + StatusHelper.Pending + ", " + StatusHelper.Approved + " or " + StatusHelper.Denied + ".");
        }

        var VacationRequest = (await _context.VacationRequests
            .Include(i => i.VacationStatus)
            .Where(i => i.VacationStatus.Id == status.Id)
            .FirstAsync());

        if (VacationRequest.UserId == this.Extension_GetUserId())
        {
            return BadRequest("Admin can't approve their own requests.");
        }
        VacationStatus? VacationStatus = VacationRequest.VacationStatus;
        if (VacationStatus == null)
        {
            return NotFound();
        }
        _context.Update(VacationStatus);
        _mapper.Map(status, VacationStatus);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
