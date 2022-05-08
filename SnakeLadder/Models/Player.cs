using System;
namespace SnakeLadder.Models
{
    public class Player
    {
        public Player(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }
    }
}
