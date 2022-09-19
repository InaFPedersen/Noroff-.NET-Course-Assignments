using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;

namespace Tidsbanken_Backend.Services;

/// <summary>
/// This class implements some basic CRUD for any model with a primary key, DTOs and automapper profile.
/// </summary>
public partial class GenericDbService<TModel, TPrimaryKey> : ControllerBase
    where TModel : class
{
    public IMapper _mapper { get; }
    public TidsbankenDbContext _context { get; }

    public GenericDbService(TidsbankenDbContext context, IMapper mapper, GetTFromContext<TModel> getTFromContext)
    {
        _context = context;
        _mapper = mapper;
        _getTFromContext = new GetTFromContext<TModel>(getTFromContext);
    }
    /// <summary>
    /// Gets the DbSet<T> from the database.
    /// The implementation should look like: 
    ///    { return _context.T; }
    /// </summary>
    /// <returns></returns>
    protected GetTFromContext<TModel> _getTFromContext;

    /// <summary>
    /// Create an instance of a model
    /// </summary>
    /// <typeparam name="TDTO"></typeparam>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<IActionResult> Create<TDTO>(TDTO dto)
    {
        var newData = _mapper.Map<TModel>(dto);
        _context.Add(newData);
        await _context.SaveChangesAsync();

        return Ok();
    }
    /// <summary>
    /// Returns a DTO of the model of the given ID.
    /// </summary>
    /// <typeparam name="TDTO"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ActionResult<TDTO>> ReadById<TDTO>(TPrimaryKey id)
    {
        var result = await _getTFromContext(_context).FindAsync(id);
        if (result == null) return NotFound();
        return Ok(_mapper.Map<TDTO>(result));
    }
    /// <summary>
    /// Read all instances of the model from the database.
    /// Converts from DbSet to IQueryable.
    /// </summary>
    /// <returns></returns>
    public IQueryable<TModel> ReadAll()
    {
        return _getTFromContext(_context).Select(t => t);
    }
    /// <summary>
    /// Delete a model with the given ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(TPrimaryKey id)
    {
        var Model = await _getTFromContext(_context).FindAsync(id);
        if (Model == null)
        {
            return NotFound();
        }
        _getTFromContext(_context).Remove(Model);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
