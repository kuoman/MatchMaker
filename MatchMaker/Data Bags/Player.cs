using System;

namespace MatchMaker.Data_Bags
{
    public class Player
    {
        private readonly double _winRate;
        private readonly int _id;

        public Player(int id)
        {
            _id = id;
        }

        public Player(int id, double winRate)
        {
            _id = id;
            _winRate = winRate;
        }

        public bool Equals(Player other)
        {
            //Check for null and compare run-time types.
            if ((other == null) || GetType() != other.GetType())
            {
                return false;
            }

            return _id == other._id;
        }

        public bool IsSameWinRateCategory(int winRateCategory)
        {
            int playerWinRateCategory = GetWinRateCategory(_winRate);

            return playerWinRateCategory == winRateCategory;
            
        }

        private int GetWinRateCategory(in double winRate)
        {
            if (winRate >= 60.0d) return 5;

            if (winRate >= 55.0d) return 4;

            if (winRate >= 50.0d) return 3;

            if (winRate >= 45.0d) return 2;

            if (winRate >= 40.0d) return 1;

            return 0;
        }
    }
}
