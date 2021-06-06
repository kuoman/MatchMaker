using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
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
                team.AddQueueItem(CreateQueueItem());
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
                team.AddQueueItem(CreateQueueItem());
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

            Player player = new Player((int) 1, (double) 50d, (int) 499);

            team.AddQueueItem(CreateQueueItem(player));

            // act // assert
            team.HasPlayer(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindPlayer()
        {
            // arrange
            Team team = new Team();

            team.AddQueueItem(CreateQueueItem(new Player((int) 2, (double) 50d, (int) 499)));

            // act // assert
            team.HasPlayer(new Player((int) 3, (double) 50d, (int) 499)).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldAddQueueItemsBackToQueue()
        {
            // arrange
            Team team = new Team();

            Player player = new Player((int) 1, (double) 50d, (int) 499);
            QueueItem queueItem = new QueueItem(player, new Tank((int) 1, (string) "Heavy", (string) "Heavy"));

            team.AddQueueItem(queueItem);

            QueueItems queueItems = new QueueItems();

            // act
            team.ResetQueueItems(queueItems);

            // assert
            queueItems.Contains(queueItem).Should().BeTrue();
            team.HasPlayer(player).Should().BeFalse();
        }

        private QueueItem CreateQueueItem()
        {
            return CreateQueueItem(new Player((int) 1, (double) 50d, (int) 499));
        }

        private QueueItem CreateQueueItem(Player player)
        {
            return new QueueItem(player, new Tank((int) 1, (string) null, (string) "Heavy"));
        }
    }

}



