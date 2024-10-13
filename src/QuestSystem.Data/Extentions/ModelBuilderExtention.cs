using Microsoft.EntityFrameworkCore;
using QuestSystem.Domain.Entities.Player;
using QuestSystem.Domain.Entities.Quests.Common;
using QuestSystem.Domain.Entities.Quests.Conditions;
using QuestSystem.Domain.Entities.Quests.Requirements;
using QuestSystem.Domain.Entities.Quests.Rewards;

namespace QuestSystem.Data.Extentions
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var conditionId1 = Guid.NewGuid();
            var conditionId2 = Guid.NewGuid();
            var conditionId3 = Guid.NewGuid();
            var conditionId4 = Guid.NewGuid();
            var conditionId5 = Guid.NewGuid();
            var conditionId6 = Guid.NewGuid();
            var conditionId7 = Guid.NewGuid();
            var conditionId8 = Guid.NewGuid();
            var conditionId9 = Guid.NewGuid();
            var wolfFang = new CollectSubjectCondition(conditionId1, "collect 10 wolf fangs", 10);
            var roseBlossoms = new CollectSubjectCondition(conditionId2, "collect 5 rose blossoms", 5);
            var trollHeart = new CollectSubjectCondition(conditionId3, "collect 1 troll heart", 1);

            var defeatDemons = new WinMonstersCondition(conditionId4, "defeat 15 demons", 15);
            var defeatSuccubi = new WinMonstersCondition(conditionId5, "defeat 10 succubi", 10);
            var defeatArchidemon = new WinMonstersCondition(conditionId6, "defeat 1 archidemon", 1);

            var forestShowers = new VisitSpecificLocationCondition(conditionId7, "Forest of Showers");
            var forlorn = new VisitSpecificLocationCondition(conditionId8, "Forlorn");
            var azeroth = new VisitSpecificLocationCondition(conditionId9, "Azeroth");

            _ = modelBuilder.Entity<CollectSubjectCondition>().HasData(wolfFang, roseBlossoms, trollHeart);
            _ = modelBuilder.Entity<WinMonstersCondition>().HasData(defeatDemons, defeatSuccubi, defeatArchidemon);
            _ = modelBuilder.Entity<VisitSpecificLocationCondition>().HasData(forestShowers, forlorn, azeroth);

            var rewId1 = Guid.NewGuid();
            var rewId2 = Guid.NewGuid();
            var rewId3 = Guid.NewGuid();
            var rewId4 = Guid.NewGuid();
            var rewId5 = Guid.NewGuid();
            var rewId6 = Guid.NewGuid();
            var experience1 = new RewardExperience(rewId1, 1000);
            var experience2 = new RewardExperience(rewId2, 2000);

            var subject1 = new RewardItem(rewId3, "Ring");
            var subject2 = new RewardItem(rewId4, "Sword of Azeroth");

            var currency1 = new RewardCurrency(rewId5, 500);
            var currency2 = new RewardCurrency(rewId6, 1500);

            _ = modelBuilder.Entity<RewardExperience>().HasData(experience1, experience2);
            _ = modelBuilder.Entity<RewardItem>().HasData(subject1, subject2);
            _ = modelBuilder.Entity<RewardCurrency>().HasData(currency1, currency2);

            var questId1 = Guid.NewGuid();
            var questId2 = Guid.NewGuid();
            var questId3 = Guid.NewGuid();
            var questId4 = Guid.NewGuid();
            var questId5 = Guid.NewGuid();

            var reqId1 = Guid.NewGuid();
            var reqId2 = Guid.NewGuid();
            var reqId3 = Guid.NewGuid();
            var reqId4 = Guid.NewGuid();
            var requirements1 = new Requirements(reqId1, 5, [questId1, questId3]);
            var requirements2 = new Requirements(reqId2, 2, [questId2]);
            var requirements3 = new Requirements(reqId3, 10, [questId3, questId4, questId5]);
            var requirements4 = new Requirements(reqId4, 1, []);

            _ = modelBuilder.Entity<Requirements>().HasData(requirements1, requirements2, requirements3, requirements4);
            var quest1 = new Quest(questId1, conditionId1, rewId1, reqId4, "collect wolf fangs", "collect 10 wolf fangs");
            var quest2 = new Quest(questId2, conditionId2, rewId2, reqId1, "collect rose blossoms", "collect 5 rose blossoms");
            var quest3 = new Quest(questId3, conditionId3, rewId2, reqId4, "collect troll heart", "collect 1 troll heart");
            var quest4 = new Quest(questId4, conditionId6, rewId3, reqId2, "defeat archidemon", "defeat archidemon");
            var quest5 = new Quest(questId5, conditionId9, rewId2, reqId3, "visite the Azeroth", "visit the Azeroth");

            var player = new Player(Guid.NewGuid(), "Player1", 1);
            _ = modelBuilder.Entity<Quest>().HasData(quest1, quest2, quest3, quest4, quest5);
            _ = modelBuilder.Entity<Player>().HasData(player);
        }
    }
}
