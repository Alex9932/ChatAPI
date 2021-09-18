using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Commands.Server
{
    public class CreateServerCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
    }
}
