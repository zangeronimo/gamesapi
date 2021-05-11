using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute()
        {

        }
    }
}