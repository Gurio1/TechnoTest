using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace TechnoTest
{
    public class BasicAuthenticationHandler : IAuthenticationHandler
    {
        private HttpContext _context;

        public BasicAuthenticationHandler()
        {
            ;
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _context = context;
            return Task.CompletedTask;
        }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            if (!(_context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Basic ") ?? false))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var encodedCredentials =
                _context.Request.Headers["Authorization"].ToString().Substring("Basic ".Length).Trim();
            var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            var username = decodedCredentials.Split(':')[0];
            var password = decodedCredentials.Split(':')[1];

            if (username != "myusername" || password != "mypassword")
                return Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));

            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, "Basic");
            var principal = new ClaimsPrincipal(identity);
            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, "Basic")));
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            _context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"Techno Test\"";
            _context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            _context.Response.StatusCode = 403;
            return Task.CompletedTask;
        }
    }
}