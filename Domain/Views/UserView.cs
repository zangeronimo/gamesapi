using Domain.Models;

namespace Domain.Views
{
    public class GameView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }

        public GameView(Game user)
        {
            Id = user.Id;
            Name = user.Name;
            Path = user.Path;
        }
    }
}