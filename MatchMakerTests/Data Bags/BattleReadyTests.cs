using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class BattleReadyTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfTeamsAreReadyToFight()
        {
            // arrange
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamA(CreateQueueItem());
                battleReady.AddQueueItemToTeamB(CreateQueueItem());
            }

            // act // assert
            battleReady.IsReadyToFight().Should().BeTrue();
            battleReady.IsNotReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamsBNotReadyToFight()
        {
            // arrange
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamA(CreateQueueItem());
            }

            for (int i = 0; i < 6; i++)
            {
                battleReady.AddQueueItemToTeamB(CreateQueueItem());
            }
            // act // assert
            battleReady.IsReadyToFight().Should().BeFalse();
            battleReady.IsNotReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamsANotReadyToFight()
        {
            // arrange
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamB(CreateQueueItem());
            }

            for (int i = 0; i < 6; i++)
            {
                battleReady.AddQueueItemToTeamA(CreateQueueItem());
            }

            // act // assert
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldRemoveQueueItemsWhenFinalizing()
        {
            // arrange
            BattleReady battleReady = new BattleReady();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Medium"));
            QueueItem queueItem02 = new QueueItem(new Player(2), new Tank(2, "Heavy"));

            battleReady.AddQueueItemToTeamA(queueItem01);
            battleReady.AddQueueItemToTeamB(queueItem02);

            QueueItems queueItems = new QueueItems();

            queueItems.Add(queueItem01);
            queueItems.Add(queueItem02);

            // act
            battleReady.FinalizeBattle(queueItems);

            // assert
            queueItems.Contains(queueItem01).Should().BeFalse();
            queueItems.Contains(queueItem02).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(1)).Should().BeTrue();
            battleReady.ContainsPlayer(new Player(2)).Should().BeTrue();
        }

        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player(1), new Tank(1, null));
        }


    }
}



