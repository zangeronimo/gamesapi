using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.Controllers
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
        public AuthDTO Authenticate(
            [FromServices] DataContext context,
            [FromBody] AuthRequest model)
        {
            // Recupera o usuário
            var user = context.users.AsQueryable();

            user = user
                .Where(x => x.Email.ToLower().Contains(model.Email));

            // Gera o Token
            var token = TokenService.GenerateToken(user.First(), Configuration.GetConnectionString("Secret"));

            // Retorna os dados
            return new AuthDTO() { user = user.First(), token = token };
        }
    }
}