namespace MatchMaker.Data_Bags
{
    public class Tank
    {
        private readonly int _tier;
        private readonly string _tankType;

        public Tank(int tier, string tankType)
        {
            _tier = tier;
            _tankType = tankType;
        }

        public bool IsTier(int tier)
        {
            return tier == _tier;
        }

        public bool IsTankType(string tankType)
        {
            return _tankType == tankType;
        }
    }
}
