using System.Collections.Generic;
using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SimpleStrategyTests
    {
        [TestMethod]
        public void ShouldReturnBattle()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();
            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            // act
            BattleReady battleReady = (BattleReady)simpleStrategy.CreateBattle(queueItems);

            // assert
            battleReady.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldReturnBattleReadyThatsReadyToFight()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();

            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            BattleReady battleReady = (BattleReady)simpleStrategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnBattleNotReadyIfTeamsAreNotReady()
        {
            // arrange
            List<QueueItem> queueItems = new List<QueueItem>();

            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            SimpleStrategy simpleStrategy = new SimpleStrategy();

            IBattle battleReady = simpleStrategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeFalse();
        }
        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player(1), new Tank(1));
        }
    }

}