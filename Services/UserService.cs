using ApiWithROP.Models;
using ROP;

namespace ApiWithROP.Services
{
    public class UserService
    {
        public Result<User> GetUser(int id)
        {
            if (id < 0)
            {
                return new Failure("E-001", "User not found");
            }

            return new User()
            {
                Id = id,
                Name = "Fake user"
            };
        }

    }

}