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

        public bool IsTier(int tier)
        {
            return tier == _tier;
        }

        public bool IsTankType(string tankType)
        {
            return _tankType == tankType;
        }

        public bool IsRanking(string tankRanking)
        {
            return _rank == tankRanking;
        }

        public bool IsSameTankType(ITank tank)
        {
            return tank.IsTankType(_tankType);
        }

        public bool IsSameTankTier(ITank tank)
        {
            return tank.IsTier(_tier);
        }

        public bool IsSameTankRank(ITank tank)
        {
            return tank.IsRanking(_rank);
        }
    }
}
