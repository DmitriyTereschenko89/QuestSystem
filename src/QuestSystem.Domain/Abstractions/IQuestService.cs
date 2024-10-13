using QuestSystem.Domain.Common;
using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.Domain.Abstractions
{
    public interface IQuestService
    {
        Task<IEnumerable<Quest>> GetAvailableQuests(Guid playerId);
        Task AcceptedQuest(Guid playerId, Guid questId);
        Task UpdateQuestStatus(Guid playerId, Guid questId, QuestStatus status);
        Task FinishedQuest(Guid questItemId);
    }
}
