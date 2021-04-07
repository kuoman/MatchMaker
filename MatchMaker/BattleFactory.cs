using System.Collections.Generic;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;

namespace MatchMaker
{
    public static class BattleFactory
    {
        public static IBattle Create(IStrategy strategy, QueueItems queueItems)
        {
            IBattle battle =  PopulateBattleByMatches(strategy, queueItems, new Battle(), 7);

            if (battle.IsNotReadyToFight()) battle.FlushTeamsBackToQueue(queueItems);

            return battle;
        }

        private static readonly List<string> TankClasses = new List<string> { "Heavy", "Medium", "TankDestroyer", "Light" };
        private static readonly int MaxTanksOfSameType = 2;
        public static IBattle CreateFillBattle(IStrategy strategy, IRandom random, QueueItems queueItems)
        {
            List<string> shuffledTankClasses = random.Shuffle(TankClasses);

            IBattle battle = new Battle();

            foreach (string tankClass in shuffledTankClasses)
            {
                // todo: remove or generalize this SameClass call ?
                battle = PopulateBattleByMatches(new SameClass(tankClass), queueItems, battle, MaxTanksOfSameType);
            }

            if (battle.IsNotReadyToFight()) battle.FlushTeamsBackToQueue(queueItems);

            return battle;
        }

        private static IBattle PopulateBattleByMatches(IStrategy strategy, QueueItems queueItems, IBattle battleReady, int loopMax)
        {
            for (int i = 0; i < loopMax; i++)
            {
                if (battleReady.IsNotReadyToFight()) battleReady = strategy.PopulateBattle(queueItems, battleReady);
            }

            return battleReady;
        }
    }
}
