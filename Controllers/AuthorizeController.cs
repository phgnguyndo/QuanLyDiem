using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Mapping;
using BE_QuanLiDiem.Models.DTO.User;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private QL_DiemDbContext context;
        private ICreateUser createUser;
        private JwtSettings jwtSettings;
        private IRefreshHandler refresh;

        public AuthorizeController(QL_DiemDbContext context, IOptions<JwtSettings> options, IRefreshHandler refresh, ICreateUser createUser)
        {
            this.context = context;
            this.jwtSettings = options.Value;
            this.refresh = refresh;
            this.createUser = createUser;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred)
        {
            var user = await this.context.tbl_user.FirstOrDefaultAsync(x => x.Code == userCred.username && x.Password == userCred.password);
            if (user != null)
            {
                //generate token
                var tokenhandler=new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Code),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires=DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                var finalToken=tokenhandler.WriteToken(token);
                return Ok(new  { Token=finalToken, RefreshToken=await this.refresh.GenerateToken(userCred.username), infoUser= user});

            }
            else
            {
                return Unauthorized();
            }
                return Ok("");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] tblUserDTO userDTO)
        {
            var user = await this.context.tbl_user.FirstOrDefaultAsync(x => x.Code == userDTO.Code);
            if (user != null)
            {
                return BadRequest("User existed");
            }
            user = await createUser.Register1(userDTO);
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
            var tokendesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, user.Code),
                        new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddSeconds(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokendesc);
            var finalToken = tokenhandler.WriteToken(token);
            
            return Ok(new { Token = finalToken, RefreshToken = await this.refresh.GenerateToken(userDTO.Code), infoUser=user });

        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] TokenResponse token)
        {
            var _refreshToken = await this.context.tbl_RefreshToken.FirstOrDefaultAsync(x => x.RefreshToken == token.RefreshToken);
            if (_refreshToken != null)
            {
                //generate token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                SecurityToken securityToken;
                var principal = tokenhandler.ValidateToken(token.Token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenkey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out securityToken);

                var _token= securityToken as JwtSecurityToken;
                if(_token != null && _token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                {
                    string username = principal.Identity?.Name;
                    var _existdata=await this.context.tbl_RefreshToken.FirstOrDefaultAsync(x=>x.UserId==username
                    && x.RefreshToken==token.RefreshToken);
                    if(_existdata != null)
                    {
                        var _newtoken = new JwtSecurityToken(
                            claims:principal.Claims.ToArray(),
                            expires:DateTime.Now.AddSeconds(30),
                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtSettings.securitykey)),
                            SecurityAlgorithms.HmacSha256)
                            );

                        var _finaltoken=tokenhandler.WriteToken(_newtoken);
                        return Ok(new TokenResponse() { Token = _finaltoken, RefreshToken = await this.refresh.GenerateToken(username) });

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }

            }
            else
            {
                return Unauthorized();
            }
            return Ok("");
        }
    }
}
