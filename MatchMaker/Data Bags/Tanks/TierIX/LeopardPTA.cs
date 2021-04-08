namespace MatchMaker.Data_Bags.Tanks.TierIX
{
    public class LeopardPTA : ITank
    {
        private readonly int _tier = 9;
        private readonly string _tankType = "Medium";
        private readonly string _ranking = "Damage Medium";

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
