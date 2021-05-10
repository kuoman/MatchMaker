using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class TwoTier : Strategy
    {
        private readonly int _tier;

        public TwoTier(int tier)
        {
            _tier = tier;
        }

        override 
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