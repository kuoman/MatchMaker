using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
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

            BattleFactory battleFactory = new BattleFactory();

            // act
            IBattle battle = battleFactory.Create(new SimpleStrategy(), queueItems);
            
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

            BattleFactory battleFactory = new BattleFactory();

            // act
            IBattle battle = battleFactory.Create(new SimpleStrategy(), queueItems);

            //arrange
            battle.IsReadyToFight().Should().BeFalse();
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

            BattleFactory battleFactory = new BattleFactory();

            // act
            IBattle battle = battleFactory.Create(new SameClass(), queueItems);

            // assert
            battle.IsReadyToFight().Should().BeTrue();
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

            BattleFactory battleFactory = new BattleFactory();

            IBattle battle = battleFactory.Create(new SameTier(5), queueItems);

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

            BattleFactory battleFactory = new BattleFactory();

            // act
            IBattle battle = battleFactory.Create(new TwoTier(1), queueItems);

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

            BattleFactory battleFactory = new BattleFactory();

            // act
            IBattle battle = battleFactory.Create(new SameTierSameClass(1, "Heavy"), queueItems);

            // assert
            battle.IsReadyToFight().Should().BeTrue();
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
