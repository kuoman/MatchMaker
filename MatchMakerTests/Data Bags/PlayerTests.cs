using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ShouldEquatePlayerCorrectly()
        {
            Player player = new Player(2);

            bool value = player.Equals(player);

            value.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindNotEqualsToo()
        {
            Player player = new Player(2);
            Player otherPlayer = new Player(3);

            bool value = otherPlayer.Equals(player);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotEquateNull()
        {
            Player player = new Player(2);

            bool value = player.Equals(null);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldEqualOnType()
        {
            Player player = new Player(2);

            player.Equals(new Player(4)).Should().BeFalse();
        }
    }
}

