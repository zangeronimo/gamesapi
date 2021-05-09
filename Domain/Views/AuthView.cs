using Domain.Models;

namespace Domain.Views
{
    public class AuthView
    {
        public UserView user { get; set; }
        public string token { get; set; }
    }
}