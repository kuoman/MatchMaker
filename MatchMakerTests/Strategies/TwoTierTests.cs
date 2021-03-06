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

        [TestMethod]
        public void ShouldNotBeBattleReadyIfFewerThan14Tanks()
        {
            // arrange
            IStrategy strategy = new TwoTier(5);

            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 3; i++)
            {
                queueItems.Add(CreateQueueItem(5));
                queueItems.Add(CreateQueueItem(6));
            }

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyReadyToFightWith14QueueItemsOfTwoTiers6()
        {
            // arrange
            IStrategy strategy = new TwoTier(6);

            List<QueueItem> queueItems = new List<QueueItem>();

            queueItems = AddGivenNumberOfTanksOfTier(4, 1, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(7, 6, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(8, 5, queueItems);

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyReadyToFightWith14QueueItemsOfTwoTiers7()
        {
            // arrange
            IStrategy strategy = new TwoTier(7);

            List<QueueItem> queueItems = new List<QueueItem>();

            queueItems = AddGivenNumberOfTanksOfTier(4, 2, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(7, 7, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(8, 6, queueItems);

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }


        [TestMethod]
        public void ShouldCreateBattleReadyReadyToFightWith14QueueItemsOfTwoTiers1()
        {
            // arrange
            IStrategy strategy = new TwoTier(1);

            List<QueueItem> queueItems = new List<QueueItem>();

            queueItems = AddGivenNumberOfTanksOfTier(4, 6, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(7, 1, queueItems);
            queueItems = AddGivenNumberOfTanksOfTier(8, 2, queueItems);

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier));
        }

        private static List<QueueItem> AddGivenNumberOfTanksOfTier(int numberToAdd, int tier, List<QueueItem> list)
        {
            for (int i = 0; i < numberToAdd; i++)
            {
                list.Add(CreateQueueItem(tier));
            }

            return list;
        }
    }
}

