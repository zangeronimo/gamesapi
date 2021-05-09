using System;
using System.Linq;
using Domain.Models;
using Domain.Views;
using Infra.Context;
using Infra.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        public IConfiguration Configuration { get; }
        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("v1/auth")]
        public ActionResult<AuthView> Authenticate(
            [FromServices] DataContext context,
            [FromBody] AuthRequest model)
        {
            // Recupera o usuário
            var userQuery = context.users.AsQueryable();

            User user = userQuery
                .Where(x => x.Email.ToLower().Contains(model.Email)).First();


            var option = new HashingOptions();
            var password = new PasswordHasher(Options.Create(option));

            var (verified, _) = (password.Check(user.Password, model.Password));

            if (verified)
            {

                // Gera o Token
                var token = TokenService.GenerateToken(user, Configuration.GetConnectionString("Secret"));

                // Retorna os dados
                return new AuthView() { user = new UserView(user), token = token };
            }
            var e = new Exception("Login inválido");
            return BadRequest(e.Message);
        }
    }
}