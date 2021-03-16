using FluentAssertions;
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

        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player(1), new Tank(1, null));
        }


    }
}



