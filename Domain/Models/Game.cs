using System;

namespace Domain.Models
{
    public class Game : BaseEntity
    {
        public Game(string name, string path)
        {
            Name = name;
            Path = path;
            Updated_at = DateTime.Now;
        }

        public bool IsValid
        {
            get
            {
                return
                    Name.Length > 3 && Name.Length <= 20 &&
                    Path.Length > 3 && Path.Length <= 250;
            }
        }

        public void setName(string name)
        {
            Name = name;
        }

        public void setPath(string path)
        {
            Path = path;
        }
        public string Name { get; private set; }

        public string Path { get; private set; }
    }
}