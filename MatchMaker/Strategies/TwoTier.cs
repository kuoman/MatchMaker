using System.Collections.Generic;
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

        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            BattleReady battleReady = new BattleReady();

            List<QueueItem> sameTierTanks = SortForTier(queueItems, _tier);

            int modSameTierTanks = (sameTierTanks.Count / 2) * 2;
            for (int i = 0; i < modSameTierTanks ; i = i + 2)
            {
                battleReady.AddQueueItemToTeamA(sameTierTanks[i]);
                battleReady.AddQueueItemToTeamB(sameTierTanks[i + 1]);
            }

            if (!battleReady.IsReadyToFight())
            {
                List<QueueItem> fallBackTierTanks = GetFallbackTierTanks(queueItems);

                int modNextLowerTierTanks = (fallBackTierTanks.Count / 2) * 2;
                for (int i = 0; i < modNextLowerTierTanks; i = i + 2)
                {
                    if (battleReady.IsReadyToFight()) break;

                    battleReady.AddQueueItemToTeamA(fallBackTierTanks[i]);
                    battleReady.AddQueueItemToTeamB(fallBackTierTanks[i + 1]);
                }
            }

            if (13 >= queueItems.Count) return new BattleNotReady();

            return battleReady;
        }

        private List<QueueItem> GetFallbackTierTanks(List<QueueItem> queueItems)
        {
            if (_tier == 1)
            {
                return SortForTier(queueItems, _tier + 1);
            }

            return SortForTier(queueItems, _tier - 1); ;
        }

        private List<QueueItem> SortForTier(List<QueueItem> queueItems, int tier)
        {
            List<QueueItem> sameTierTanks = new List<QueueItem>();

            foreach (QueueItem queueItem in queueItems)
            {
                if (queueItem.IsTier(tier)) sameTierTanks.Add(queueItem);
            }

            return sameTierTanks;
        }
    }
}