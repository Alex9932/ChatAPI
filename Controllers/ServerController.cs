using ChatAPI.Commands.Server;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly ILogger<ServerController> _logger;
        private readonly ISender _sender;

        public ServerController(ILogger<ServerController> logger, ISender sender) {
            _logger = logger;
            _sender = sender;
        }

        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServerCommand Cmd)
        {
            var result = await _sender.Send(Cmd);
            return result;
        }

    }
}
