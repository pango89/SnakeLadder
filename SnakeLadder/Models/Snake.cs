using System;
namespace SnakeLadder.Models
{
    public class Snake
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Snake(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
