using System;
using System.Text;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("ManUtd", 20);
        }

        [Test]
        public void Does_Constructor_InitializeAllElements()
        {
            Assert.AreEqual("ManUtd", team.Name);
            Assert.AreEqual(20, team.Capacity);
            Assert.IsNotNull(team.Players);
        }

        [Test]
        public void Does_NameThrowException_WhenNull()
        {
            Assert.Throws<ArgumentException>(() => team = new FootballTeam(null, 20));
        }

        [Test]
        public void Does_Capacity_ThrowExceptionWhenUnder15()
        {
            Assert.Throws<ArgumentException>(() => team = new FootballTeam("ManUtd", 10));
        }

        [Test]
        public void Does_AddNewPlayerMethod_AddPlayer()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 7, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Viktor", 10, "Forward");
            team.AddNewPlayer(player);
            Assert.Contains(player, team.Players);
            Assert.AreEqual($"Added player Viktor in position Forward with number 10", team.AddNewPlayer(player2));
        }

        [Test]
        public void Does_AddNewPlayerMethod_Return_WhenNoMoreCapacity()
        {
            FootballPlayer player1 = new FootballPlayer("Viktor", 10, "Forward");

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player1);

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player1));
        }

        [Test]
        public void Does_PickPlayerMethod_ReturnCorrectPlayer()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 13, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Viktor", 4, "Forward");

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            
            Assert.IsNotNull(team.PickPlayer("Viktor"));
        }

        [Test]
        public void Does_PlayerScoreMethod_ReturnCorrectString()
        {
            string expected = $"Viktor scored and now has 1 for this season!";
            
            FootballPlayer player = new FootballPlayer("Viktor", 4, "Forward");
            team.AddNewPlayer(player);
            
            Assert.AreEqual(expected, team.PlayerScore(4));
        }
    }
}