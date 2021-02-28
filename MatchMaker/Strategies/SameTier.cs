using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTier : IStrategy
    {
        private readonly int _tier;

        public SameTier(int tier)
        {
            _tier = tier;
        }

        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            List<QueueItem> sameTierTanks = SortForTier(queueItems);

            if (13 >= sameTierTanks.Count) return new BattleNotReady();

            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 14; i = i + 2)
            {
                battleReady.AddQueueItemToTeamA(sameTierTanks[i]);
                battleReady.AddQueueItemToTeamB(sameTierTanks[i + 1]);
            }

            return battleReady;
        }

        private List<QueueItem> SortForTier(List<QueueItem> queueItems)
        {
            List<QueueItem> sameTierTanks = new List<QueueItem>();

            foreach (QueueItem queueItem in queueItems)
            {
                if (queueItem.IsTier(_tier)) sameTierTanks.Add(queueItem);
            }

            return sameTierTanks;
        }
    }
}