namespace MatchMaker.Data_Bags.Tanks.TierIX
{
    public class T92E1 : ITank
    {
        private readonly int _tier = 9;
        private readonly string _tankType = "Light";
        private readonly string _ranking = "Light";

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
