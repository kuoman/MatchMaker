using System.Collections.Generic;
using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.Tier09;
using MatchMaker.Data_Bags.Tanks.Tier10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class EndToEndTest
    {
        [TestMethod]
        public void ShouldPopulateBattle()
        {
            QueueItems queueItems = new QueueItems();

            QueueItem playerA1 = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            queueItems.Add(playerA1);
            QueueItem playerB1 = new QueueItem(ObjectBuider.CreatePlayer(11, 50, 499), new E100());
            queueItems.Add(playerB1);
            QueueItem playerA2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50, 499), new E100());
            queueItems.Add(playerA2);
            QueueItem playerB2 = new QueueItem(ObjectBuider.CreatePlayer(12, 50, 499), new E100());
            queueItems.Add(playerB2);
            QueueItem playerA3 = new QueueItem(ObjectBuider.CreatePlayer(3, 50, 499), new E100());
            queueItems.Add(playerA3);
            QueueItem playerB3 = new QueueItem(ObjectBuider.CreatePlayer(13, 50, 499), new E100());
            queueItems.Add(playerB3);
            QueueItem playerA4 = new QueueItem(ObjectBuider.CreatePlayer(4, 50, 499), new E100());
            queueItems.Add(playerA4);
            QueueItem playerB4 = new QueueItem(ObjectBuider.CreatePlayer(14, 50, 499), new E100());
            queueItems.Add(playerB4);
            QueueItem playerA5 = new QueueItem(ObjectBuider.CreatePlayer(5, 50, 499), new E100());
            queueItems.Add(playerA5);
            QueueItem playerB5 = new QueueItem(ObjectBuider.CreatePlayer(15, 50, 499), new E100());
            queueItems.Add(playerB5);
            QueueItem playerA6 = new QueueItem(ObjectBuider.CreatePlayer(6, 50, 499), new E100());
            queueItems.Add(playerA6);
            QueueItem playerB6 = new QueueItem(ObjectBuider.CreatePlayer(16, 50, 499), new E100());
            queueItems.Add(playerB6);
            QueueItem playerA7 = new QueueItem(ObjectBuider.CreatePlayer(7, 50, 499), new E100());
            queueItems.Add(playerA7);
            Player playerB7 = ObjectBuider.CreatePlayer(17, 50, 499);
            QueueItem queueItemB7 = new QueueItem(playerB7, new E100());
            queueItems.Add(queueItemB7);

            List<QueueItem> items = new List<QueueItem> {playerA1, playerA2, playerA3, playerA4, playerA5, playerA6, playerA7};

            IBattle battle = new Battle();
            for (int i = 0; i < 7; i++)
            {
                IMatchPair matchPair = queueItems.GetMatchPairTeamA(queueItems, items[i]);
                matchPair.AddMatchToBattle(battle);
            }

            battle.IsReadyToFight().Should().BeTrue();
            battle.ContainsPlayer(playerB7).Should().BeTrue();
            queueItems.Contains(queueItemB7).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldPopulateMoreComplexBattleQueue()
        {
            QueueItems queueItems = new QueueItems();

            QueueItem queueItemA1 = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            queueItems.Add(queueItemA1);
            Player playerA1B = ObjectBuider.CreatePlayer(8, 50, 499);
            QueueItem queueItemA1B = new QueueItem(playerA1B, new Tortoise());
            queueItems.Add(queueItemA1B);
            QueueItem queueItemB1 = new QueueItem(ObjectBuider.CreatePlayer(11, 50, 499), new E100());
            queueItems.Add(queueItemB1);
            QueueItem queueItemA2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50, 499), new E100());
            queueItems.Add(queueItemA2);
            QueueItem queueItemB2 = new QueueItem(ObjectBuider.CreatePlayer(12, 50, 499), new E100());
            queueItems.Add(queueItemB2);
            QueueItem queueItemA3 = new QueueItem(ObjectBuider.CreatePlayer(3, 50, 499), new E100());
            queueItems.Add(queueItemA3);
            QueueItem queueItemB3 = new QueueItem(ObjectBuider.CreatePlayer(13, 50, 499), new E100());
            queueItems.Add(queueItemB3);
            QueueItem queueItemA4 = new QueueItem(ObjectBuider.CreatePlayer(4, 50, 499), new E100());
            queueItems.Add(queueItemA4);
            QueueItem queueItemB4 = new QueueItem(ObjectBuider.CreatePlayer(14, 50, 499), new E100());
            queueItems.Add(queueItemB4);
            QueueItem queueItemA5 = new QueueItem(ObjectBuider.CreatePlayer(5, 50, 499), new E100());
            queueItems.Add(queueItemA5);
            QueueItem queueItemB5 = new QueueItem(ObjectBuider.CreatePlayer(15, 50, 499), new E100());
            queueItems.Add(queueItemB5);
            QueueItem queueItemA6 = new QueueItem(ObjectBuider.CreatePlayer(6, 50, 499), new E100());
            queueItems.Add(queueItemA6);
            QueueItem queueItemB6 = new QueueItem(ObjectBuider.CreatePlayer(16, 50, 499), new E100());
            queueItems.Add(queueItemB6);
            QueueItem queueItemA7 = new QueueItem(ObjectBuider.CreatePlayer(7, 50, 499), new E100());
            queueItems.Add(queueItemA7);
            Player playerB7 = ObjectBuider.CreatePlayer(17, 50, 499);
            QueueItem queueItemB7 = new QueueItem(playerB7, new E100());
            queueItems.Add(queueItemB7);

            List<QueueItem> items = new List<QueueItem> {queueItemA1, queueItemA2, queueItemA3, queueItemA4, queueItemA5, queueItemA6, queueItemA7};

            QueueItems sortedQueue = queueItems.ByTier(queueItemA1);

            IBattle battle = new Battle();
            for (int i = 0; i < 7; i++)
            {
                IMatchPair matchPair = sortedQueue.GetMatchPairTeamA(sortedQueue, items[i]);
                matchPair.AddMatchToBattle(battle);
            }

            battle.IsReadyToFight().Should().BeTrue();
            battle.ContainsPlayer(playerB7).Should().BeTrue();
            battle.ContainsPlayer(playerA1B).Should().BeFalse();
            queueItems.Contains(queueItemA1B).Should().BeTrue();
        }

        // questions to ask the Queue...
        // get battle from your oldest queueItem...
        //   OldestQueueItem 
        //     Save TierSorted queue
        //     get first match 
        //          TierSorted -> subsort -> class, rank, winrate, numbattles
        //     get next oldest QueueItem from TierSorted match
        //          TierSorted -> subsort -> class, rank, winrate, numbattles
        //     if battle not full -> get next lower tier and save sort (LowerTierSorted)
        //     get oldest QueueItem from LowerTierSorted match
        //          LowerTierSorted -> subsort -> class, rank, winrate, numbattles
        // 
        //     If battle not full, reset.

        // how to get next tier down sort.  
        // what do you do if your subsearch has no items?

        //  [Ignore]
        [TestMethod]
        public void ShouldPopulateBattleWithPlatoons()
        {
            QueueItems queueItems = new QueueItems();

            Player playerA1 = ObjectBuider.CreatePlayer(1, 50, 499);
            QueueItem queueItemA1 = new QueueItem(playerA1, new E100());
            queueItems.Add(queueItemA1);
            Player playerA1B = ObjectBuider.CreatePlayer(9, 50, 499);
            QueueItem queueItemTortoise = new QueueItem(playerA1B, new Tortoise());
            queueItems.Add(queueItemTortoise);
            QueueItem queueItemB1 = new QueueItem(ObjectBuider.CreatePlayer(11, 50, 499), new E100());
            queueItems.Add(queueItemB1);
            QueueItem queueItemA2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50, 499), new E100());
            queueItems.Add(queueItemA2);
            QueueItem queueItemB2 = new QueueItem(ObjectBuider.CreatePlayer(12, 50, 499), new E100());
            queueItems.Add(queueItemB2);
            QueueItem queueItemA3 = new QueueItem(ObjectBuider.CreatePlayer(3, 50, 499), new E100());
            queueItems.Add(queueItemA3);
            Player playerB3 = ObjectBuider.CreatePlayer(13, 50, 499);
            QueueItem queueItemB3 = new QueueItem(playerB3, new E100());
            queueItems.Add(queueItemB3);
            QueueItem queueItemA4 = new QueueItem(ObjectBuider.CreatePlayer(4, 50, 499), new E100());
            queueItems.Add(queueItemA4);
            QueueItem queueItemB4 = new QueueItem(ObjectBuider.CreatePlayer(14, 50, 499), new E100());
            queueItems.Add(queueItemB4);
            QueueItem queueItemA5 = new QueueItem(ObjectBuider.CreatePlayer(5, 50, 499), new E100());
            queueItems.Add(queueItemA5);
            QueueItem queueItemB5 = new QueueItem(ObjectBuider.CreatePlayer(15, 50, 499), new E100());
            queueItems.Add(queueItemB5);
            QueueItem queueItemA6 = new QueueItem(ObjectBuider.CreatePlayer(6, 50, 499), new E100());
            queueItems.Add(queueItemA6);
            QueueItem queueItemB6 = new QueueItem(ObjectBuider.CreatePlayer(16, 50, 499), new E100());
            queueItems.Add(queueItemB6);
            Player playerA7 = ObjectBuider.CreatePlayer(7, 50, 499);
            QueueItem queueItemA7 = new QueueItem(playerA7, new E100());
            queueItems.Add(queueItemA7);
            Player playerB7 = ObjectBuider.CreatePlayer(17, 50, 499);
            QueueItem queueItemB7 = new QueueItem(playerB7, new E100());
            queueItems.Add(queueItemB7);

            Player playerB8 = ObjectBuider.CreatePlayer(18, 50, 499);
            QueueItem queueItemB3PlatoonMate = new QueueItem(playerB8, new E100());
            queueItemB3.AddPlatoonMate(queueItemB3PlatoonMate);

            Player playerA8 = ObjectBuider.CreatePlayer(8, 50, 499);
            QueueItem queueItemA1PlatoonMate = new QueueItem(playerA8, new E100());
            queueItemA1.AddPlatoonMate(queueItemA1PlatoonMate);

            // need 2 platoons Team A gets 1 platoon Team B gets another platoon

            List<QueueItem> items = new List<QueueItem> {queueItemA2, queueItemA3, queueItemA4, queueItemA5, queueItemA6, queueItemA7};

            Battle battle = new Battle();

            // get oldest queueItem (we don't have sort by date yet)

            QueueItem queueItemOldest = queueItemA1;

            if (queueItemOldest.IsInPlatoon())
            {
                // add myself to battle with match with another player that is not in a platoon on team A
                IMatchPair matchPair = queueItems.ByTier(queueItemA1).GetMatchPairTeamA(queueItems, queueItemOldest);
                matchPair.AddMatchToBattle(battle);

                // add my platoon mate to battle with match with another player that is not in a platoon on team A

                IMatchPair platoonMateMatchPair = queueItemOldest.GetMatchForPlatoonMateTeamA(queueItems.ByTier(queueItemA1));
                platoonMateMatchPair.AddMatchToBattle(battle);

                IMatchPair teamB_PrimaryPlayer_match = queueItems.ByTier(queueItemB3).GetMatchPairTeamB(queueItems.ByTier(queueItemB3), queueItemB3);
                teamB_PrimaryPlayer_match.AddMatchToBattle(battle);

                IMatchPair teamB_SecondaryPlayer_match = queueItemB3.GetMatchForPlatoonMateTeamB(queueItems.ByTier(queueItemB3));
                teamB_SecondaryPlayer_match.AddMatchToBattle(battle);
            }

            for (int i = 0; i < 6; i++)
            {
                IMatchPair matchPair = queueItems.ByTier(queueItemA1).GetMatchPairTeamA(queueItems, items[i]);
                matchPair.AddMatchToBattle(battle);
            }

            battle.IsReadyToFight().Should().BeTrue();
            battle.ContainsPlayer(playerA1);
            battle.ContainsPlayer(playerA8).Should().BeTrue();

            battle.ContainsPlayer(playerB3).Should().BeTrue();
            battle.ContainsPlayer(playerB8).Should().BeTrue();

            battle.ContainsPlayer(playerB7).Should().BeFalse();
            battle.ContainsPlayer(playerA7).Should().BeFalse();

            queueItems.Contains(queueItemTortoise).Should().BeTrue();

            battle.ContainsPlayer(playerA1B).Should().BeFalse();
            battle.PlayerOnTeamA(playerA1).Should().BeTrue();
            battle.PlayerOnTeamA(playerA8).Should().BeTrue();
            battle.PlayerOnTeamB(playerB3).Should().BeTrue();
            battle.PlayerOnTeamB(playerB8).Should().BeTrue();
        }
    }
}