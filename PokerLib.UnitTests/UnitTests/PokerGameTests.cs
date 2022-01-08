using NUnit.Framework;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Poker.Suite;
using static Poker.Rank;
using Poker;

namespace PokerLib.UnitTests
{
    [TestFixture]
    public class PokerGameTests
    {
        private PokerGame _pokerGame;

        [SetUp]
        public void Setup()
        {
            _pokerGame = new PokerGame(new string[] { "Leffe", "James" });
        }

        [Test]
        public void PlayGame_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var player1 = new Player("Kalle", 8);
            var player2 = new Player("Musse", 7);

            player1.Hand[0] = new Card(Clubs, Two);
            player1.Hand[1] = new Card(Hearts, Two);
            player1.Hand[2] = new Card(Clubs, Three);
            player1.Hand[3] = new Card(Hearts, Three);
            player1.Hand[4] = new Card(Clubs, Four);

            player2.Hand[0] = new Card(Diamonds, Two);
            player2.Hand[1] = new Card(Spades, Two);
            player2.Hand[2] = new Card(Diamonds, Three);
            player2.Hand[3] = new Card(Spades, Three);
            player2.Hand[4] = new Card(Diamonds, Four);

            var players = new Player[] { player1, player2 };
            var dealer = new Dealer(players);
            var pokerGame = new PokerGame(players);
            //Act

            //Assert
            Assert.DoesNotThrow(delegate { pokerGame.PlayGame(dealer); });
        }

        private static void NewDeal()
        {

        }
        private static void OnRecievedReplacementCards(IPlayer player)
        {

        }

        [Test]
        public void PlayGame_RaiseAllEvents_ShouldNotThrowErrors()
        {
            //Arrange
            var player1 = new Player("Kalle", 8);
            var player2 = new Player("Musse", 7);

            player1.Hand[0] = new Card(Clubs, Two);
            player1.Hand[1] = new Card(Hearts, Two);
            player1.Hand[2] = new Card(Clubs, Three);
            player1.Hand[3] = new Card(Hearts, Three);
            player1.Hand[4] = null;

            player2.Hand[0] = new Card(Diamonds, Two);
            player2.Hand[1] = new Card(Spades, Two);
            player2.Hand[2] = new Card(Diamonds, Three);
            player2.Hand[3] = new Card(Spades, Three);
            player2.Hand[4] = new Card(Diamonds, Four);

            var players = new Player[] { player1, player2 };
            var dealer = new Dealer(players);
            var pokerGame = new PokerGame(players);
            pokerGame.NewDeal += NewDeal;
            pokerGame.RecievedReplacementCards += OnRecievedReplacementCards;
            pokerGame.ShowAllHands += ShowAllHands;
            pokerGame.Draw += Draw;
            pokerGame.Winner += Winner;
            pokerGame.SelectCardsToDiscard += SelectedCardToDiscard;


            NewDeal();
            OnRecievedReplacementCards(player1);
            ShowAllHands();
            Draw(new Player[] {player1, player2});
            Winner(player1);
            SelectedCardToDiscard(player1);
            //Act

            //Assert
            Assert.DoesNotThrow(delegate { pokerGame.PlayGame(dealer); });
        }

        private void SelectedCardToDiscard(IPlayer player)
        {
        }

        private void Winner(IPlayer winner)
        {
        }

        private void Draw(IPlayer[] tiedPlayers)
        {
        }

        private void ShowAllHands()
        {
        }

        [Test]
        public void SaveGame_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var player1 = new Player("c3", 8);
            var player2 = new Player("d4", 7);
            var players = new Player[] { player1, player2 };
            var pokerGame = new PokerGame(players);
            //Act

            //Assert
            Assert.DoesNotThrow(delegate { _pokerGame.SaveGame($"SavePoker-{Guid.NewGuid()}"); });
        }

        [Test]
        public void RunGame_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
           _pokerGame.gameIsOver = true;

            //Act
            //Assert
            Assert.DoesNotThrow(delegate { _pokerGame.RunGame(); });
        }

    }
}
