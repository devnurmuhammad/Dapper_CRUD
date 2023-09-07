using Dapper;
using Dapper_CRUD.DTO;
using Dapper_CRUD.Interfaces;
using Dapper_CRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;

namespace Dapper_CRUD.Services
{
    public class UserService : IUserRepository
    {
        private readonly string connectionString = 
            "Server = localhost; Port = 5432; User Id = postgres; Password = devnur; Database = Dapper_CRUD;";

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
              
                var sqlQuery = $"CREATE TABLE IF NOT EXISTS users (id Serial PRIMARY KEY NOT NULL, name TEXT NOT NULL, age INTEGER);";
                await connection.ExecuteAsync(sqlQuery);

                sqlQuery = $"INSERT INTO users (name, age) VALUES ('{userDTO.Name}', '{userDTO.Age}')";
                connection.Execute(sqlQuery);
            }
        }

        public async Task UpdateUserAsync(UserDTO userDTO, int age)
        {
            using (var connection = new NpgsqlConnection (connectionString))
            {
                var sqlQuery = $"UPDATE users SET Name = '{userDTO.Name}' WHERE Age = '{age}';";
                await connection.ExecuteAsync(sqlQuery);
            }
        }

        public async Task DeleteUserAsync(int Id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM users WHERE Id = '{Id}';";
                await connection.ExecuteAsync(sqlQuery);
            }
        }

        

        public async Task<List<User>> GetAllUsersAsync()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlQuery = $"SELECT * FROM public.users;";
                var users = await connection.QueryAsync<User>(sqlQuery);

                return users.ToList();
            }
        }
    }
}
