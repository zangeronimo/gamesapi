using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Users
{
    public class AddUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AddUserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User Execute(User model)
        {
            if (model.IsValid)
            {
                model.setPassword(_passwordHasher.Hash(model.Password));
                _userRepository.Add(model);
                _userRepository.Save();
                return model;
            }
            else
            {
                throw new Exception("Dados inválidos");
            }
        }
    }
}