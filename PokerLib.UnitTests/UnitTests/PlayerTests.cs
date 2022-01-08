using NUnit.Framework;
using Poker;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Poker.Suite;
using static Poker.Rank;


namespace PokerLib.UnitTests
{
    [TestFixture]
    public class PlayerTests

    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Charlie", 5);
        }
        [Test]
        public void CardsHaveBeenChoosenForExchange_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var cards = new Card[] { new Card(Suite.Spades, Rank.Queen) };

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _player.SortCards(cards); });
        }

        [Test]
        public void BeforeShowHand_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var player = new Player("Musse", 7);

            player.Hand[0] = new Card(Clubs, Two);
            player.Hand[1] = new Card(Hearts, Two);
            player.Hand[2] = new Card(Clubs, Three);
            player.Hand[3] = new Card(Hearts, Three);
            player.Hand[4] = new Card(Clubs, Four);

            player.graveyard = new();

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { player.BeforeShowHand(); });
        }

        [Test]
        public void BeforeShowHand_RoyalStraightFlush_ShouldNotThrowErrors()
        {
            //Arrange
            var player = new Player("Musse", 7);

            player.Hand[0] = new Card(Hearts, Ten);
            player.Hand[1] = new Card(Hearts, Jack);
            player.Hand[2] = new Card(Hearts, Queen);
            player.Hand[3] = new Card(Hearts, King);
            player.Hand[4] = new Card(Hearts, Ace);

            player.graveyard = new();

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { player.BeforeShowHand(); });
        }

        [Test]
        public void BeforeShowHand_Flush_ShouldNotThrowErrors()
        {
            //Arrange
            var player = new Player("Musse", 7);

            player.Hand[0] = new Card(Hearts, Seven);
            player.Hand[1] = new Card(Hearts, Jack);
            player.Hand[2] = new Card(Hearts, Queen);
            player.Hand[3] = new Card(Hearts, King);
            player.Hand[4] = new Card(Hearts, Ace);

            player.graveyard = new();

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { player.BeforeShowHand(); });
        }

        [Test]
        public void HandAfterDiscard_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var player = new Player("Musse", 7);

            player.Hand[0] = new Card(Clubs, Two);
            player.Hand[1] = new Card(Hearts, Two);
            player.Hand[2] = new Card(Clubs, Three);
            player.Hand[3] = new Card(Hearts, Three);
            player.Hand[4] = new Card(Clubs, Four);

            player.graveyard = new();
            //Act

            //Assert
            Assert.DoesNotThrow(delegate { player.Discard = player.Hand; });
        }
    }
}
