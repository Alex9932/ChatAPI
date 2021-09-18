using ChatAPI.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ISender _sender;
        
        public AuthController(ILogger<AuthController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthCommand Cmd)
        {
            var result = await _sender.Send(Cmd);
            return result;
        }
    }
}
