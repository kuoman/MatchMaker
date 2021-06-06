using MatchMaker.Data_Bags.Tanks;

namespace MatchMaker.Data_Bags
{
    public class QueueItem
    {
        private readonly Player _player;
        private readonly Tank _tank;
        private QueueItem _platoonMate;

        public QueueItem(Player player, Tank tank)
        {
            _player = player;
            _tank = tank;
        }

        public bool HasPlayer(Player player)
        {
            return _player.Equals(player);
        }

        public bool IsTier(Tank tank)
        {
            return _tank.IsSameTankTier(tank);
        }

        public bool IsTier(QueueItem queueItem)
        {
            return queueItem.IsTier(_tank);
        }

        public bool IsTankType(Tank tank)
        {
            return _tank.IsSameTankType(tank);
        }

        public bool IsTankType(QueueItem queueItem)
        {
            return queueItem.IsTankType(_tank);
        }

        public bool IsRank(Tank tank)
        {
            return _tank.IsSameTankRank(tank);
        }

        public bool IsRank(QueueItem queueItem)
        {
            return queueItem.IsRank(_tank);
        }


        public bool IsSameWinRateCategory(Player player)
        {
            return _player.IsSameWinRateCategory(player);
        }

        public bool IsSameWinRateCategory(QueueItem queueItem)
        {
            return queueItem.IsSameWinRateCategory(_player);
        }

        public bool IsNextTierTank(Tank tank)
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

        public bool IsNotInPlatoon()
        {
            return !IsInPlatoon();
        }

        public IMatchPair GetMatchForPlatoonMateTeamA(QueueItems queueItems)
        {
            return queueItems.GetMatchPairTeamA(queueItems, _platoonMate);
        }

        public IMatchPair GetMatchForPlatoonMateTeamB(QueueItems queueItems)
        {
            return queueItems.GetMatchPairTeamB(queueItems, _platoonMate);
        }
    }
}