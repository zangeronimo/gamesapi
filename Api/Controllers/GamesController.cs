using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Domain.Views;
using Domain.Services.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    public class GamesController : Controller
    {
        private readonly ReadGameService _readGameService;
        private readonly CreateGameService _createGameService;
        private readonly UpdateGameService _updateGameService;
        private readonly DeleteGameService _deleteGameService;

        public GamesController(
            ReadGameService readGameService,
            CreateGameService createGameService,
            UpdateGameService updateGameService,
            DeleteGameService deleteGameService
        )
        {
            _readGameService = readGameService;
            _createGameService = createGameService;
            _updateGameService = updateGameService;
            _deleteGameService = deleteGameService;
        }

        [HttpGet("v1/games")]
        [Authorize]
        public ActionResult<IEnumerable<GameView>> Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var games = _readGameService.Execute(filter);
                return Ok(games.Select(d => new GameView(d)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("v1/games")]
        [Authorize]
        public ActionResult<GameView> Post([FromBody] Game model)
        {
            try
            {
                var game = _createGameService.Execute(model);
                return Created("", new GameView(game));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("v1/games/{id}")]
        [Authorize]
        public ActionResult<GameView> Put(int id, [FromBody] Game model)
        {
            try
            {
                var game = _updateGameService.Execute(id, model);
                return Ok(new GameView(game));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [HttpDelete("v1/games/{id}")]
        [Authorize]
        public ActionResult<GameView> Delete(int id)
        {
            try
            {
                var game = _deleteGameService.Execute(id);
                return Ok(new GameView(game));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}