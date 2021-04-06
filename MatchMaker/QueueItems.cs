using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MatchMaker.Data_Bags;

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
            _queueItems.Add(queueItem);
        }

        public bool Contains(QueueItem queueItem)
        {
            foreach (QueueItem item in _queueItems)
            {
                if (item == queueItem) return true;
            }

            return false; 
        //    return _queueItems.Any(item => item == queueItem);
        }

        public QueueItems ByTier(int tier)
        { 
            QueueItems returnItems  = new QueueItems();

            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTier(tier)) returnItems.Add(item);
            }

            return returnItems;
        //    return new QueueItems(_queueItems.FindAll(x => x.IsTier(tier)));
        }

        public QueueItems ByTankType(string tankType)
        {
            QueueItems returnItems = new QueueItems();


            foreach (QueueItem item in _queueItems)
            {
                if (item.IsTankType(tankType)) returnItems.Add(item);
            }

            return returnItems;
          //  return new QueueItems(_queueItems.FindAll(x => x.IsTankType(tankType)));
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