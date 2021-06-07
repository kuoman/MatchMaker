using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class MatchPairTests
    {
        [TestMethod]
        public void ShouldContainItems()
        {
            // arrange
            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));
            QueueItem queueItem02 = new QueueItem(ObjectBuider.CreatePlayer(3, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));

            // act
            MatchPair matchPair = new MatchPair(queueItem01, queueItem02);

            // assert
            matchPair.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem02).Should().BeTrue();
            matchPair.Contains(new QueueItem(ObjectBuider.CreatePlayer(33, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"))).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnPairFull()
        {
            // arrange
            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));

            // act
            MatchPair matchPair = new MatchPair(queueItem01, null);

            // assert
            matchPair.IsPairFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnPairFullSecond()
        {
            // arrange
            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));

            // act
            MatchPair matchPair = new MatchPair(null, queueItem01);

            // assert
            matchPair.IsPairFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldAddMatchQueueItemsToBattle()
        {
            // arrange 
            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));
            QueueItem queueItem02 = new QueueItem(ObjectBuider.CreatePlayer(3, 50d, 499), ObjectBuider.CreateTank(1, "Medium", "Heavy"));
            MatchPair matchPair = new MatchPair(queueItem01, queueItem02);

            IBattle battleReady = new Battle();

            // act
            IBattle returnBattle = matchPair.AddMatchToBattle(battleReady);

            // assert
            returnBattle.ContainsPlayer(ObjectBuider.CreatePlayer(1, 50d, 499));
            returnBattle.ContainsPlayer(ObjectBuider.CreatePlayer(3, 50d, 499));
        }
    }
}