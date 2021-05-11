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
            

            QueueItem playerA1 = new QueueItem(new Player(1, 50), new E100());
            queueItems.Add(playerA1);
            QueueItem playerB1 = new QueueItem(new Player(11, 50), new E100());
            queueItems.Add(playerB1);
            QueueItem playerA2 = new QueueItem(new Player(2, 50), new E100());
            queueItems.Add(playerA2);
            QueueItem playerB2 = new QueueItem(new Player(12, 50), new E100());
            queueItems.Add(playerB2);
            QueueItem playerA3 = new QueueItem(new Player(3, 50), new E100());
            queueItems.Add(playerA3);
            QueueItem playerB3 = new QueueItem(new Player(13, 50), new E100());
            queueItems.Add(playerB3);
            QueueItem playerA4 = new QueueItem(new Player(4, 50), new E100());
            queueItems.Add(playerA4);
            QueueItem playerB4 = new QueueItem(new Player(14, 50), new E100());
            queueItems.Add(playerB4);
            QueueItem playerA5 = new QueueItem(new Player(5, 50), new E100());
            queueItems.Add(playerA5);
            QueueItem playerB5 = new QueueItem(new Player(15, 50), new E100());
            queueItems.Add(playerB5);
            QueueItem playerA6 = new QueueItem(new Player(6, 50), new E100());
            queueItems.Add(playerA6);
            QueueItem playerB6 = new QueueItem(new Player(16, 50), new E100());
            queueItems.Add(playerB6);
            QueueItem playerA7 = new QueueItem(new Player(7, 50), new E100());
            queueItems.Add(playerA7);
            Player playerB7 = new Player(17, 50);
            QueueItem queueItemB7 = new QueueItem(playerB7, new E100());
            queueItems.Add(queueItemB7);

            List<QueueItem> items = new List<QueueItem> {playerA1, playerA2, playerA3, playerA4, playerA5, playerA6, playerA7};

            IBattle battle = new Battle();
            for (int i = 0; i < 7; i++)
            {
                IMatchPair matchPair = queueItems.GetMatchPair(queueItems, items[i]);
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

            QueueItem queueItemA1 = new QueueItem(new Player(1, 50), new E100());
            queueItems.Add(queueItemA1);
            Player playerA1B = new Player(8, 50);
            QueueItem queueItemA1B = new QueueItem(playerA1B, new Tortoise());
            queueItems.Add(queueItemA1B);
            QueueItem queueItemB1 = new QueueItem(new Player(11, 50), new E100());
            queueItems.Add(queueItemB1);
            QueueItem queueItemA2 = new QueueItem(new Player(2, 50), new E100());
            queueItems.Add(queueItemA2);
            QueueItem queueItemB2 = new QueueItem(new Player(12, 50), new E100());
            queueItems.Add(queueItemB2);
            QueueItem queueItemA3 = new QueueItem(new Player(3, 50), new E100());
            queueItems.Add(queueItemA3);
            QueueItem queueItemB3 = new QueueItem(new Player(13, 50), new E100());
            queueItems.Add(queueItemB3);
            QueueItem queueItemA4 = new QueueItem(new Player(4, 50), new E100());
            queueItems.Add(queueItemA4);
            QueueItem queueItemB4 = new QueueItem(new Player(14, 50), new E100());
            queueItems.Add(queueItemB4);
            QueueItem queueItemA5 = new QueueItem(new Player(5, 50), new E100());
            queueItems.Add(queueItemA5);
            QueueItem queueItemB5 = new QueueItem(new Player(15, 50), new E100());
            queueItems.Add(queueItemB5);
            QueueItem queueItemA6 = new QueueItem(new Player(6, 50), new E100());
            queueItems.Add(queueItemA6);
            QueueItem queueItemB6 = new QueueItem(new Player(16, 50), new E100());
            queueItems.Add(queueItemB6);
            QueueItem queueItemA7 = new QueueItem(new Player(7, 50), new E100());
            queueItems.Add(queueItemA7);
            Player playerB7 = new Player(17, 50);
            QueueItem queueItemB7 = new QueueItem(playerB7, new E100());
            queueItems.Add(queueItemB7);

            List<QueueItem> items = new List<QueueItem> { queueItemA1, queueItemA2, queueItemA3, queueItemA4, queueItemA5, queueItemA6, queueItemA7 };

            QueueItems sortedQueue = queueItems.ByTier(queueItemA1);

            IBattle battle = new Battle();
            for (int i = 0; i < 7; i++)
            {
                IMatchPair matchPair = sortedQueue.GetMatchPair(sortedQueue, items[i]);
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

    }
}
