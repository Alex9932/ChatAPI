using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ChatAPI.Services;

namespace ChatAPI.Handlers.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(IUserService userService, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Guid token;
            if (!Guid.TryParse(Request.Headers["authorization"], out token)) return Guid.Empty.Equals(token) ? AuthenticateResult.NoResult() : AuthenticateResult.Fail("No valid ApiKey format!");

            var user = await _userService.AuthenticateAsync(token);

            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid token!");
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, token.ToString())
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}