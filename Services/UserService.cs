using System.Collections.Generic;
using ApiWithROP.Models;
using ROP;

namespace ApiWithROP.Services
{
    public class UserService
    {
        private readonly Dictionary<int, User> _source = new()
        {
            { 1, new User() { Id = 1, Name = "User 1" } },
            { 2, new User() { Id = 1, Name = "User 2" } },
            { 3, new User() { Id = 1, Name = "User 3" } },
            { 4, new User() { Id = 1, Name = "User 4" } },
            { 5, new User() { Id = 1, Name = "User 5" } }
        };

        public Result<User> GetUser(int id)
        {
            if (!_source.TryGetValue(id, out var user))
            {
                return Errors.UserNotFound;
            }

            return user;
        }

    }

}