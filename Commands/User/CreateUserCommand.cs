using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Commands.User
{
    public class CreateUserCommand : IRequest<IActionResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
