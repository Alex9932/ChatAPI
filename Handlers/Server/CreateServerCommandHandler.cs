using ChatAPI.Commands.Server;
using ChatAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAPI.Handlers.Server
{
    public class CreateServerCommandHandler : IRequestHandler<CreateServerCommand, IActionResult>
    {
        private readonly AppDBContext _ctx;

        public CreateServerCommandHandler(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Handle(CreateServerCommand request, CancellationToken cancellationToken)
        {
            var server = new Data.Models.Server()
            {
                Name = request.Name,
            };

            _ctx.Servers.Add(server);
            await _ctx.SaveChangesAsync();

            return new CreatedResult("Server", server.Id);
        }
    }
}
