using Domain.Models;

namespace Api.Views
{
    public class AuthView
    {
        public UserView user { get; set; }
        public string token { get; set; }
    }
}