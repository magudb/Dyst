using System.Collections.Generic;
using System.Linq;
using Dyst.Domain;
using NUnit.Framework;

namespace Dyst.Tests
{
    [TestFixture]
    public class Game_should
    {
        [Test]
        public void add_player()
        {
            //// Arrange
            var game = new Game("Owner Name", "Password", "Dyst");
            var player = new Player("A player");
            //// Act
            game.AddPlayer(player);

            //// Assert
            Assert.That(game.Players, Contains.Item(player));
        }

        [Test]
        public void assign_knight_to_player()
        {
            //// Arrange
            var game = new Game("Owner Name", "Password", "Dyst");
            var knight = new Knight("Knight Name", new List<ICard>(), 1, 1);
            var player = new Player("A player");
            game.AddPlayer(player);
            
            //// Act
            game.AssignKnightToPlayer(player, knight);

            //// Assert
            Assert.That(game.Players.Any(p => p.Knight == knight),Is.True);
        }

        [Test]
        public void Get_game_on_name_and_password()
        {
            //// Arrange
            var game = new Game("Owner Name", "Password", "Dyst");

            //// Act
            var result = game.IsThisGame("Dyst", "Password");

            //// Assert
            Assert.That(result, Is.True);
        }
    }
}
