using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class TwoTierTests
    {
        [TestMethod]
        public void ShouldCreateBattleReadyWith14QueueItemsOfSameTier()
        {
            // arrange
            IStrategy strategy = new TwoTier(5);

            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 7; i++)
            {
                queueItems.Add(CreateQueueItem(5));
                queueItems.Add(CreateQueueItem(6));
            }

            // act
            BattleReady battleReady = (BattleReady)strategy.CreateBattle(queueItems);

            // assert
            battleReady.Should().NotBeNull();
        }


        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier));
        }
    }

    public class TwoTier : IStrategy
    {
        private readonly int _tier;

        public TwoTier(int tier)
        {
            _tier = tier;
        }

        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            return new BattleReady();
        }
    }
}

