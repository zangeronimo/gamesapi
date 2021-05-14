using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Users
{
    public class UpdateUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User Execute(int id, User model)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.setName(model.Name);
            user.setEmail(model.Email);

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.setPassword(_passwordHasher.Hash(model.Password));
            }

            // Adiciono updated_at ao contato
            user.Updated_at = DateTime.Now;

            _userRepository.Update(user);
            _userRepository.Save();

            return user;
        }
    }
}