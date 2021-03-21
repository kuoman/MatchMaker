using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using MatchMakerTests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameClassTests
    {
        [TestMethod]
        public void ShouldCreateBattleNotReadyIfFewerThan14Tanks()
        {
            // arrange
            SameClass matchingStrategy = new SameClass();

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(13, 3, "Heavy", queueItems);

            // act
            IBattle battleReady = matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateBattleNotReadyThatIsReadyToFight()
        {
            // arrange
            SameClass matchingStrategy = new SameClass();

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(13, 3, "Heavy", queueItems);
            AddGivenNumberOfTanksOfTier(1, 3, "Light", queueItems);

            // act
            IBattle battleReady = matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyForFullMixedTanksThatIsReadyToFight()
        {
            // arrange
            SameClass matchingStrategy = new SameClass();

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(4, 3, "Heavy", queueItems);
            AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems);
            AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems);
            AddGivenNumberOfTanksOfTier(9, 3, "Light", queueItems);

            // act
            IBattle battleReady = matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyForFullMixedTanksThatIsReadyToFight2()
        {
            // arrange
            SameClass matchingStrategy = new SameClass();

            QueueItems queueItems = new QueueItems();

            AddGivenNumberOfTanksOfTier(3, 3, "Heavy", queueItems);
            AddGivenNumberOfTanksOfTier(3, 3, "Medium", queueItems);
            AddGivenNumberOfTanksOfTier(5, 3, "TankDestroyer", queueItems);
            AddGivenNumberOfTanksOfTier(7, 3, "Light", queueItems);

            // act
            IBattle battleReady = matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
        }


        [TestMethod]
        public void ShouldNotContainMoreThanThreeTanksOfType()
        {
            // arrange
            SameClass matchingStrategy = new SameClass(new TestNotRandom());

            QueueItems queueItems = new QueueItems();
 
            queueItems.Add(new QueueItem(new Player(0), new Tank(3, "Heavy")));
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
            IBattle battleReady = matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.IsReadyToFight().Should().BeTrue();
            battleReady.ContainsPlayer(new Player(6)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(16)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(26)).Should().BeFalse();
            battleReady.ContainsPlayer(new Player(36)).Should().BeFalse();
        }

        private QueueItem CreateQueueItem(int tier, string tankType)
        {
            return new QueueItem(new Player(1), new Tank(tier, tankType));
        }

        private void AddGivenNumberOfTanksOfTier(int numberToAdd, int tier, string tankType, QueueItems queueItems)
        {
            for (int i = 0; i < numberToAdd; i++)
            {
                queueItems.Add(CreateQueueItem(tier, tankType));
            }
        }
    }
}
