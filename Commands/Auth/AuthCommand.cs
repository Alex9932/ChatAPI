using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Commands.Auth
{
    public class AuthCommand : IRequest<IActionResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
