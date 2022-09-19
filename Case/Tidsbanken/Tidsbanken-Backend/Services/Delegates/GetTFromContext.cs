using Microsoft.EntityFrameworkCore;
using Tidsbanken_Backend.Models.Data;

namespace Tidsbanken_Backend.Services;

/// <summary>
/// Get the DbSet containing the type TModel from the given context.
/// Implementation looks like:
///     return _context.{variable name};
/// </summary>
public delegate DbSet<TModel> GetTFromContext<TModel>(TidsbankenDbContext _context) where TModel : class;
