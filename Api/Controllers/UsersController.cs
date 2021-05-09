using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly IRepository<User> _userRepository;

        public UsersController(UserService userService, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet("v1/users")]
        [Authorize]
        public IEnumerable<UserView> Get([FromQuery(Name = "filter")] string filter)
        {
            var users = _userRepository.GetAll();
            return users.Select(d => new UserView(d));
        }
        /*
                [HttpPost("v1/users")]
                public async Task<ActionResult<UserView>> Post(
                    [FromServices] DataContext context,
                    [FromBody] User model)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            var option = new HashingOptions();
                            var passwordHasher = new PasswordHasher(Options.Create(option));
                            model.Password = passwordHasher.Hash(model.Password);
                            context.users.Add(model);
                            await context.SaveChangesAsync();
                            return new UserView(model);
                        }
                        else
                        {
                            return BadRequest(ModelState);
                        }
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                [HttpPut("v1/users/{id}")]
                [Authorize]
                public async Task<ActionResult<User>> Put(
                    [FromServices] DataContext context,
                    int id,
                    [FromBody] User model)
                {
                    try
                    {
                        var user = await context.users.FindAsync(id);
                        if (user == null)
                        {
                            return BadRequest();
                        }

                        user.Name = model.Name;
                        user.Email = model.Email;

                        if (!string.IsNullOrEmpty(model.Password))
                        {
                            var option = new HashingOptions();
                            var passwordHasher = new PasswordHasher(Options.Create(option));
                            user.Password = passwordHasher.Hash(model.Password);
                        }

                        // Adiciono updated_at ao contato
                        user.UpdatedAt = DateTime.Now;

                        context.users.Update(user);
                        await context.SaveChangesAsync();

                        return Ok(user);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }

                [HttpDelete("v1/users/{id}")]
                [Authorize]
                public async Task<ActionResult<User>> Delete(
                    [FromServices] DataContext context,
                    int id)
                {
                    try
                    {
                        var user = await context.users.FindAsync(id);
                        if (user == null)
                        {
                            return BadRequest();
                        }

                        context.users.Remove(user);
                        await context.SaveChangesAsync();

                        return Ok(user);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }
                */
    }
}