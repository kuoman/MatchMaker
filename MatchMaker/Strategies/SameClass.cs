using System;
using System.Collections.Generic;
using System.Linq;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : IStrategy
    {
        private readonly int _maxTanksOfSameType = 3 * 2;
        private readonly List<string> _tankTypes = new List<String> {"Heavy", "Light", "TankDestroyer", "Medium"};

        public SameClass() : this(RandomFactory.Create()) { }

        public SameClass(IRandom random)
        {
            _tankTypes = random.Shuffle(_tankTypes);
        }

        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            if (13 >= queueItems.Count) return new BattleNotReady();
            
            BattleReady battleReady = new BattleReady();

            foreach (string tankType in _tankTypes)
            {
                if (!battleReady.IsReadyToFight())
                {
                    SortAndAddByTankType(queueItems, battleReady, tankType);
                }
            }

            return battleReady;
        }

        public IBattle CreateBattle(QueueItems queueItems)
        {
           // if (13 >= queueItems.Count) return new BattleNotReady();

            BattleReady battleReady = new BattleReady();

            foreach (string tankType in _tankTypes)
            {
                if (!battleReady.IsReadyToFight())
                {
                   // SortAndAddByTankType(queueItems, battleReady, tankType);
                }
            }

            return battleReady;
        }

        private void SortAndAddByTankType(List<QueueItem> queueItems, BattleReady battleReady, string tankType)
        {
            List<QueueItem> sameTankType = SortForTankType(tankType, queueItems);

            int evenSameClassTanks = (sameTankType.Count / 2) * 2;
            if (evenSameClassTanks > _maxTanksOfSameType) evenSameClassTanks = _maxTanksOfSameType;

            for (int i = 0; i < evenSameClassTanks; i = i + 2)
            {
                battleReady.AddQueueItemToTeamA(sameTankType[i]);
                battleReady.AddQueueItemToTeamB(sameTankType[i + 1]);
            }
        }

        private List<QueueItem> SortForTankType(string tankType, List<QueueItem> queueItems)
        {
            return queueItems.Where(queueItem => queueItem.IsTankType(tankType)).ToList();
        }
    }
}