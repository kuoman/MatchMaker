namespace MatchMaker.Data_Bags.Tanks.TierIX
{
    public class Mauchen : ITank
    {
        private readonly int _tier = 9;
        private readonly string _tankType = "Heavy";
        private readonly string _ranking = "Super Heavy";

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
