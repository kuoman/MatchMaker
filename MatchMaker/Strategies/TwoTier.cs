using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class TwoTier : IStrategy
    {
        private readonly int _tier;

        public TwoTier(int tier)
        {
            _tier = tier;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            return CreateMatchPair(queueItems, queueItem).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            IMatchPair matchPair = queueItems.ByTier(queueItem).GetMatchPair(queueItems, queueItem);

            if (matchPair.IsPairFull()) return matchPair;

            return queueItems.ByTier(GetFallbackTier(_tier)).GetMatchPair(queueItems, queueItem);
        }

        // todo: how do I do that with good OOP
        private int GetFallbackTier(int tier)
        {
            if (tier == 1)
            {
                return tier + 1;
            }

            return tier - 1;
        }
    }
}