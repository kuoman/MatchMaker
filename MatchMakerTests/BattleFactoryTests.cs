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

            QueueItem item100 = CreateQueueItem(100, 1, "Heavy");
            queueItems.Add(item100);

            for (int i = 0; i < 12; i++)
            {
                QueueItem queueItem = CreateQueueItem(i, 1, "Heavy");
                queueItems.Add(queueItem);
            }

            // act
            IBattle battle = BattleFactory.Create(new SimpleStrategy(), queueItems);

            //arrange
            battle.IsReadyToFight().Should().BeFalse();
            battle.ContainsPlayer(new Player(100)).Should().BeFalse();
            queueItems.Contains(item100).Should().BeTrue();
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
        public void ShouldFlushTanksIfNotEnoughForBattle()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem item00 = CreateQueueItem(100, 1, "Heavy");
            queueItems.Add(item00);

            AddGivenNumberOfTanksOfTier(3, 3, "Heavy", queueItems, 1);
            AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems, 10);
            AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems, 20);
            AddGivenNumberOfTanksOfTier(1, 3, "Light", queueItems, 30);

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeFalse();
            queueItems.Contains(item00).Should().BeTrue();
            battleReady.ContainsPlayer(new Player(100)).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyForFullMixedTanksThatIsReadyToFight2()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 3, "Heavy", queueItems, 1);
            AddGivenNumberOfTanksOfTier(4, 3, "Medium", queueItems, 10);
            AddGivenNumberOfTanksOfTier(4, 3, "TankDestroyer", queueItems, 20);
            AddGivenNumberOfTanksOfTier(3, 3, "Light", queueItems, 30);

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
        public void ShouldNotRemoveQueuesFromQueueIfNotAddedToBattle()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem item00 = new QueueItem(new Player(0), new Tank(3, "Heavy"));
            queueItems.Add(item00);
            QueueItem item01 = new QueueItem(new Player(1), new Tank(3, "Heavy"));
            queueItems.Add(item01);
            QueueItem item02 = new QueueItem(new Player(2), new Tank(3, "Heavy"));
            queueItems.Add(item02);
            QueueItem item03 = new QueueItem(new Player(3), new Tank(3, "Heavy"));
            queueItems.Add(item03);
            QueueItem item04 = new QueueItem(new Player(4), new Tank(3, "Heavy"));
            queueItems.Add(item04);
            QueueItem item05 = new QueueItem(new Player(5), new Tank(3, "Heavy"));
            queueItems.Add(item05);
            QueueItem item06 = new QueueItem(new Player(6), new Tank(3, "Heavy"));
            queueItems.Add(item06);
            QueueItem item07 = new QueueItem(new Player(7), new Tank(3, "Heavy"));
            queueItems.Add(item07);
            queueItems.Add(new QueueItem(new Player(8), new Tank(3, "Heavy")));
            queueItems.Add(new QueueItem(new Player(9), new Tank(3, "Heavy")));
            QueueItem item10 = new QueueItem(new Player(10), new Tank(3, "Medium"));
            queueItems.Add(item10);
            QueueItem item11 = new QueueItem(new Player(11), new Tank(3, "Medium"));
            queueItems.Add(item11);
            QueueItem item12 = new QueueItem(new Player(12), new Tank(3, "Medium"));
            queueItems.Add(item12);
            QueueItem item13 = new QueueItem(new Player(13), new Tank(3, "Medium"));
            queueItems.Add(item13);
            QueueItem item14 = new QueueItem(new Player(14), new Tank(3, "Medium"));
            queueItems.Add(item14);
            QueueItem item15 = new QueueItem(new Player(15), new Tank(3, "Medium"));
            queueItems.Add(item15);
            QueueItem item16 = new QueueItem(new Player(16), new Tank(3, "Medium"));
            queueItems.Add(item16);
            QueueItem item17 = new QueueItem(new Player(17), new Tank(3, "Medium"));
            queueItems.Add(item17);
            queueItems.Add(new QueueItem(new Player(18), new Tank(3, "Medium")));
            queueItems.Add(new QueueItem(new Player(19), new Tank(3, "Medium")));
            QueueItem item20 = new QueueItem(new Player(20), new Tank(3, "TankDestroyer"));
            queueItems.Add(item20); 
            QueueItem item21 = new QueueItem(new Player(21), new Tank(3, "TankDestroyer"));
            queueItems.Add(item21);
            QueueItem item22 = new QueueItem(new Player(22), new Tank(3, "TankDestroyer"));
            queueItems.Add(item22);
            QueueItem item23 = new QueueItem(new Player(23), new Tank(3, "TankDestroyer"));
            queueItems.Add(item23);
            QueueItem item24 = new QueueItem(new Player(24), new Tank(3, "TankDestroyer"));
            queueItems.Add(item24);
            QueueItem item25 = new QueueItem(new Player(25), new Tank(3, "TankDestroyer"));
            queueItems.Add(item25);
            QueueItem item26 = new QueueItem(new Player(26), new Tank(3, "TankDestroyer"));
            queueItems.Add(item26);
            QueueItem item27 = new QueueItem(new Player(27), new Tank(3, "TankDestroyer"));
            queueItems.Add(item27);
            queueItems.Add(new QueueItem(new Player(28), new Tank(3, "TankDestroyer")));
            queueItems.Add(new QueueItem(new Player(29), new Tank(3, "TankDestroyer")));
            QueueItem item30 = new QueueItem(new Player(30), new Tank(3, "Light"));
            queueItems.Add(item30);
            QueueItem item31 = new QueueItem(new Player(31), new Tank(3, "Light"));
            queueItems.Add(item31);
            QueueItem item32 = new QueueItem(new Player(32), new Tank(3, "Light"));
            queueItems.Add(item32);
            QueueItem item33 = new QueueItem(new Player(33), new Tank(3, "Light"));
            queueItems.Add(item33);
            QueueItem item34 = new QueueItem(new Player(34), new Tank(3, "Light"));
            queueItems.Add(item34);
            QueueItem item35 = new QueueItem(new Player(35), new Tank(3, "Light"));
            queueItems.Add(item35);
            QueueItem item36 = new QueueItem(new Player(36), new Tank(3, "Light"));
            queueItems.Add(item36);
            QueueItem item37 = new QueueItem(new Player(37), new Tank(3, "Light"));
            queueItems.Add(item37);
            queueItems.Add(new QueueItem(new Player(38), new Tank(3, "Light")));
            queueItems.Add(new QueueItem(new Player(39), new Tank(3, "Light")));

            // act
            IBattle battleReady = BattleFactory.CreateFillBattle(new SameClass(), new TestNotRandom(), queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
            battleReady.ContainsPlayer(new Player(4)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(14)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(24)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(32)).Should().BeFalse();
            queueItems.Contains(item00).Should().BeFalse();
            queueItems.Contains(item01).Should().BeFalse();
            queueItems.Contains(item02).Should().BeFalse();
            queueItems.Contains(item03).Should().BeFalse();
            queueItems.Contains(item04).Should().BeTrue();
            queueItems.Contains(item05).Should().BeTrue();
            queueItems.Contains(item06).Should().BeTrue();
            queueItems.Contains(item07).Should().BeTrue();
            queueItems.Contains(item10).Should().BeFalse();
            queueItems.Contains(item11).Should().BeFalse();
            queueItems.Contains(item12).Should().BeFalse();
            queueItems.Contains(item13).Should().BeFalse();
            queueItems.Contains(item14).Should().BeTrue();
            queueItems.Contains(item15).Should().BeTrue();
            queueItems.Contains(item16).Should().BeTrue();
            queueItems.Contains(item17).Should().BeTrue();
            queueItems.Contains(item20).Should().BeFalse();
            queueItems.Contains(item21).Should().BeFalse();
            queueItems.Contains(item22).Should().BeFalse();
            queueItems.Contains(item23).Should().BeFalse();
            queueItems.Contains(item24).Should().BeTrue();
            queueItems.Contains(item25).Should().BeTrue();
            queueItems.Contains(item26).Should().BeTrue();
            queueItems.Contains(item27).Should().BeTrue();
            queueItems.Contains(item30).Should().BeFalse();
            queueItems.Contains(item31).Should().BeFalse();
            queueItems.Contains(item32).Should().BeTrue();
            queueItems.Contains(item33).Should().BeTrue();
            queueItems.Contains(item34).Should().BeTrue();
            queueItems.Contains(item35).Should().BeTrue();
            queueItems.Contains(item36).Should().BeTrue();
            queueItems.Contains(item37).Should().BeTrue();
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
