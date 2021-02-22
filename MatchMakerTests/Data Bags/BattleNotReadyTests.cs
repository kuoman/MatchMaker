using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class BattleNotReadyTests
    {
        [TestMethod]
        public void ShouldBeBattleNotReady()
        {
            // arrange
            BattleNotReady battleNotReady = new BattleNotReady();

            // act // assert
            battleNotReady.IsReadyToFight().Should().BeFalse();
        }
    }
}
