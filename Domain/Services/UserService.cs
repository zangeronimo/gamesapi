using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Executar(string filter)
        {
            try
            {
                var users = _userRepository.GetAll();

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}