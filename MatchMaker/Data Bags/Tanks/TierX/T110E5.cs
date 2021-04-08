using System;

namespace MatchMaker.Data_Bags.Tanks.TierX
{
    public class T110E5 : ITank
    {
        private readonly int _tier = 10;
        private readonly string _tankType = "Heavy";
        private readonly string _ranking = "Heavy";
        public bool IsTier(int tier)
        {
            throw new NotImplementedException();
        }

        public bool IsTankType(string tankType)
        {
            throw new NotImplementedException();
        }

        public bool IsRanking(string tankRanking)
        {
            throw new NotImplementedException();
        }
    }
}