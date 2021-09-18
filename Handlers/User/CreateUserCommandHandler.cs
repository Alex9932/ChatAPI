using ChatAPI.Commands.User;
using ChatAPI.Data;
using ChatAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAPI.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IActionResult>
    {
        private readonly AppDBContext _ctx;

        public CreateUserCommandHandler(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(_ctx.Users.Where(u => u.Login == request.Login).Count() > 0) {
                return new ConflictResult();
            }

            var user = new Data.Models.User()
            {
                Login = request.Login,
                PasswordHash = MD5Hash.Create(request.Password)
            };

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            return new CreatedResult("User", user.Id);
        }
    }
}
