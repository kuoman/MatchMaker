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

        public bool HasEnoughTanksToFight()
        {
            return _queueItems.Count >= 14;
        }
    }
}