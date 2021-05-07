using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{

    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("v1/users")]
        [Authorize]
        public async Task<ActionResult<List<UserView>>> Get(
            [FromServices] DataContext context,
            [FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var users = context.users.AsQueryable();

                // Se existe filtro, aplico à consulta
                if (!string.IsNullOrEmpty(filter))
                {
                    var clause = filter.ToLower();

                    users = users
                        .Where(x => x.Name.ToLower().Contains(clause)
                                || x.Email.ToLower().Contains(clause));
                }

                return await users.Select(a => new UserView(a)).ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
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
    }
}