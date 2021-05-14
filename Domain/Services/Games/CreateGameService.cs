using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Games
{
    public class CreateGameService
    {
        private readonly IRepository<Game> _gameRepository;

        public CreateGameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Execute(Game model)
        {
            if (model.IsValid)
            {
                _gameRepository.Add(model);
                _gameRepository.Save();
                return model;
            }
            else
            {
                throw new Exception("Dados inválidos");
            }
        }
    }
}