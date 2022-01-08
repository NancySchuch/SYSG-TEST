using NUnit.Framework;
using Poker.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokerLib.UnitTests
{
    [TestFixture]
    public class GameFactoryTests
    {
        [Test]
        public void NewGame_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            string [] playerNames = new string[]{"Daniel", "Malin"};

            //Act
            //Assert
            Assert.DoesNotThrow(delegate { GameFactory.NewGame(playerNames); });
        }

        [Test]
        public void LoadGame_HappyCase_ShouldNotThrowErrors()
        {
            //Arrange
            var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/savedgame";
            //Act
            //Assert
            Assert.DoesNotThrow(delegate { GameFactory.LoadGame(path); });
        }
    }
}
