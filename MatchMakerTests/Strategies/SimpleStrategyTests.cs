using System.Collections.Generic;
using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleStrategy = MatchMaker.Strategies.SimpleStrategy;

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
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            // act
            BattleReady battleReady = (BattleReady)simpleStrategy.CreateBattle(queueItems);

            // assert
            battleReady.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldReturnBattleWithTeamsWithPlayerLists()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();

            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            // act
            BattleReady battleReady = (BattleReady)simpleStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnBattleNotReadyIfTeamsAreNotReady()
        {
            // arrange
            List<QueueItem> queueItems = new List<QueueItem>();

            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            SimpleStrategy simpleStrategy = new SimpleStrategy();

            // act
            IBattle battleReady = simpleStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeFalse();
        }
    }
}
