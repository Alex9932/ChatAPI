using ChatAPI.Commands.Channel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly ILogger<ChannelController> _logger;
        private readonly ISender _sender;

        public ChannelController(ILogger<ChannelController> logger, ISender sender) {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateChannelCommand Cmd)
        {
            var result = await _sender.Send(Cmd);
            return result;
        }
    }
}
