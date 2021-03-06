using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Users
{
    public class DeleteUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public DeleteUserService(IRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User Execute(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            // Adiciono updated_at ao registro
            user.Updated_at = DateTime.Now;
            // Adiciono removed_at ao registro
            user.Deleted_at = DateTime.Now;

            _userRepository.Update(user);
            _userRepository.Save();

            return user;
        }
    }
}