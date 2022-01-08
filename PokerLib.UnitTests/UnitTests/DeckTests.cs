using NUnit.Framework;
using Poker;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLib.UnitTests

{
    [TestFixture]
    public class DeckTests

    {
        private Deck _deck;

        [SetUp]
        public void Setup()
        {
            _deck = new Deck();
        }

        [Test]
        public void Shuffle_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange


            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _deck.Shuffle(); });
        }

        [Test]
        public void DrawTopCard_HappyCase_ResultsShouldBeTwoOfCLubs()
        {
            //Arrange
            var expectedResult = new Card(Suite.Clubs, Rank.Two);

            //Act
            var result = _deck.DrawTopCard();

            //Assert
            Assert.AreEqual(expectedResult.Rank, result.Rank);
            Assert.AreEqual(expectedResult.Suite, result.Suite);
        }
        [Test]
        public void ReturnCard_CardInGraveyard_ResultShoulldBeReturnedCards()
        {
            //Arrange
            //Arrange
            var player1 = new Player("Peggy", 2);
            var player2 = new Player("Twiggy", 3);
            player1.graveyard = new Graveyard() { graveYardCards = new List<Card>() { new Card(Suite.Diamonds, Rank.Ace) } };
            player2.graveyard = new Graveyard();

            var players = new Player[] { player1, player2 };

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _deck.ReturnCard(players); });
        }


        [Test]
        public void ReturnCard_HappyCase_ResultShoulldBeReturnedCards()
        {
            //Arrange
            //Arrange
            var player1 = new Player("Peggy", 2);
            var player2 = new Player("Twiggy", 3);
            player1.graveyard = new Graveyard();
            player2.graveyard = new Graveyard();

            var players = new Player[] { player1, player2 };

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _deck.ReturnCard(players); });
        }
    }
}
