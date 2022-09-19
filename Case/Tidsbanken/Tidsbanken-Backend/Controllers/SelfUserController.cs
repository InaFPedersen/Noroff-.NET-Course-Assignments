using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Models.DTOs.Self;
using Tidsbanken_Backend.Services;

namespace Tidsbanken_Backend.Controllers;
[ApiController]
[Route("User")]
public class SelfUserController : ControllerBase
{

	public SelfUserController(IMapper mapper, TidsbankenDbContext context, ManagementAccess managementAccess)
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
	/// Get only the authenticated user, without requiring input.
	/// </summary>
	/// <returns>Returns the current user as a SelfReadUserDTO object.</returns>
	[Authorize, HttpGet("")]
	public async Task<ActionResult<SelfReadUserDTO>> Get()
	{
		string? userId = this.Extension_GetUserId();
		if (userId == null)
		{
			return BadRequest("User could not be found");
		}
		return await _service.ReadById<SelfReadUserDTO>(userId);
	}

	/// <summary>
	/// If accessed by someone other than self or admin, this should only return name and picture.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Returns the appropriate UserDTO</returns>
	[Authorize, HttpGet("ReadById/{id}")]
	public async Task<ActionResult<object>> ReadById(string id)
	{
		var result = await _context.Users.FindAsync(id);
		if (result == null) return NotFound();
		object? output;
		string? userId = this.Extension_GetUserId();
		if (result.Id == userId)
		{
			output = _mapper.Map<SelfReadUserDTO>(result);
		}
		else
		{
			output = _mapper.Map<SelfReadOtherUserDTO>(result);
		}
		return Ok(output);
	}

	/// <summary>
	/// Deletes the user if done by an admin or current user.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Returns OK if successful, Forbid if not allowed and bad request otherwise.</returns>
	[Authorize, HttpDelete("Delete/{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		if (!await this.Extension_IsSelfOrAdmin(_context, id))
		{
			return Forbid();
		}
		if (await _context.Users.Where(u => u.Id == id).AnyAsync())
		{
			await _service.Delete(id);
			await _managementAccess.DeleteUser(id);
			return Ok();
		}
		return BadRequest();
	}

	/// <summary>
	/// Updates the user in the database. 
	/// Checks if the user is the current or an admin 
	/// and if the user exists before updating the database.
	/// </summary>
	/// <param name="dto"></param>
	/// <returns>Returns OK if successful with the updated user object, 
	/// Forbid if not allowed, and NotFound if user does not exist.</returns>
	[Authorize, HttpPut("Update")]
	public async Task<IActionResult> Update(SelfUpdateUserDTO dto)
	{
		if (!await this.Extension_IsSelfOrAdmin(_context, dto.Id))
		{
			return Forbid();
		}
		var user = await _context.Users.FindAsync(dto.Id);
		if (user == null)
		{
			return NotFound();
		}
		if (user.Email != dto.Email)
		{
			_context.Update(user);
			_mapper.Map(dto, user);

			await _context.SaveChangesAsync();
			_ = await _managementAccess.UpdateUser(dto);
		}
		else
		{
			_context.Update(user);
			_mapper.Map(dto, user);

			await _context.SaveChangesAsync();

		}
		return Ok(user);
	}

	/// <summary>
	/// Sends a change password request to the Auth0 Management API.
	/// The API then sends the user a password change link to the users email.
	/// </summary>
	/// <param name="email"></param>
	/// <returns>Returns OK with the response from Auth0 that a change password email has been sent.</returns>
	[Authorize, HttpPost("UpdatePassword/{email}")]
	public IActionResult UpdatePassword(string email)
	{
		string response = _managementAccess.ChangePassword(email).Content;

		return Ok(response);
	}

	/// <summary>
	/// Gets all of a user's vacation requests.
	/// </summary>
	/// <param name="UserId"></param>
	/// <returns>Returns OK with a list of vacation requests if successful, Forbid if not allowed and BadRequest if user not found.</returns>
	[Authorize, HttpGet("GetRequests/{UserId}")]
	public async Task<ActionResult<IEnumerable<SelfReadVacationRequestDTO>>> GetRequests(string UserId)
	{
		if (!await this.Extension_IsSelfOrAdmin(_context, UserId))
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
		return Ok(_mapper.Map<SelfReadVacationRequestDTO>(user.VacationRequests));
	}
}