using Crud_Back.Data;
using Crud_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CrudDbContext _context;

        public UserController(CrudDbContext crudDb)
        {
            _context = crudDb;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User userObj)
        {
           
            var user=await _context.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password==userObj.Password);
            if (user == null)
                return NotFound(new { Message = "User not found" });
            return Ok(new {Message="Login Success"});
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User userObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Users.AddAsync(userObj); 
            await _context.SaveChangesAsync();
            return Ok(new { Message = "User registered" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user =await  _context.Users.ToListAsync();
            return Ok(user);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("Student not found");
            }
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.UserName = updateUser.UserName;
            user.Password = updateUser.Password;

            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
    }
}
