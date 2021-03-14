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
                team.QueueItemList.Add(CreateQueueItem());
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
                team.QueueItemList.Add(CreateQueueItem());
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
                team.AddQueueItem(CreateQueueItem());
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
                team.AddQueueItem(CreateQueueItem());
            }
            // act // assert
            team.TeamIsFull().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindPlayer()
        {
            // arrange
            Team team = new Team();

            Player player = new Player(1);

            team.AddQueueItem(CreateQueueItem(player));

            // act // assert
            team.HasPlayer(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindPlayer()
        {
            // arrange
            Team team = new Team();

            team.AddQueueItem(CreateQueueItem(new Player(2)));

            // act // assert
            team.HasPlayer(new Player(3)).Should().BeFalse();
        }

        private QueueItem CreateQueueItem()
        {
            return CreateQueueItem(new Player(1));
        }

        private QueueItem CreateQueueItem(Player player)
        {
            return new QueueItem(player, new Tank(1, null));
        }
    }

}



