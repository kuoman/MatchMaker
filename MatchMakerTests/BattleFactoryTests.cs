using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using MatchMakerTests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class BattleFactoryTests
    {
        [TestMethod]
        public void ShouldReturnBattleReadyThatIsReadyToFightForSimpleStrategy()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem(i, 1, "Heavy"));
            }

            // act
            IBattle battle = BattleFactory.Create(new SimpleStrategy(), queueItems);
            
            //arrange
            battle.IsReadyToFight().Should().BeTrue();
            battle.ContainsPlayer(new Player(13)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnBattleNotReadyForIncompleteNumbers()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem(i, 1, "Heavy"));
            }

            // act
            IBattle battle = BattleFactory.Create(new SimpleStrategy(), queueItems);

            //arrange
            battle.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateBattleForSameTierStrategy()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem(i, 3, "Heavy"));
                queueItems.Add(CreateQueueItem(i+20, 5, "Heavy"));
            }

            IBattle battle = BattleFactory.Create(new SameTier(5), queueItems);

            // act // arrange
            battle.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleForTwoTiersStrategy()
        {
            // arrange

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 6, "Heavy", queueItems, 10);
            AddGivenNumberOfTanksOfTier(7, 1, "Heavy", queueItems, 20);
            AddGivenNumberOfTanksOfTier(8, 2, "Heavy", queueItems, 30);

            // act
            IBattle battle = BattleFactory.Create(new TwoTier(1), queueItems);

            // assert
            battle.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleForSameTierSameClassStrategy()
        {
            // arrange

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 6, "Heavy", queueItems, 10);
            AddGivenNumberOfTanksOfTier(7, 1, "Light", queueItems, 20);
            AddGivenNumberOfTanksOfTier(14, 1, "Heavy", queueItems, 30);
            AddGivenNumberOfTanksOfTier(8, 2, "Heavy", queueItems, 40);

            // act
            IBattle battle = BattleFactory.Create(new SameTierSameClass(1, "Heavy"), queueItems);

            // assert
            battle.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleForSameClassStrategy()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            int id = 0;
            id = AddGivenNumberOfTanksOfTier(4, 3, "Heavy", queueItems, id);
            id = AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems, id);
            id = AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems, id);
            AddGivenNumberOfTanksOfTier(9, 3, "Light", queueItems, id);

            // act
            IBattle battle = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battle.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldAutoFillTankTypesForMultiClass()
        {
            // arrange

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 3, "Heavy", queueItems, 1);
            AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems, 10);
            AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems, 20);
            AddGivenNumberOfTanksOfTier(9, 3, "Light", queueItems, 30);

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyForFullMixedTanksThatIsReadyToFight2()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(3, 3, "Heavy", queueItems, 1);
            AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems, 10);
            AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems, 20);
            AddGivenNumberOfTanksOfTier(7, 3, "Light", queueItems, 30);

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotContainMoreThanThreeTanksOfType()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem = new QueueItem(new Player(0), new Tank(3, "Heavy"));
            queueItems.Add(queueItem);
            queueItems.Add(new QueueItem(new Player(1), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(2), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(3), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(4), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(5), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(6), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(7), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(8), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(9), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(10), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(11), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(12), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(13), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(14), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(15), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(16), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(17), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(18), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(19), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(20), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(21), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(22), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(23), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(24), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(25), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(26), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(27), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(28), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(29), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(30), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(31), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(32), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(33), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(34), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(35), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(36), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(37), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(38), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(39), new Tank(3, "Light")));

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
            battleReady.ContainsPlayer(new Player(6)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(16)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(26)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(36)).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFinalizeBattle()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem = new QueueItem(new Player(0), new Tank(3, "Heavy"));
            queueItems.Add(queueItem);
            queueItems.Add(new QueueItem(new Player(1), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(2), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(3), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(4), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(5), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(6), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(7), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(8), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(9), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(10), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(11), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(12), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(13), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(14), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(15), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(16), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(17), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(18), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(19), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(20), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(21), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(22), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(23), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(24), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(25), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(26), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(27), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(28), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(29), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(30), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(31), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(32), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(33), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(34), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(35), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(36), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(37), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(38), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(39), new Tank(3, "Light")));

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            queueItems.Contains(queueItem).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(1)).Should().BeTrue();
        }

        private QueueItem CreateQueueItem(int playerId, int tier, string tankType)
        {
            return new QueueItem(new Player(playerId), new Tank(tier, tankType));
        }

        private int AddGivenNumberOfTanksOfTier(int numberToAdd, int tier, string tankType, QueueItems queueItems, int id)
        {
            for (int i = 0; i < numberToAdd; i++)
            {
                id = id + 1;
                queueItems.Add(CreateQueueItem(id, tier, tankType));
            }

            return id;
        }
    }
}
