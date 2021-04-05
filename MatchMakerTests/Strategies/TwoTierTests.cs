using FluentAssertions;
using MatchMaker;
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

            QueueItems queueItems = new QueueItems();

            for (int i = 0; i < 14; i++)
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

            QueueItems queueItems = new QueueItems();
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

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 1, queueItems);
            AddGivenNumberOfTanksOfTier(7, 6, queueItems);
            AddGivenNumberOfTanksOfTier(8, 5, queueItems);

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

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 2, queueItems);
            AddGivenNumberOfTanksOfTier(7, 7, queueItems);
            AddGivenNumberOfTanksOfTier(8, 6, queueItems);

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

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 6, queueItems);
            AddGivenNumberOfTanksOfTier(7, 1, queueItems);
            AddGivenNumberOfTanksOfTier(8, 2, queueItems);

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFinalizeBattle()
        {
            // arrange
            IStrategy strategy = new TwoTier(1);

            QueueItem queueItem = new QueueItem(new Player(345), new Tank(1, "Heavy"));

            QueueItems queueItems = new QueueItems();
            
            queueItems.Add(queueItem);
            AddGivenNumberOfTanksOfTier(4, 6, queueItems);
            AddGivenNumberOfTanksOfTier(6, 1, queueItems);
            AddGivenNumberOfTanksOfTier(8, 2, queueItems);

            // act
            IBattle battleReady = strategy.CreateBattle(queueItems);

            // assert
            queueItems.Contains(queueItem).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(345)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateMatchPairForTargetTier()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new TwoTier(3).CreateMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateMatchPairForFallBackTier()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(4), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new TwoTier(4).CreateMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
            matchPair.IsPairFull().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnMatchNotFullForInsufficientNumbers()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(5, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(4), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new TwoTier(4).CreateMatchPair(queueItems);

            // assert
            matchPair.IsPairFull().Should().BeFalse();
        }


        [TestMethod]
        public void ShouldPopulateBattle()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(4), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new TwoTier(4).PopulateBattle(queueItems, new BattleReady());

            // assert
            battle.ContainsPlayer(new Player(1)).Should().BeTrue();
            battle.ContainsPlayer(new Player(2)).Should().BeTrue();
        }
        private QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier, "Heavy"));
        }

        private void AddGivenNumberOfTanksOfTier(int numberToAdd, int tier, QueueItems queueItems)
        {
            for (int i = 0; i < numberToAdd; i++)
            {
                queueItems.Add(CreateQueueItem(tier));
            }
        }
    }
}

