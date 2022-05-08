using System;
using System.Collections.Generic;

namespace SnakeLadder.Models
{
    public class Board
    {
        public Board(int size, int count)
        {
            Size = size;
            Snakes = new List<Snake>();
            Ladders = new List<Ladder>();
            PlayerPositionMap = new Dictionary<int, int>();

            for (int i = 1; i <= count; i++)
                this.PlayerPositionMap.Add(i, 0);
        }

        public int Size { get; set; }
        public List<Snake> Snakes { get; set; }
        public List<Ladder> Ladders { get; set; }
        public Dictionary<int, int> PlayerPositionMap { get; set; }
    }
}
