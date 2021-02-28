namespace MatchMaker.Data_Bags
{
    public class Tank
    {
        private readonly int _tier;

        public Tank(int tier)
        {
            _tier = tier;
        }

        public bool IsTier(int tier)
        {
            return tier == _tier;
        }
    }
}
