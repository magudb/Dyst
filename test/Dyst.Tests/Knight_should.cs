using System.Collections.Generic;
using System.Linq;
using Dyst.Domain;
using NUnit.Framework;


namespace Dyst.Tests
{
    [TestFixture]
    class Knight_should
    {
        [Test]
        public void draw_card_up_to_max_hand()
        {
            //// Arrange
            var cards = new List<ICard>
            {
                new Card()
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawCardsUpToMaxHand();

            //// Assert
            Assert.That(knight.Hand.Count(), Is.EqualTo(1));
            Assert.That(knight.Cards.Count(), Is.EqualTo(0));
        }

        [Test]
        public void play_card_from_hand()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
             
              card
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawCardsUpToMaxHand();
            knight.PlayCard(card);

            //// Assert
            Assert.That(knight.Hand.Count(), Is.EqualTo(0));
            Assert.That(knight.Graveyard.Count(), Is.EqualTo(1));
        }

        [Test]
        public void only_play_card_from_hand()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
             
              new Card()
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawCardsUpToMaxHand();
           

            //// Assert
            Assert.Throws<CardNotFoundException>(() => knight.PlayCard(card));
        }
        [Ignore]
        [Test]
        public void draw_card_up_to_max_hand_when_has_cards_in_hand()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
                card,
                new Card(),
               
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawCardsUpToMaxHand();
            knight.PlayCard(card);
            knight.DrawCardsUpToMaxHand();
            //// Assert
            Assert.That(knight.Hand.Count(), Is.EqualTo(1));
            Assert.That(knight.Cards.Count(), Is.EqualTo(0));
        }

        [Test]
        public void add_card_from_graveyard_to_hand()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
                card,
               
               
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawCardsUpToMaxHand();
            knight.PlayCard(card);
            knight.DrawSpecificCardFromGraveyard(card);
            //// Assert
            Assert.That(knight.Hand.Count(), Is.EqualTo(1));
            Assert.That(knight.Cards.Count(), Is.EqualTo(0));

        }

        [Test]
        public void throw_exception_when_return_card_from_graveyard_that_isnt_in_graveyard()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
             
             card
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
           


            //// Assert
            Assert.Throws<CardNotFoundException>(() =>  knight.DrawSpecificCardFromGraveyard(card));
        }

        [Test]
        public void draw_specific_card_from_cards()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
             
             card
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act
            knight.DrawSpecificCard(card);

            //// Assert
            Assert.That(knight.Hand, Contains.Item(card));
        }

        [Test]
        public void throw_exception_when_card_is_not_found()
        {
            //// Arrange
            var card = new Card();
            var cards = new List<ICard>
            {
             
           
               
            };

            var knight = new Knight("Knight Name", cards, 1, 1);

            //// Act



            //// Assert
            Assert.Throws<CardNotFoundException>(() => knight.DrawSpecificCard(card));
        }
    }
}
