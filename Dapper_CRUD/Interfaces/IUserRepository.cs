using Dapper_CRUD.DTO;
using Dapper_CRUD.Models;

namespace Dapper_CRUD.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(UserDTO userDTO);
        public Task UpdateUserAsync(UserDTO userDTO, int age);
        public Task DeleteUserAsync(int Id);
        public Task<List<User>> GetAllUsersAsync();
    }
}
