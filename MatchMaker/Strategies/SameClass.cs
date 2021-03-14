using System;
using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : IStrategy
    {
        private readonly int _maxTanksOfSameType = 3 * 2;
        private readonly List<string> _tankTypes = new List<String> {"Heavy", "Light", "TankDestroyer", "Medium"};

        public SameClass()
        {
             Shuffle(_tankTypes);
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
            List<QueueItem> sortedList = new List<QueueItem>();

            foreach (QueueItem queueItem in queueItems)
            {
                if (queueItem.IsTankType(tankType)) sortedList.Add(queueItem);
            }

            return sortedList;
        }

        private static readonly Random Random = new Random();

        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}