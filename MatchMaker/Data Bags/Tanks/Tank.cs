namespace MatchMaker.Data_Bags.Tanks
{
    public class Tank : ITank
    {
        private readonly int _tier;
        private readonly string _tankType;
        private readonly string _rank;

        public Tank(int tier, string tankType)
        {
            _tier = tier;
            _tankType = tankType;
        }
        public Tank(int tier, string tankType, string rank)
        {
            _tier = tier;
            _tankType = tankType;
            _rank = rank;
        }

        public bool IsSameTankTier(Tank tank)
        {
            return tank._tier == _tier;
        }

        public bool IsSameTankType(Tank tank)
        {
            return tank._tankType == _tankType;
        }

        public bool IsSameTankRank(Tank tank)
        {
            return tank._rank == _rank;
        }

        private bool IsNextTierTank(int tier)
        {
            if (_tier == 10) return 9 == tier;

            if (_tier == 2) return 1 == tier;
           
            return _tier == tier - 1;
        }

        public bool IsNextTierTank(Tank tank)
        {
            return tank.IsNextTierTank(_tier);
        }
    }
}
