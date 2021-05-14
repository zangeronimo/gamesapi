using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Users
{
    public class ShowUserService
    {
        private readonly IRepository<User> _userRepository;

        public ShowUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Execute(string filter)
        {
            var users = _userRepository.GetAll();

            return users;
        }
    }
}