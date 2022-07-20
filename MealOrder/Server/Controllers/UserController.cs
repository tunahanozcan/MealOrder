using MealOrder.Server.Services.Infrastruce;
using MealOrder.Shared.DTO;
using MealOrder.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet("Login")]
        public ServiceResponse<string> Login(string Email,string Password)
        {
            return new ServiceResponse<string>()
            {
                Value = userService.Login(Email, Password)
            };
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await userService.GetUsers()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(int Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id)
            };
        }


        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] int id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(id)
            };
        }

    }
}
