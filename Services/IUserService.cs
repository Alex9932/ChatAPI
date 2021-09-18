using ChatAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatAPI.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(Guid token);
        Guid GetUserId(ClaimsPrincipal user);
        Task<User> GetUserAsync(ClaimsPrincipal user);
    }
}
