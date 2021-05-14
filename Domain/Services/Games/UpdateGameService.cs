using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Games
{
    public class UpdateGameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateGameService(IRepository<Game> gameRepository, IPasswordHasher passwordHasher)
        {
            _gameRepository = gameRepository;
            _passwordHasher = passwordHasher;
        }

        public Game Execute(int id, Game model)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                throw new Exception("Game não encontrado");
            }

            game.setName(model.Name);
            game.setPath(model.Path);

            // Adiciono update_at ao registro
            game.Updated_at = DateTime.Now;

            _gameRepository.Update(game);
            _gameRepository.Save();

            return game;
        }
    }
}