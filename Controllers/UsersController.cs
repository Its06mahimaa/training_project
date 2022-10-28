
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;
using trainingproject.Models;
using User = trainingproject.Models.User;

namespace trainingproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        private BooksContext _context;

        public UsersController(BooksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> UserDataUpload([FromForm] UserModel user)
        {
            if (user.Profile_pic == null)
            {
                return new UnsupportedMediaTypeResult();
            }

            if (user.Profile_pic.Length > 0)
            {
                IFormFile formFile = user.Profile_pic;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

                var filePath = Path.Combine(folderPath, formFile.FileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    fileStream.Flush();

                }

            }


            User user1 = new User();
            user1.UserId = user.UserId;
            user1.UserName = user.UserName;
            user1.Mobile = user.Mobile;
            user1.Email = user.Email;
            user1.Gender = user.Gender;
            user1.Dob = user.Dob;
            user1.Hobbies = user.Hobbies;
            user1.ProfilePic = user.Profile_pic.FileName;
            user1.Password = user.password;
            user1.RoleId = user.RoleId;
            

            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);



        }
        [HttpDelete("UserId")]

        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var dbUser = await _context.Users.FindAsync(id)
;
            if (dbUser == null)
                return BadRequest("User not found.");

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

    }
}



