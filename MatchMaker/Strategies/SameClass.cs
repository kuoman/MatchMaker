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
            BattleReady battleReady = IterateOverTankTypes(queueItems, new BattleReady());

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }

        private BattleReady IterateOverTankTypes(QueueItems queueItems, BattleReady battleReady)
        {
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