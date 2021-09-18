using ChatAPI.Commands.Channel;
using ChatAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAPI.Handlers.Channel
{
    public class CreateChannelCommandHandler : IRequestHandler<CreateChannelCommand, IActionResult>
    {
        private readonly AppDBContext _ctx;

        public CreateChannelCommandHandler(AppDBContext ctx) {
            _ctx = ctx;
        }

        public async Task<IActionResult> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
        {

            var servers = _ctx.Servers.Where(s => s.Id == request.ServerId);
            if (servers.Count() == 0)
            {
                return new BadRequestObjectResult("Server not found!");
            }

            var server = servers.First();
            var channel = new Data.Models.Channel()
            {
                Name = request.Name,
                Server = server
            };

            _ctx.Channels.Add(channel);
            await _ctx.SaveChangesAsync();

            return new CreatedResult("Channel", channel.Id);
        }
    }
}
