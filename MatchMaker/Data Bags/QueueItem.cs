using MatchMaker.Data_Bags.Tanks;

namespace MatchMaker.Data_Bags
{
    public class QueueItem
    {
        private readonly Player _player;
        private readonly ITank _tank;
        private QueueItem _platoonMate;

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

        public bool IsTier(ITank tank)
        {
            return _tank.IsSameTankTier(tank);
        }

        public bool IsTier(QueueItem queueItem)
        {
            return queueItem.IsTier(_tank);
        }

        public bool IsTankType(string type)
        {
            return _tank.IsTankType(type);
        }

        public bool IsTankType(ITank tank)
        {
            return _tank.IsSameTankType(tank);
        }
        public bool IsTankType(QueueItem queueItem)
        {
            return queueItem.IsTankType(_tank);
        }

        public bool IsRank(string rank)
        {
            return _tank.IsRanking(rank);
        }

        public bool IsRank(ITank tank)
        {
            return _tank.IsSameTankRank(tank);
        }

        public bool IsRank(QueueItem queueItem)
        {
            return queueItem.IsRank(_tank);
        }

        public bool IsSameWinRateCategory(int winRateCategory)
        {
            return _player.IsSameWinRateCategory(winRateCategory);
        }

        public bool IsSameWinRateCategory(Player player)
        {
            return _player.IsSameWinRateCategory(player);
        }

        public bool IsSameWinRateCategory(QueueItem queueItem)
        {
            return queueItem.IsSameWinRateCategory(_player);
        }

        public bool IsNextTierTank(ITank tank)
        {
            return _tank.IsNextTierTank(tank);
        }

        public bool IsSameNumBattlesCategory(Player player)
        {
            return _player.IsSameNumBattlesCategory(player);
        }

        public bool IsSameNumBattlesCategory(QueueItem queueItemOther)
        {
            return queueItemOther.IsSameNumBattlesCategory(_player);
        }

        public void AddPlatoonMate(QueueItem queueItem)
        {
            _platoonMate = queueItem;
            queueItem._platoonMate = this;
        }

        public bool IsInPlatoon()
        {
            return _platoonMate != null;
        }

        /*public IMatchPair GetMatchForPlatoonMate(QueueItems queueItems)
        {
            return queueItems.GetMatchPair(queueItems, _platoonMate);
        }*/
        public bool IsNotInPlatoon()
        {
            return !IsInPlatoon();
        }
    }
}