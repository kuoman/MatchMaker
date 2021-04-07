using System.Collections.Generic;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;

namespace MatchMaker
{
    public static class BattleFactory
    {
        public static IBattle Create(IStrategy strategy, QueueItems queueItems)
        {
            return PopulateBattleByMatches(strategy, queueItems, new BattleReady(), 7);
        }

        private static readonly List<string> TankClasses = new List<string> { "Heavy", "Medium", "TankDestroyer", "Light" };
        private static readonly int MaxTanksOfSameType = 2;
        public static IBattle CreateFillBattle(IStrategy strategy, IRandom random, QueueItems queueItems)
        {
            List<string> shuffledTankClasses = random.Shuffle(TankClasses);

            IBattle battleReady = new BattleReady();

            foreach (string tankClass in shuffledTankClasses)
            {
                // todo: remove or generalize this SameClass call
                battleReady = PopulateBattleByMatches(new SameClass(tankClass), queueItems, battleReady, MaxTanksOfSameType);
            }

            return battleReady;
        }

        private static IBattle PopulateBattleByMatches(IStrategy strategy, QueueItems queueItems, IBattle battleReady, int loopMax)
        {
            for (int i = 0; i < loopMax; i++)
            {
                if (battleReady.IsNotReadyToFight()) battleReady = strategy.PopulateBattle(queueItems, battleReady);
              //  battleReady = strategy.PopulateBattle(queueItems, battleReady);
            }

            return battleReady;
        }
    }
}
