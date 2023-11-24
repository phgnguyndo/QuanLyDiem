using BE_QuanLiDiem.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BE_QuanLiDiem.Mapping
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly QL_DiemDbContext context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, QL_DiemDbContext context) : base(options, logger, encoder, clock)
        {
            this.context = context;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No header found");
            }
            var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (headerValue != null)
            {
                var bytes = Convert.FromBase64String(headerValue.Parameter);
                string credentials=Encoding.UTF8.GetString(bytes);
                string[] array=credentials.Split(":");
                string username = array[0];
                string password = array[1];
                var user =await this.context.tbl_user.FirstOrDefaultAsync(x => x.Code == username && x.Password == password);
                if (user != null)
                {
                    var claim = new[] { new Claim(ClaimTypes.Name, user.Code) };
                    var identity=new ClaimsIdentity(claim, Scheme.Name);
                    var printcipal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(printcipal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("UnAuthorized");
                }
            }
            else
            {
                return AuthenticateResult.Fail("Empty Header");
            }
        }
    }
}
