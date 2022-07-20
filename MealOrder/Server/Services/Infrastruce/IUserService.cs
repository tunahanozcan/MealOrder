using MealOrder.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealOrder.Server.Services.Infrastruce
{
    public interface IUserService
    {

        public Task<UserDTO> GetUserById(int Id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO user);
        public Task<UserDTO> UpdateUser(UserDTO user);
        public Task<bool> DeleteUser(int Id);
    }
}
