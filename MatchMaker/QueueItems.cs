using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker
{
    public class QueueItems
    {
        readonly List<QueueItem> _queueItems = new List<QueueItem>();

        public void Add(QueueItem queueItem)
        {
            _queueItems.Add(queueItem);
        }

        public bool Contains(QueueItem queueItem)
        {
            foreach (QueueItem item in _queueItems)
            {
                if (item == queueItem) return true;
            }

            return false;
        }

        public QueueItems ByTier(int tier)
        { 
            QueueItems returnItems  = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTier(tier)) returnItems.Add(item);
            }

            return returnItems;
        }

        public QueueItems ByTankType(string tankType)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTankType(tankType)) returnItems.Add(item);
            }

            return returnItems;
        }

        public bool HasEnoughTanks(int count)
        {
            return _queueItems.Count >= count;
        }

        public BattleReady AddTanksToBattleReady(BattleReady battleReady, int maxToAdd)
        {
            int modTankCount = _queueItems.Count / 2;
            if (modTankCount > maxToAdd) modTankCount = maxToAdd;

            for (int i = 0; i < modTankCount * 2; i = i + 2)
            {
                battleReady.AddQueueItemToTeamA(_queueItems[i]);
                battleReady.AddQueueItemToTeamB(_queueItems[i + 1]);
            }

            return battleReady;
        }
    }
}