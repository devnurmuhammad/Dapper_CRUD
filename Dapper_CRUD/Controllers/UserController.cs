using Dapper_CRUD.DTO;
using Dapper_CRUD.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromForm] UserDTO userDTO)
        {
            await userRepository.CreateUserAsync(userDTO);
            return Ok("Created");
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDTO userDTO, int age)
        {
            await userRepository.UpdateUserAsync(userDTO, age);
            return Ok("Updated");
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            await userRepository.DeleteUserAsync(Id);
            return Ok("Deleted");
        }

        [HttpGet("GetAllUsers")]

        public async Task<IActionResult> GetAllUsers()
        {
            var result =  await userRepository.GetAllUsersAsync();
            return Ok(result);
        }
    }
}
