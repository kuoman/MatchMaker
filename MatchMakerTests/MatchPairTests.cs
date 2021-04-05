using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
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
            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Medium"));
            QueueItem queueItem02 = new QueueItem(new Player(3), new Tank(1, "Medium"));

            // act
            MatchPair matchPair = new MatchPair(queueItem01, queueItem02);

            // assert
            matchPair.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem02).Should().BeTrue();
            matchPair.Contains(new QueueItem(new Player(33), new Tank(1, "Medium"))).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnPairFull()
        {
            // arrange
            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Medium"));
          
            // act
            MatchPair matchPair = new MatchPair(queueItem01, null);

            // assert
            matchPair.IsPairFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnPairFullSecond()
        {
            // arrange
            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Medium"));

            // act
            MatchPair matchPair = new MatchPair(null, queueItem01);

            // assert
            matchPair.IsPairFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldAddMatchQueueItemsToBattle()
        {
            // arrange 
            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Medium"));
            QueueItem queueItem02 = new QueueItem(new Player(3), new Tank(1, "Medium"));
            MatchPair matchPair = new MatchPair(queueItem01, queueItem02);

            IBattle battleReady = new BattleReady();

            // act
            IBattle returnBattle = matchPair.AddMatchToBattle(battleReady);

            // assert
            returnBattle.ContainsPlayer(new Player(1));
            returnBattle.ContainsPlayer(new Player(3));
        }
    }
}
