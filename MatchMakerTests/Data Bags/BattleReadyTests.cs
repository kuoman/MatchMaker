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
            Battle battle = new Battle();

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
        public void ShouldReturnFalseIfTeamsBNotReadyToFight()
        {
            // arrange
            Battle battle = new Battle();

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
        public void ShouldReturnFalseIfTeamsANotReadyToFight()
        {
            // arrange
            Battle battle = new Battle();

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

        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player(1), new Tank(1, null));
        }


    }
}



