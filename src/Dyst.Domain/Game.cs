using System;
using System.Collections.Generic;
using System.Linq;

namespace Dyst.Domain
{
    public class Game
    {
        public Game(string owner, string password, string gameName)
        {
            GameName = gameName;
            Password = password;
            Owner = owner;
            Players = new List<Player>();
            Id = Guid.NewGuid();
        }

        public string GameName { get; private set; }
        public string Owner { get; private set; }
        public string Password { get; private set; }
        public Guid Id { get; private set; }

        public IEnumerable<Player> Players { get; private set; }

        public void AssignKnightToPlayer(Player player, Knight knight)
        {
            var players = Players.ToList();
            var playerWithoutKnight = players.SingleOrDefault(p=> p == player);
            if (playerWithoutKnight != null)
            {
                playerWithoutKnight.AssignKnight(knight);
            }

            Players = players;
        }

        public void AddPlayer(Player player)
        {
            var players = Players.ToList();
            players.Add(player);
            Players = players;
        }

        public bool IsThisGame(string gameName, string password)
        {
            return GameName == gameName && Password == password;
        }
    }
}
