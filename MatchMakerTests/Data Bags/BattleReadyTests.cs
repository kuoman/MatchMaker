using System;
using System.Collections.Generic;
using System.Text;
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
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamA(new QueueItem(new Player(), new Tank()));
                battleReady.AddQueueItemToTeamB(new QueueItem(new Player(), new Tank()));
            }

            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamsBNotReadyToFight()
        {
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamA(new QueueItem(new Player(), new Tank()));
            }

            for (int i = 0; i < 6; i++)
            {
                battleReady.AddQueueItemToTeamB(new QueueItem(new Player(), new Tank()));
            }

            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTeamsANotReadyToFight()
        {
            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamB(new QueueItem(new Player(), new Tank()));
            }

            for (int i = 0; i < 6; i++)
            {
                battleReady.AddQueueItemToTeamA(new QueueItem(new Player(), new Tank()));
            }

            battleReady.IsReadyToFight().Should().BeFalse();
        }
    }
}



