using System;
namespace SnakeLadder.Models
{
    public class Ladder
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Ladder(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
