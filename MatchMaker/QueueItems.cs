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

        public QueueItems ByTier(int tier)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTier(tier)) returnItems.Add(item);
            }

            return returnItems;
        }

        public QueueItems ByTier(ITank tank)
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

            return new QueueItems(_queueItems.FindAll(x => x.IsTier(queueItem))); 
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

        public QueueItems ByTankType(ITank tank)
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

        public QueueItems ByRank(string rank)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsRank(rank)) returnItems.Add(item);
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

        public QueueItems ByWinRate(int winRateCategory)
        {
            QueueItems returnItems = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsSameWinRateCategory(winRateCategory)) returnItems.Add(item);
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

        public bool HasEnoughTanks(int count)
        {
            return _queueItems.Count >= count;
        }

        public IBattle AddTanksToBattleReady(IBattle battleReady, int matchesToAdd)
        {
            int matchesToCreate = _queueItems.Count / 2;
            if (matchesToCreate > matchesToAdd) matchesToCreate = matchesToAdd;

            int tankCount = matchesToCreate * 2;
            for (int i = 0; i < tankCount; i = i + 2)
            {
                battleReady = GetMatchPair(this).AddMatchToBattle(battleReady);
            }

            return battleReady;
        }

        public bool Remove(QueueItem queueItem)
        {
            return _queueItems.Remove(queueItem);
        }

        public IMatchPair GetMatchPair(QueueItems baseQueue)
        {
            if (1 >=_queueItems.Count) return new MatchNotPaired();

            QueueItem queueItem01 = _queueItems[0];
            QueueItem queueItem02 = _queueItems[1];

            MatchPair matchPair = new MatchPair(queueItem01, queueItem02);

            baseQueue.Remove(queueItem02);
            baseQueue.Remove(queueItem01);

            return matchPair;
        }

    }
}