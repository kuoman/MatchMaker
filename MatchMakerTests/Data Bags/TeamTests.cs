using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfReadyToFight()
        {
            // arrange
            Team team = new Team();

            for (int i = 0; i < 7; i++)
            {
                team.QueueItemList.Add(new QueueItem(new Player(), new Tank()));
            }
            // act // assert
            team.HasFullTeam().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfReadyToFight()
        {
            // arrange
            Team team = new Team();

            for (int i = 0; i < 6; i++)
            {
                team.QueueItemList.Add(new QueueItem(new Player(), new Tank()));
            }
            // act // assert
            team.HasFullTeam().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfListNotFull()
        {
            // arrange
            Team team = new Team();

            for (int i = 0; i < 6; i++)
            {
                team.AddQueueItem(new QueueItem(new Player(), new Tank()));
            }
            // act // assert
            team.TeamIsFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfListFull()
        {
            // arrange
            Team team = new Team();

            for (int i = 0; i < 7; i++)
            {
                team.AddQueueItem(new QueueItem(new Player(), new Tank()));
            }
            // act // assert
            team.TeamIsFull().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindPlayer()
        {
            // arrange
            Team team = new Team();

            Player player = new Player();

            team.AddQueueItem(new QueueItem(player, new Tank()));
            // act // assert
            team.HasPlayer(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindPlayer()
        {
            // arrange
            Team team = new Team();

            team.AddQueueItem(new QueueItem(new Player(), new Tank()));
            // act // assert
            team.HasPlayer(new Player()).Should().BeFalse();
        }
    }

}



