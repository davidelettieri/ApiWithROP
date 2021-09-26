using ROP;

namespace ApiWithROP.Services
{
    public static class Errors
    {
        public static readonly Failure UserNotFound = new Failure("E-001", "User not found");
    }

}