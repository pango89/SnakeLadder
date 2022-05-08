using System;
using System.Collections.Generic;
using SnakeLadder.Models;
using SnakeLadder.Services;

namespace SnakeLadder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OrchestratorService os = new OrchestratorService();
            List<Player> players = new List<Player>();
            players.Add(new Player("Obama", 1));
            players.Add(new Player("Trump", 2));
            os.AddPlayers(players);

            List<Ladder> ladders = new List<Ladder>();
            ladders.Add(new Ladder(4, 30));
            ladders.Add(new Ladder(23, 68));
            ladders.Add(new Ladder(39, 50));
            ladders.Add(new Ladder(44, 99));
            ladders.Add(new Ladder(70, 85));
            ladders.Add(new Ladder(9, 77));
            os.AddLadders(ladders);

            List<Snake> snakes = new List<Snake>();
            snakes.Add(new Snake(95, 56));
            snakes.Add(new Snake(80, 19));
            snakes.Add(new Snake(55, 3));
            snakes.Add(new Snake(49, 32));
            snakes.Add(new Snake(40, 19));
            snakes.Add(new Snake(30, 11));
            snakes.Add(new Snake(15, 2));
            os.AddSnakes(snakes);

            os.PlayGame();
        }
    }
}
