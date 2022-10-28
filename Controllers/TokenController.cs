
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trainingproject.Models;

namespace trainingproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly BooksContext _context;


        public TokenController(IConfiguration config, BooksContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserD _userData )
        {
            if (_userData != null && _userData.Login != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Login, _userData.Password);
                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", user.UserName)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),

                        signingCredentials: signIn);

                    Tokenmodel model = new Tokenmodel();
                    model.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    model.UserName = user.UserName;
                    model.UserId = user.UserId;
                    model.RoleName = user.Role.RoleName;
                    model.ProfilePic = user.ProfilePic;
                  
                    return Ok(model);
                }

                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private object TokenHandler()
        {
            throw new NotImplementedException();
        }

        private async Task<User> GetUser(string login, string password)
        {
            return await _context.Users.Include(x => x.Role
            ).FirstOrDefaultAsync(u => (u.Email == login || u.Mobile == login) && u.Password == password);
        }

    } 
}



