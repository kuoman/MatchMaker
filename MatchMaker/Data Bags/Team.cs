using System.Collections.Generic;
using System.Linq;

namespace MatchMaker.Data_Bags
{
    public class Team
    {
        public List<QueueItem> QueueItemList = new List<QueueItem>();

        public bool HasFullTeam()
        {
            return QueueItemList.Count == 7;
        }

        public void AddQueueItem(QueueItem queueItem)
        {
            if (QueueItemList.Count == 7) return;

            QueueItemList.Add(queueItem);
        }

        public bool TeamIsFull()
        {
            return (QueueItemList.Count == 7);
        }

        public bool HasPlayer(Player player)
        {
            return QueueItemList.Any(queueItem => queueItem.HasPlayer(player));
        }
    }
}