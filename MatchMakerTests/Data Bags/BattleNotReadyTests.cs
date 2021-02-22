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
            BattleNotReady battleNotReady = new BattleNotReady();

            battleNotReady.IsReadyToFight().Should().BeFalse();
        }
    }
}
