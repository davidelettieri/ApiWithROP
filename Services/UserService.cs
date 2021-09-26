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
                return Errors.UserNotFound;
            }

            return new User()
            {
                Id = id,
                Name = "Fake user"
            };
        }

    }

}