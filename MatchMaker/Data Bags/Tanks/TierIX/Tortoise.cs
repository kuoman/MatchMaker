namespace MatchMaker.Data_Bags.Tanks.TierIX
{
    public class Tortoise : ITank
    {
        private readonly int _tier = 9;
        private readonly string _tankType = "Tank Destroyer";
        private readonly string _ranking = "Tank Destroyer";

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
            return _ranking == tankRanking;
        }
    }
}
