using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
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