namespace MatchMaker.Data_Bags
{
    public class Player
    {
        private readonly double _winRate;
        private readonly int _numBattles;
        private readonly int _id;

        public Player(int id, double winRate, int numBattles)
        {
            _id = id;
            _winRate = winRate;
            _numBattles = numBattles;
        }

        public bool Equals(Player other)
        {
            if ((other == null) || GetType() != other.GetType())
            {
                return false;
            }

            return _id == other._id;
        }

        public bool IsSameWinRateCategory(Player otherPlayer)
        {
            return GetWinRateCategory(otherPlayer._winRate) == GetWinRateCategory(_winRate);
        }

        private int GetWinRateCategory(double winRate)
        {
            if (winRate >= 60.0d) return 5;

            if (winRate >= 55.0d) return 4;

            if (winRate >= 50.0d) return 3;

            if (winRate >= 45.0d) return 2;

            if (winRate >= 40.0d) return 1;

            return 0;
        }

        public bool IsSameNumBattlesCategory(Player otherPlayer)
        {
            return GetNumBattlesCategory(otherPlayer._numBattles) == GetNumBattlesCategory(_numBattles);
        }

        private int GetNumBattlesCategory(int numBattles)
        {
            if (numBattles >= 15001) return 4;

            if (numBattles >= 10001) return 3;

            if (numBattles >= 5001) return 2;

            if (numBattles >= 2001) return 1;

            return 0;
        }
    }
}
