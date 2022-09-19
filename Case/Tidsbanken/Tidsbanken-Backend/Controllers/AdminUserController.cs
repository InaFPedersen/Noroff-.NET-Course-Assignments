using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Admin;
using Tidsbanken_Backend.Services;
namespace Tidsbanken_Backend.Controllers;

[ApiController]
[Route("Admin/User")]
public class AdminUserController : ControllerBase
{
	public AdminUserController(IMapper mapper, TidsbankenDbContext context, ManagementAccess managementAccess)
	{
		_mapper = mapper;
		_context = context;
		_service = new GenericDbService<User, string>(context, mapper, (c) => c.Users);
		_managementAccess = managementAccess;
	}
	private readonly GenericDbService<User, string> _service;
	private readonly TidsbankenDbContext _context;
	private readonly IMapper _mapper;
	private readonly ManagementAccess _managementAccess;

	/// <summary>
	/// Post request - Create new user
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	[Authorize, HttpPost("Create/")]
	public async Task<IActionResult> Create(AdminCreateUserDTO dto)
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		var newData = _mapper.Map<User>(dto);
		var userId = await _managementAccess.CreateUser(dto);
		newData.Id = userId;

		_context.Add(newData);
		await _context.SaveChangesAsync();

		return Ok();
	}

	/// <summary>
	/// Administrator - Get request - Read all existing users
	/// </summary>
	/// <returns></returns>
	[Authorize, HttpGet("ReadAll/")]
	public async Task<ActionResult<IEnumerable<AdminReadUserDTO>>> ReadAll()
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		return Ok(from user in _service.ReadAll() select _mapper.Map<AdminReadUserDTO>(user));
	}

	/// <summary>
	/// Administrator - Get request - Read a existing user by ID
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[Authorize, HttpGet("ReadById/{id}")]
	public async Task<ActionResult<AdminReadUserDTO>> ReadById(string id)
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		return await _service.ReadById<AdminReadUserDTO>(id);
	}

	/// <summary>
	/// Administrator - Delete request - Delete a existing user by ID
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[Authorize, HttpDelete("Delete/{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		if (!(await _context.Users.Where(u => u.Id == id).AnyAsync()))
		{
			return BadRequest();
		}

		var comments = from comment in _context.Comments
					   where comment.AuthorId == id
					   select comment;

		// Dereference comments made by this user.
		foreach (var comment in comments)
		{
			_context.Update(comment);
			comment.AuthorId = null;
		}
		_context.SaveChanges();

		// Delete the user's requests and their comments
		var requests = from request in _context.VacationRequests.Include(r => r.Comments)
					   where request.UserId == id
					   select request;
		foreach (var request in requests)
		{
			var requestComments = from comment in request.Comments
								  where comment.AuthorId == id
								  select comment;
			foreach (var comment in requestComments)
			{
				_context.Comments.Remove(comment);
			}
			_context.VacationRequests.Remove(request);
		}


		await _service.Delete(id);
		await _managementAccess.DeleteUser(id);

		return Ok();
	}

	/// <summary>
	/// Administrator - Put request - Update information on a existing user by ID
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	[Authorize, HttpPut("Update")]
	public async Task<IActionResult> Update(AdminUpdateUserDTO dto)
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		var userInDatabase = await _context.Users.FindAsync(dto.Id);
		if (userInDatabase == null)
		{
			return NotFound();
		}

		_context.Update(userInDatabase);
		_mapper.Map(dto, userInDatabase);

		await _context.SaveChangesAsync();

		return Ok(userInDatabase);
	}

	/// <summary>
	/// Administrator - Get request - Read all Vacation request belonging to a user by userID
	/// </summary>
	/// <param name="UserId"></param>
	/// <returns></returns>
	[Authorize, HttpGet("GetRequests/{UserId}")]
	public async Task<ActionResult<IEnumerable<VacationRequest>>>? GetRequests(string UserId)
	{
		if (!(await this.Extension_IsAdmin(_context)))
		{
			return Forbid();
		}
		User? user = await _context.Users
			.Where(u => u.Id == UserId)
			.Include(u => u.VacationRequests)
			.FirstAsync();
		if (user == null)
		{
			return BadRequest("The user could not be found");
		}
		return Ok(user.VacationRequests);
	}
}
