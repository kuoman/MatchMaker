using System.Collections.Generic;
using System.Linq;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;

namespace MatchMaker
{
    public class QueueItems
    {
        readonly List<QueueItem> _queueItems;

        public QueueItems() : this(new List<QueueItem>())
        { }

        private QueueItems(List<QueueItem> itemList)
        {
            _queueItems = itemList;
        }

        public void Add(QueueItem queueItem)
        {
            if (_queueItems.Contains(queueItem)) return;

            _queueItems.Add(queueItem);
        }

        //public bool Contains(QueueItem queueItem) => _queueItems.Any(item => item == queueItem);
        public bool Contains(QueueItem queueItem)
        {
            foreach (QueueItem item in _queueItems)
            {
                if (item == queueItem) return true;
            }

            return false;
        }


        public QueueItems ByTier(Tank tank)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTier(tank)) returnItems.Add(item);
            }

            return returnItems;
        }

        //public QueueItems ByTier(QueueItem queueItem) => new QueueItems(_queueItems.FindAll(x => x.IsTier(queueItem)));
        public QueueItems ByTier(QueueItem queueItem)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems.Where(item => item.IsTier(queueItem)))
            {
                returnItems.Add(item);
            }

            return returnItems; 
        }

        public QueueItems ByTankType(Tank tank)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTankType(tank)) returnItems.Add(item);
            }

            return returnItems;
        }

        //public QueueItems ByTankType(QueueItem queueItem) => new QueueItems(_queueItems.FindAll(x => x.IsTankType(queueItem)));
        public QueueItems ByTankType(QueueItem queueItem)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTankType(queueItem)) returnItems.Add(item);
            }

            return returnItems;
        }

        //public QueueItems ByRank(QueueItem queueItem) => new QueueItems(_queueItems.FindAll(x => x.IsRank(queueItem)));
        public QueueItems ByRank(QueueItem queueItem)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsRank(queueItem)) returnItems.Add(item);
            }

            return returnItems;
        }

        //public QueueItems ByWinRate(QueueItem queueItem) => new QueueItems(_queueItems.FindAll(x => x.IsSameWinRateCategory(queueItem)));
        public QueueItems ByWinRate(QueueItem queueItem)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsSameWinRateCategory(queueItem)) returnItems.Add(item);
            }

            return returnItems;
        }

        //public QueueItems ByWinRate(QueueItem queueItem) => new QueueItems(_queueItems.FindAll(x => x.IsSameWinRateCategory(queueItem)));
        public QueueItems ByNumBattles(QueueItem queueItem)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsSameNumBattlesCategory(queueItem)) returnItems.Add(item);
            }

            return returnItems;
        }

        public QueueItems ByInPlatoon()
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsInPlatoon()) returnItems.Add(item);
            }

            return returnItems;
        }

        public QueueItems ByNotInPlatoon()
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsNotInPlatoon()) returnItems.Add(item);
            }

            return returnItems;
        }

        public bool HasEnoughTanks(int count)
        {
            return _queueItems.Count >= count;
        }

        public bool Remove(QueueItem queueItem)
        {
            return _queueItems.Remove(queueItem);
        }

        public IMatchPair GetMatchPairTeamA(QueueItems baseQueue, QueueItem queueItem)
        {
            if (0 == _queueItems.Count) return new MatchNotPaired();

            QueueItem queueItemToAdd = _queueItems[0];

            if (queueItemToAdd == queueItem)
            {
                if (1 >= _queueItems.Count ) return new MatchNotPaired();

                queueItemToAdd = _queueItems[1];
            }

            MatchPair matchPair = new MatchPair(queueItem, queueItemToAdd);

            baseQueue.Remove(queueItem);
            baseQueue.Remove(queueItemToAdd);

            return matchPair;
        }

        public IMatchPair GetMatchPairTeamB(QueueItems baseQueue, QueueItem queueItem)
        {
            if (0 == _queueItems.Count) return new MatchNotPaired();

            QueueItem queueItemToAdd = _queueItems[0];

            if (queueItemToAdd == queueItem)
            {
                if (1 >= _queueItems.Count) return new MatchNotPaired();

                queueItemToAdd = _queueItems[1];
            }

            MatchPair matchPair = new MatchPair(queueItemToAdd, queueItem);

            baseQueue.Remove(queueItem);
            baseQueue.Remove(queueItemToAdd);

            return matchPair;
        }
    }
}