using System;
using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : IStrategy
    {
        private readonly int _maxTanksOfSameType = 3;
        private readonly List<string> _tankTypes = new List<String> {"Heavy", "Light", "TankDestroyer", "Medium"};

        public SameClass() : this(RandomFactory.Create()) { }

        public SameClass(IRandom random)
        {
            _tankTypes = random.Shuffle(_tankTypes);
        }

        public IBattle CreateBattle(QueueItems queueItems)
        {
            if (!queueItems.HasEnoughTanks(14)) return new BattleNotReady();

            BattleReady battleReady = new BattleReady();

            foreach (string tankType in _tankTypes)
            {
                if (battleReady.IsNotReadyToFight())
                {
                    battleReady = queueItems.ByTankType(tankType).AddTanksToBattleReady(battleReady, _maxTanksOfSameType);
                }
            }

            return battleReady;
        }
    }
}