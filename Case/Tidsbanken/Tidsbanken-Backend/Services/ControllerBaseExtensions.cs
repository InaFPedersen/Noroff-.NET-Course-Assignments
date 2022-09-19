using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using Tidsbanken_Backend.Models.Data;
using System.Security.Claims;

namespace Tidsbanken_Backend.Services
{
    /// <summary>
    /// Extends the ControllerBase with additional functions for authentication.
    /// 
    /// </summary>
    public static class ControllerBaseExtensions
    {
        public static string? GetScheme(this ControllerBase controller)
        {
            var authorization = controller.Request.Headers[HeaderNames.Authorization];
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                return headerValue.Scheme; // This is the token
            }
            return null;
        }

        /// <summary>
        /// Get the userId of the authenticated user.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static string? Extension_GetUserId(this ControllerBase controller)
        {
            string? userId = controller.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            return userId;
        }
        /// <summary>
        /// Test if a given UserId corresponds to the UserId of the authorization.
        /// </summary>
        public static bool Extension_IsSelf(this ControllerBase controller, string? requestedUserId)
        {
            return (requestedUserId != null && controller.Extension_GetUserId() == requestedUserId);
        }
        /// <summary>
        /// Check if the authenticated user is an administrator.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="_context"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static async Task<bool> Extension_IsAdmin(this ControllerBase controller, TidsbankenDbContext _context)
        {
            var user = await _context.Users.FindAsync(controller.Extension_GetUserId());
            if (user == null)
            {
                return false;
            }
            return  user.IsAdmin;
        }
        /// <summary>
        /// Test if a given UserId corresponds to the UserId of the authorization, OR the authenticated user is an administrator.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="_context"></param>
        /// <param name="requestedUserId"></param>
        /// <returns></returns>
        public static async Task<bool> Extension_IsSelfOrAdmin(this ControllerBase controller, TidsbankenDbContext _context, string? requestedUserId)
        {
            if (requestedUserId == null) return false;
            bool isSelf = controller.Extension_GetUserId() == requestedUserId;
            return isSelf || await controller.Extension_IsAdmin(_context);
        }
    }
}
