using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Commands.Channel
{
    public class CreateChannelCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public Guid ServerId { get; set; }
    }
}
