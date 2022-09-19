using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs;
using Tidsbanken_Backend.Models.DTOs.Self;
using Tidsbanken_Backend.Services;

namespace Tidsbanken_Backend.Controllers;

[ApiController]
[Route("Request")]
public class SelfRequestController : ControllerBase
{

	public SelfRequestController(IMapper mapper, TidsbankenDbContext context)
	{
		_mapper = mapper;
		_context = context;
		_service = new GenericDbService<VacationRequest, int>(context, mapper, (x) => x.VacationRequests);
	}
	private readonly IMapper _mapper;
	private readonly TidsbankenDbContext _context;
	private readonly GenericDbService<VacationRequest, int> _service;

	/// <summary>
	/// Post request - Creates a VacationRequest with a corresponding pending VacationStatus.
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	[Authorize, HttpPost("Create/")]
	public async Task<IActionResult> Create([Bind("Title,StartDate,EndDate,UserId")] SelfCreateVacationRequestDTO dto)
	{
		if (!this.Extension_IsSelf(dto.UserId))
		{
			return Forbid();
		}

		Func<IneligiblePeriod, bool> IsOverlapping = (IneligiblePeriod ineligible) =>
				(ineligible.StartDate <= dto.EndDate && ineligible.StartDate >= dto.StartDate) // Ineligible start is wrapped in the period
			 || (ineligible.EndDate <= dto.EndDate && ineligible.StartDate >= dto.StartDate) // Ineligible end is wrapped in the period
			 || (ineligible.EndDate >= dto.EndDate && ineligible.StartDate <= dto.StartDate) // Ineligible is entirely surrounding the period
			 || (ineligible.EndDate <= dto.EndDate && ineligible.StartDate >= dto.StartDate); // Ineligible is entirely surrounded

		var ineligibleOverlap = _context.IneligiblePeriods
			.Where(IsOverlapping);

		if (ineligibleOverlap.Any())
		{
			return BadRequest("This request would overlap with an ineligible period.");
		}


		var newData = _mapper.Map<VacationRequest>(dto);
		var status = new VacationStatus() { Status = StatusHelper.Pending };
		newData.VacationStatus = status;
		_context.Add(newData);
		await _context.SaveChangesAsync();

		return CreatedAtAction("ReadById", new { id = newData.Id }, _mapper.Map<SelfReadVacationRequestDTO>(newData));
	}

	/// <summary>
	/// Get request - Read vacation request by ID
	/// Must be vacation request owner or administrator
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[Authorize, HttpGet("ReadById/{id}")]
	public async Task<ActionResult<SelfReadVacationRequestDTO>> ReadById(int id)
	{
		var request = await _context.VacationRequests.FindAsync(id);
		var DTO = _mapper.Map<SelfReadVacationRequestDTO>(request);
		if (request == null)
		{
			return BadRequest("VacationRequest was not found");
		}
		var status = (await _context.VacationRequests
			.Include(i => i.VacationStatus)
			.Where(i => i.Id == id)
			.FirstAsync()).VacationStatus;

		if (status == null)
		{
			return BadRequest("Couldn't find the request status");
		}
		DTO.Status = status.Status;
		if (status.Status == StatusHelper.Approved)
		{
			return Ok(DTO);
		}
		if (await this.Extension_IsSelfOrAdmin(_context, request.UserId))
		{
			return Ok(DTO);
		}
		return Forbid();
	}

	/// <summary>
	/// Put request - Update a vacation request by ID
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	[Authorize, HttpPut("Update")]
	public async Task<IActionResult> Update(SelfUpdateVacationRequestDTO dto)
	{
		var oldT = await _context.VacationRequests.Include(v => v.VacationStatus).Where(v => v.Id == dto.Id).FirstAsync();
		if (!this.Extension_IsSelf(oldT?.UserId))
		{
			return Forbid("Can't edit requests that belong to other users.");
		}
		if (oldT == null)
		{
			return NotFound();
		}
		if (oldT.VacationStatus.Status != StatusHelper.Pending)
		{
			return Forbid("Can't edit a request that is not pending.");
		}

		_context.Update(oldT);
		_mapper.Map(dto, oldT);


		await _context.SaveChangesAsync();

		return Ok(oldT);
	}

	/// <summary>
	/// Get request - Read all vacation requests made on a user
	/// </summary>
	/// <returns></returns>
	[Authorize, HttpGet("ReadAll/")]
	public ActionResult<IEnumerable<SelfReadVacationRequestDTO>> ReadAll()
	{
		string? userId = this.Extension_GetUserId();
		if (userId == null)
		{
			return BadRequest("User could not be found");
		}
		var query = from request in _service.ReadAll().Include((r) => r.VacationStatus)
					where request.UserId == userId
					select request;

		var output = from request in query.Include(r => r.VacationStatus) // temporary hack solution
					 select new SelfReadVacationRequestDTO() { Title = request.Title, EndDate = request.EndDate, Id = request.Id, StartDate = request.StartDate, Status = request.VacationStatus.Status, VacationStatusId = request.VacationStatusId };

		return Ok(output);
	}

	/// <summary>
	/// Get request - Read all approved vacation requests made on all users
	/// </summary>
	/// <returns></returns>
	[Authorize, HttpGet("ReadAllApproved/")]
	public ActionResult<IEnumerable<SelfReadVacationRequestDTO>> ReadAllApproved()
	{
		return Ok(_service.ReadAll()
			.Include(r => r.VacationStatus)
			.Where(r => r.VacationStatus.Status == StatusHelper.Approved)
			.Select(request => new SelfReadVacationRequestDTO() { Title = request.Title, EndDate = request.EndDate, Id = request.Id, StartDate = request.StartDate, Status = request.VacationStatus.Status, VacationStatusId = request.VacationStatusId }));
	}

	/// <summary>
	/// Get request - Read vacation request status
	/// </summary>
	/// <param name="RequestId"></param>
	/// <returns></returns>
	[Authorize, HttpGet("GetStatus/{RequestId}")]
	public async Task<ActionResult<ReadVacationStatusDTO>> GetVacationStatus(int RequestId)
	{
		string? userId = this.Extension_GetUserId();
		if (userId == null)
		{
			return BadRequest("User could not be found");
		}
		var status = (await _context.VacationRequests
			.Include(i => i.VacationStatus)
			.Where(i => i.Id == RequestId && i.UserId == userId)
			.FirstAsync()).VacationStatus;
		return _mapper.Map<ReadVacationStatusDTO>(status);
	}
}
