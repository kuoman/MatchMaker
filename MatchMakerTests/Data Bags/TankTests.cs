using FluentAssertions;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Data_Bags.Tanks.Tier01;
using MatchMaker.Data_Bags.Tanks.Tier02;
using MatchMaker.Data_Bags.Tanks.Tier03;
using MatchMaker.Data_Bags.Tanks.Tier05;
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

            tank.IsSameTankTier(new Crusader()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotLevel()
        {
            Tank tank = new Tank(4, null);

            tank.IsSameTankTier(new Crusader()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldConfirmTankType()
        {
            Tank tank = new Tank(5, "Heavy");

            tank.IsSameTankType(new Mauchen()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotTankType()
        {
            Tank tank = new Tank(5, "Light");

            tank.IsSameTankType(new T110E5()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameRank()
        {
            ITank tank = new E50M();

            tank.IsSameTankRank(new Leopard1()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameRank()
        {
            ITank tank = new E50M();

            tank.IsSameTankRank(new T54()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameTankWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankType(new E100()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameTankWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankType(new E50M()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameTierWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankTier(new E100()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameTierWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankTier(new E75()).Should().BeFalse();
        }


        [TestMethod]
        public void ShouldReturnTrueIfSameRankWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankRank(new E100()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotSameRankWithTank()
        {
            ITank maus = new Maus();

            maus.IsSameTankRank(new T110E5()).Should().BeFalse();
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

