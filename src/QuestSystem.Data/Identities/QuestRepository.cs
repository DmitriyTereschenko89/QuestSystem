using QuestSystem.Domain.Common;
using QuestSystem.Domain.Entities.Quests;

namespace QuestSystem.Data.Identities
{
    public class QuestRepository(QuestSystemDbContext questSystemDbContext) : IQuestRepository
    {
        private readonly QuestSystemDbContext _questSystemDbContext = questSystemDbContext;

        public Task AcceptedQuest(Guid playerId, Guid questId)
        {

            throw new NotImplementedException();
        }

        public Task FinishedQuest(Guid playerId, Guid questId)
        {
            throw new NotImplementedException();
        }

        public Task<Quest> GetAvailableQuests(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuestStatus(Guid playerId, Guid questId, QuestStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
