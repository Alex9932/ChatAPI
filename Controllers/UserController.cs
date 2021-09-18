using ChatAPI.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISender _sender;

        public UserController(ILogger<UserController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand Cmd)
        {
            var result = await _sender.Send(Cmd);
            return result;
        }

    }
}
