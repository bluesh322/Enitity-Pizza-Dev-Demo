using BookStoresWebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Options;
using SQLitePCL;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BookStoresWebAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BookStoresDbContext _context;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder,
            BookStoresDbContext context,
            ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header was not found"));
            }

            try
            {
                AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                byte[] bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string emailAddress = credentials[0];
                string password = credentials[1];

                User user = _context.Users.Where(user => user.EmailAddress == emailAddress && user.Password == password).FirstOrDefault();

                if (user == null)
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
                }
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.EmailAddress) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principle = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principle, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            } 
            catch (Exception)
            {
                return Task.FromResult(AuthenticateResult.Fail("Error has occurred"));
            }
        }
    }
}
