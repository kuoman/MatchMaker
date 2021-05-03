using MatchMaker.Data_Bags.Tanks;

namespace MatchMaker.Data_Bags
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
    }
}
