using api.Models;

namespace api.DTO
{
    public class AuthDTO
    {
        public User user { get; set; }
        public string token { get; set; }
    }
}