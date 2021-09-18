using ChatAPI.Commands.Auth;
using ChatAPI.Data;
using ChatAPI.Data.DTO;
using ChatAPI.Data.Models;
using ChatAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAPI.Handlers.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, IActionResult>
    {
        private readonly AppDBContext _ctx;

        public AuthCommandHandler(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            string passwd_hash = MD5Hash.Create(request.Password);

            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Login == request.Login && u.PasswordHash == passwd_hash);

            if (user == null)
            {
                return new UnauthorizedObjectResult(new Error("Invalid login or password!"));
            }

            Token token = new Token()
            {
                User = user
            };

            _ctx.Tokens.Add(token);
            await _ctx.SaveChangesAsync();

            return new OkObjectResult(token.Id);
        }
    }
}
