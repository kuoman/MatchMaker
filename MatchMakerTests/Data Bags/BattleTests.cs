using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class BattleTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfTeamsAreReadyToFight()
        {
            // arrange
            IBattle battle = new Battle();

            for (int i = 0; i < 7; i++)
            {
                battle.AddQueueItemToTeamA(CreateQueueItem());
                battle.AddQueueItemToTeamB(CreateQueueItem());
            }

            // act // assert
            battle.IsReadyToFight().Should().BeTrue();
            battle.IsNotReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamBNotReadyToFight()
        {
            // arrange
            IBattle battle = new Battle();

            for (int i = 0; i < 7; i++)
            {
                battle.AddQueueItemToTeamA(CreateQueueItem());
            }

            for (int i = 0; i < 6; i++)
            {
                battle.AddQueueItemToTeamB(CreateQueueItem());
            }
            // act // assert
            battle.IsReadyToFight().Should().BeFalse();
            battle.IsNotReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamANotReadyToFight()
        {
            // arrange
            IBattle battle = new Battle();

            for (int i = 0; i < 7; i++)
            {
                battle.AddQueueItemToTeamB(CreateQueueItem());
            }

            for (int i = 0; i < 6; i++)
            {
                battle.AddQueueItemToTeamA(CreateQueueItem());
            }

            // act // assert
            battle.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnAssignedQueueItemsToQueueItemsList()
        {
            // arrange
            IBattle battle = new Battle();

            QueueItem queueItem01 = new QueueItem(new Player((int) 1, (double) 50d, (int) 499), new Tank((int) 1, (string) "Heavy", (string) "Heavy"));
            battle.AddQueueItemToTeamA(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player((int) 2, (double) 50d, (int) 499), new Tank((int) 1, (string) "Heavy", (string) "Heavy"));
            battle.AddQueueItemToTeamB(queueItem02);

            QueueItems queueItems = new QueueItems();

            // act
            QueueItems returnQueueItems = battle.FlushTeamsBackToQueue(queueItems);

            // assert
            battle.ContainsPlayer(new Player((int) 1, (double) 50d, (int) 499)).Should().BeFalse();
            battle.ContainsPlayer(new Player((int) 2, (double) 50d, (int) 499)).Should().BeFalse();
            returnQueueItems.Contains(queueItem01).Should().BeTrue();
            returnQueueItems.Contains(queueItem02).Should().BeTrue();
        }

        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player((int) 1, (double) 50d, (int) 499), new Tank((int) 1, (string) null, (string) "Heavy"));
        }
    }
}



