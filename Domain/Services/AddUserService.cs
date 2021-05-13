using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
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
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}