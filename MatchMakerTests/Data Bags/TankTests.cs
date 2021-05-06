using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Data_Bags.Tanks.TierIX;
using MatchMaker.Data_Bags.Tanks.TierX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class TankTests
    {
        [TestMethod]
        public void ShouldConfirmLevel()
        {
            Tank tank = new Tank(5, null);

            tank.IsTier(5).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotLevel()
        {
            Tank tank = new Tank(4, null);

            tank.IsTier(5).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldConfirmTankType()
        {
            Tank tank = new Tank(5, "Heavy");

            tank.IsTankType("Heavy").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotTankType()
        {
            Tank tank = new Tank(5, "Light");

            tank.IsTankType("Heavy").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameRank()
        {
            ITank tank = new E50M();

            tank.IsRanking("Damage Medium").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameRank()
        {
            ITank tank = new E50M();

            tank.IsRanking("Medium").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameTankWithTank()
        {
            ITank e100 = new E100();

            ITank maus = new Maus();

            maus.IsSameTankType(e100).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameTankWithTank()
        {
            ITank e50M = new E50M();

            ITank maus = new Maus();

            maus.IsSameTankType(e50M).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameTierWithTank()
        {
            ITank otherTank = new E100();

            ITank maus = new Maus();

            maus.IsSameTankTier(otherTank).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameTierWithTank()
        {
            ITank otherTank = new E75();

            ITank maus = new Maus();

            maus.IsSameTankTier(otherTank).Should().BeFalse();
        }


        [TestMethod]
        public void ShouldReturnTrueIfSameRankWithTank()
        {
            ITank otherTank = new E100();

            ITank maus = new Maus();

            maus.IsSameTankRank(otherTank).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameRankWithTank()
        {
            ITank otherTank = new T110E5();

            ITank maus = new Maus();

            maus.IsSameTankRank(otherTank).Should().BeFalse();
        }
    }
}

