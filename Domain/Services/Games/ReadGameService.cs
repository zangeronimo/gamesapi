using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services.Games
{
    public class ReadGameService
    {
        private readonly IRepository<Game> _gameRepository;

        public ReadGameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IEnumerable<Game> Execute(string filter)
        {
            var games = _gameRepository.GetAll();

            return games;
        }
    }
}