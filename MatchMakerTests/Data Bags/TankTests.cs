using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Data_Bags.Tanks.Tier01;
using MatchMaker.Data_Bags.Tanks.Tier02;
using MatchMaker.Data_Bags.Tanks.Tier03;
using MatchMaker.Data_Bags.Tanks.Tier08;
using MatchMaker.Data_Bags.Tanks.Tier09;
using MatchMaker.Data_Bags.Tanks.Tier10;
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

        [TestMethod]
        public void ShouldValidateNextLevelMinByInt()
        {
            ITank tier1 = new PzKpfwIi();

            tier1.IsNextTierTank(2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldValidateNextLevelByInt()
        {
            ITank tier9 = new E75();

            tier9.IsNextTierTank(10).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMaxByInt()
        {
            ITank tier10 = new E100();

            tier10.IsNextTierTank(9).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldInValidateNextLevelByInt()
        {
            ITank tier9 = new E75();

            tier9.IsNextTierTank(9).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextLevel()
        {
            ITank tier9 = new E75();

            tier9.IsNextTierTank(new T110E5()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMismatch()
        {
            ITank otherTank = new E100();

            otherTank.IsNextTierTank(new T110E5()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMismatchx()
        {
            ITank otherTank = new E100();

            otherTank.IsNextTierTank(new T49()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMismatch10()
        {
            ITank otherTank = new E100();

            otherTank.IsNextTierTank(new Leopard1()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMismatch1()
        {
            ITank otherTank = new PzKpfwIi();

            otherTank.IsNextTierTank(new PzKpfwIi()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMatchTier1()
        {
            ITank otherTank = new PzKpfwIi();

            otherTank.IsNextTierTank(new M3Stewart()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMatchTier2()
        {
            ITank otherTank = new M3Stewart();

            otherTank.IsNextTierTank(new PzKpfwIi()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldValidateNextLevelMisMatchTier2()
        {
            ITank otherTank = new M3Stewart();

            otherTank.IsNextTierTank(new M5Stuart()).Should().BeFalse();
        }
    }
}

