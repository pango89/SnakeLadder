using System;
using System.Collections.Generic;
using System.Linq;
using SnakeLadder.Models;

namespace SnakeLadder.Services
{
    public class OrchestratorService
    {
        public OrchestratorService()
        {
            Board = new Board(DEFAULT_BOARD_SIZE, DEFAULT_PLAYER_COUNT);
            Players = new List<Player>(DEFAULT_PLAYER_COUNT);
        }

        private static readonly int DEFAULT_BOARD_SIZE = 100;
        private static readonly int DEFAULT_PLAYER_COUNT = 2;
        private static readonly int DEFAULT_DICE_COUNT = 2;

        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }

        public void AddPlayers(List<Player> players) => this.Players = players;
        public void AddSnakes(List<Snake> snakes) => this.Board.Snakes = snakes;
        public void AddLadders(List<Ladder> ladders) => this.Board.Ladders = ladders;

        public void MovePlayer(Player player, int diceValue)
        {
            int oldPosition = this.Board.PlayerPositionMap[player.Id];
            int newPosition = oldPosition + diceValue;

            if (newPosition > DEFAULT_BOARD_SIZE)
            {
                Console.WriteLine("This move is Invalid.. Beyond Boundary.. Skipping..");
                return;
            }

            Console.WriteLine(player.Name + " rolled a " + diceValue);
            this.Board.PlayerPositionMap[player.Id] = this.FindUpdatedPosition(newPosition);
            Console.WriteLine(player.Name + " rolled a " + diceValue + " and moved from " + oldPosition + " to " + this.Board.PlayerPositionMap[player.Id]);
        }

        public bool IsGameOver()
        {
            return this.Board.PlayerPositionMap.Values.Any(x => x == DEFAULT_BOARD_SIZE);
        }

        public int FindUpdatedPosition(int position)
        {
            int previousPosition;
            int newPosition;
            do
            {
                previousPosition = position;
                newPosition = position;

                foreach (Snake snake in this.Board.Snakes)
                {
                    if (snake.Start == previousPosition)
                    {
                        newPosition = snake.End;
                        Console.WriteLine("Snake Bite - Fall from {0} to {1}", snake.Start, snake.End);
                    }
                }

                foreach (Ladder ladder in this.Board.Ladders)
                {
                    if (ladder.Start == newPosition)
                    {
                        newPosition = ladder.End;
                        Console.WriteLine("Ladder Lift - Rise from {0} to {1}", ladder.Start, ladder.End);
                    }
                }
            } while (previousPosition != position);

            return newPosition;
        }

        public void PlayGame()
        {
            while (true)
            {
                if (this.IsGameOver())
                    break;

                Random rnd = new Random();
                for (int i = 0; i < DEFAULT_PLAYER_COUNT; i++)
                {
                    int diceValue = rnd.Next(1, 7);
                    //Console.WriteLine("Player {0} got {1} on rolling the dice", this.Players[i].Name, diceValue);
                    this.MovePlayer(this.Players[i], diceValue);
                    Console.WriteLine("=================");

                    if (this.IsGameOver())
                        break;
                }
            }
        }
    }
}
