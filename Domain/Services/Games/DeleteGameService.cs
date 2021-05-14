using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Games
{
    public class DeleteGameService
    {
        private readonly IRepository<Game> _gameRepository;

        public DeleteGameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Execute(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                throw new Exception("Game não encontrado");
            }
            // Adiciono update_at ao registro
            game.Updated_at = DateTime.Now;
            // Adiciono removed_at ao registro
            game.Deleted_at = DateTime.Now;

            _gameRepository.Update(game);
            _gameRepository.Save();

            return game;
        }
    }
}