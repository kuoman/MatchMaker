using System;
using System.Collections.Generic;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;

namespace MatchMaker
{
    public static class BattleFactory
    {
        public static IBattle Create(IStrategy strategy, QueueItems queueItems)
        {
            IBattle battleReady = new BattleReady();

            battleReady = PopulateBattleByMatches(strategy, queueItems, battleReady, 7);

            return battleReady;
        }

        private static IBattle PopulateBattleByMatches(IStrategy strategy, QueueItems queueItems, IBattle battleReady, int loopMax)
        {
            for (int i = 0; i < loopMax; i++)
            {
                battleReady = strategy.PopulateBattle(queueItems, battleReady);
            }

            return battleReady;
        }


        public static IBattle CreateFillBattle(IStrategy strategy, IRandom random, QueueItems queueItems)
        {
            int maxTanksOfSameType = 3;
            List<string> tankTypes = random.Shuffle(new List<string> { "Heavy", "Light", "TankDestroyer", "Medium" });

            IBattle battleReady = new BattleReady();

            foreach (string tankType in tankTypes)
            {
                if (battleReady.IsNotReadyToFight())
                {                   
                    // todo: remove or generalize this
                    battleReady = PopulateBattleByMatches(new SameClass(tankType), queueItems, battleReady, maxTanksOfSameType);
                }
            }

            return battleReady;
        }
    }
}
