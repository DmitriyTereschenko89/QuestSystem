using QuestSystem.Domain.Entities.Quests;

namespace QuestSystem.Domain.Common
{
    public interface IQuestRepository
    {
        Task<Quest> GetAvailableQuests(Guid playerId);
        Task AcceptedQuest(Guid playerId, Guid questId);
        Task UpdateQuestStatus(Guid playerId, Guid questId, QuestStatus status);
        Task FinishedQuest(Guid playerId, Guid questId);
    }
}
