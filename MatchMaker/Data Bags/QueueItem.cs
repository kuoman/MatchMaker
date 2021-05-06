using MatchMaker.Data_Bags.Tanks;

namespace MatchMaker.Data_Bags
{
    public class QueueItem
    {
        private readonly Player _player;
        private readonly ITank _tank;

        public QueueItem(Player player, ITank tank)
        {
            _player = player;
            _tank = tank;
        }

        public bool HasPlayer(Player player)
        {
            return _player.Equals(player);
        }

        public bool IsTier(int tier)
        {
            return _tank.IsTier(tier);
        }

        public bool IsTankType(string heavy)
        {
            return _tank.IsTankType(heavy);
        }

        public bool IsRank(string rank)
        {
            return _tank.IsRanking(rank);
        }

        public bool IsSameWinRateCategory(int winRateCategory)
        {
            return _player.IsSameWinRateCategory(winRateCategory);
        }
    }
}