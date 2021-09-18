using ChatAPI.Data;
using ChatAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _ctx;

        public UserService(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> AuthenticateAsync(Guid token)
        {
            var _token = await _ctx.Tokens.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == token);

            if (_token == null)
            {
                return null;
            }

            return _token.User;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            var userToken = GetUserId(user);
            if (Guid.Empty.Equals(userToken))
            {
                return null;
            }

            var token = await _ctx.Tokens.Include(t => t.User).Where(t => t.Id == userToken).FirstOrDefaultAsync();

            if (token == null || Guid.Empty.Equals(token))
            {
                return null;
            }

            return token.User;
        }

        public Guid GetUserId(ClaimsPrincipal user) => Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
