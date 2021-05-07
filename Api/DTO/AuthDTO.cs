using Domain.Models;

namespace Api.DTO
{
    public class AuthDTO
    {
        public UserView user { get; set; }
        public string token { get; set; }
    }
}