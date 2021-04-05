using System;
using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : IStrategy
    {
        private readonly string _tankType;
        private readonly int _maxTanksOfSameType = 3;
        private readonly List<string> _tankTypes = new List<String> {"Heavy", "Light", "TankDestroyer", "Medium"};

        public SameClass() : this(RandomFactory.Create()) { }

        public SameClass(string tankType)
        {
            _tankType = tankType;
        }

        public SameClass(IRandom random)
        {
            _tankTypes = random.Shuffle(_tankTypes);
        }

        public IBattle CreateBattle(QueueItems queueItems)
        {
            IBattle battleReady = IterateOverTankTypes(queueItems, new BattleReady());

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTankType(_tankType).GetMatchPair();
        }

        private IBattle IterateOverTankTypes(QueueItems queueItems, IBattle battleReady)
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