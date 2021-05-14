using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Domain.Views;
using Domain.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    public class UsersController : Controller
    {
        private readonly ShowUserService _showUserService;
        private readonly AddUserService _addUserService;
        private readonly UpdateUserService _updateUserService;
        private readonly DeleteUserService _deleteUserService;

        public UsersController(
            ShowUserService showUserService,
            AddUserService addUserService,
            UpdateUserService updateUserService,
            DeleteUserService deleteUserService)
        {
            _showUserService = showUserService;
            _addUserService = addUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
        }

        [HttpGet("v1/users")]
        [Authorize]
        public ActionResult<IEnumerable<UserView>> Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var users = _showUserService.Execute(filter);
                return Ok(users.Select(d => new UserView(d)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("v1/users")]
        public ActionResult<UserView> Post([FromBody] User model)
        {
            try
            {
                var user = _addUserService.Execute(model);
                return Created("", new UserView(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("v1/users/{id}")]
        [Authorize]
        public ActionResult<UserView> Put(int id, [FromBody] User model)
        {
            try
            {
                var user = _updateUserService.Execute(id, model);
                return Ok(new UserView(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [HttpDelete("v1/users/{id}")]
        [Authorize]
        public ActionResult<UserView> Delete(int id)
        {
            try
            {
                var user = _deleteUserService.Execute(id);
                return Ok(new UserView(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}