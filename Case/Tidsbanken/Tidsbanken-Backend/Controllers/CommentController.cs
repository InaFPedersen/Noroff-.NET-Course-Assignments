using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;
using Tidsbanken_Backend.Models.Domain;
using Tidsbanken_Backend.Services;
using Tidsbanken_Backend.Models.DTOs.IneligiblePeriodDTO;
using Tidsbanken_Backend.Models.DTOs.CommentDTO;
using Microsoft.AspNetCore.Authorization;

namespace Tidsbanken_Backend.Controllers;

[ApiController]
[Route("Comments")]
public class CommentController : ControllerBase
{
    public CommentController(IMapper mapper, TidsbankenDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _service = new GenericDbService<Comment, int>(context, mapper, (x) => x.Comments);
    }
    private readonly IMapper _mapper;
    private readonly TidsbankenDbContext _context;
    private readonly GenericDbService<Comment, int> _service;

    /// <summary>
    /// Post request - Create a comment to a vacation request, 
    /// Found by VacationRequestID. 
    /// Only administrator and owner of the request can do this
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Authorize, HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCommentDTO dto)
    {
        if (!await IsRequestOwnerOrAdmin(dto.VacationRequestId))
        {
            return Forbid();
        }
        var newData = _mapper.Map<Comment>(dto);
        newData.CreationDate = DateTime.Now;
        _context.Add(newData);
        await _context.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Get request - Read all comments on a request by RequestID
    /// </summary>
    /// <param name="RequestId"></param>
    /// <returns></returns>
    [Authorize, HttpGet("ReadAll/{RequestId}")]
    public async Task<ActionResult<IEnumerable<ReadCommentDTO>>> ReadAll(int RequestId)
    {
        if (!await IsRequestOwnerOrAdmin(RequestId))
        {
            return Forbid();
        }
        return Ok(
            from comment in _service.ReadAll() 
            where comment.VacationRequestId == RequestId 
            select _mapper.Map<ReadCommentDTO>(comment));
    }

    /// <summary>
    /// Get request - Read comment by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpGet("ReadById/{id}")]
    public async Task<ActionResult<ReadCommentDTO>> ReadById(int id)
    {
        if (!await IsCommentOwnerOrAdmin(id))
        {
            return Forbid();
        }
        return await _service.ReadById<ReadCommentDTO>(id);
    }

    /// <summary>
    /// Delete request - Delete a comment by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize, HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsCommentOwnerOrAdmin(id))
        {
            return Forbid();
        }
        if (await _context.Comments.Where(p => p.Id == id).AnyAsync())
        {
            await _service.Delete(id);
            return Ok();
        }
        return BadRequest();
    }

    /// <summary>
    /// Put request - Update a comment by id
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Authorize, HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCommentDTO dto)
    {
        if (!await IsCommentOwnerOrAdmin(dto.Id))
        {
            return Forbid();
        }
        Comment? commentInDb = await _context.Comments.FindAsync(dto.Id);
        if (commentInDb == null)
        {
            return NotFound();
        }

        _context.Update(commentInDb);
        _mapper.Map(dto, commentInDb);
        commentInDb.LastTimeEdited = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok(commentInDb);
    }
    /// <summary>
    /// Checks if the user is the owner or administrator of the request 
    /// which this comment is attached to. 
    /// </summary>
    /// <param name="RequestId"></param>
    /// <returns></returns>
    private async Task<bool> IsRequestOwnerOrAdmin(int RequestId)
    {
        var request = await _context.VacationRequests.Where(r => r.Id == RequestId).FirstOrDefaultAsync();

        return (await this.Extension_IsSelfOrAdmin(_context, request?.UserId));
    }

    private async Task<bool> IsCommentOwnerOrAdmin(int CommentId)
    {
        var comment = await _context.Comments.Where(c => c.Id == CommentId).FirstOrDefaultAsync();
        if (comment == null)
        {
            return false;
        }
        var request = await _context.VacationRequests.Where(r => r.Id == comment.VacationRequestId).FirstOrDefaultAsync();

        return (await this.Extension_IsSelfOrAdmin(_context, request?.UserId));
    }
}