using Domain.Models;

namespace Domain.Views
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public UserView(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}