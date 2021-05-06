using System.Collections.Generic;
using System.Linq;

namespace MatchMaker.Data_Bags
{
    public class Team
    {
        private List<QueueItem> _queueItemList = new List<QueueItem>();

        public bool HasFullTeam()
        {
            return _queueItemList.Count == 7;
        }

        public void AddQueueItem(QueueItem queueItem)
        {
            if (_queueItemList.Count == 7) return;

            if (_queueItemList.Contains(queueItem)) return;

            _queueItemList.Add(queueItem);
        }

        public bool TeamIsFull()
        {
            return (_queueItemList.Count == 7);
        }

        public bool HasPlayer(Player player)
        {
            return _queueItemList.Any(queueItem => queueItem.HasPlayer(player));
        }

        public QueueItems ResetQueueItems(QueueItems queueItems)
        {
            foreach (QueueItem queueItem in _queueItemList)
            {
                if ( queueItems.Contains(queueItem) ) continue;

                queueItems.Add(queueItem);
            }

            _queueItemList = new List<QueueItem>();

            return queueItems;
        }
    }
}