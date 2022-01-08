using NUnit.Framework;
using Poker;
using Poker.Lib;
using System;

namespace PokerLib.UnitTests
{
    [TestFixture]
    public class DealerTests
    {
        private Player[] _players;
        private Dealer _dealer;

        [SetUp]
        public void Setup()
        {
            _players = new Player[] { new Player("Charlie", 7), new Player("Gösta", 3) };
            _dealer = new Dealer(_players);

        }

        [Test]
        public void OnNewDeal_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _dealer.OnNewDeal(); });
        }

        [Test]
        public void DeclareWinner_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _dealer.DeclareWinner(); });
        }
        [Test]
        public void DeclareWinner_WinnerIsDeclared_ShouldNotThrowErrors()
        {
            //Arrange
            var player1 = new Player("Peggy", 2);
            var player2 = new Player("Twiggy", 3);
            player1.HandType = HandType.FourOfAKind;
            player2.HandType = HandType.TwoPairs;
                
            var players = new Player[] { player1, player2 };
            var dealer = new Dealer(_players);

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { dealer.DeclareWinner(); });
        }
        [Test]
        public void FirstDeal_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange


            //Act
            //Assert
            Assert.DoesNotThrow(delegate { _dealer.FirstDeal(_players); });
        }

        [Test]
        public void GiveNewCard_HappyCase_ShouldReturnACard()
        {
            //Arrange


            //Act
            var result = _dealer.GiveNewCard();
            //Assert
            //Assert.DoesNotThrow(delegate { _dealer.FirstDeal(_players); });

            Assert.IsNotNull(result);
        }

        [Test]
        public void Dealer_HappyCase_ResultsShouldBeTwoOfCLubs()
        {
            //Arrange
            Deck deck = new Deck();

            //Act

            //Assert
            Assert.DoesNotThrow(delegate { var dealer = new Dealer(deck); });
        }
    }
}