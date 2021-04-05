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

            return battleReady;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return IterateOverTankTypes(queueItems, battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTankType(_tankType).GetMatchPair(queueItems);
        }

        private IBattle IterateOverTankTypes(QueueItems queueItems, IBattle battleReady)
        {
            foreach (string tankType in _tankTypes)
            {
                if (battleReady.IsNotReadyToFight())
                {
                    for (int i = 0; i < _maxTanksOfSameType; i++)
                    {
                        battleReady = new SameClass(tankType).CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
                    }
                }
            }

            return battleReady;
        }
    }
}