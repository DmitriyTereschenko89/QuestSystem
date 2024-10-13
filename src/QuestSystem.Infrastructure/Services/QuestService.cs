using QuestSystem.Domain.Abstractions;
using QuestSystem.Domain.Common;
using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.Infrastructure.Services
{
    public class QuestService(IQuestRepository questRepository) : IQuestService
    {
        private readonly IQuestRepository _questRepository = questRepository;

        public async Task AcceptedQuest(Guid playerId, Guid questId)
        {
            await _questRepository.AcceptedQuest(playerId, questId);
        }

        public async Task FinishedQuest(Guid questItemId)
        {
            await _questRepository.FinishedQuest(questItemId);
        }

        public async Task<IEnumerable<Quest>> GetAvailableQuests(Guid playerId)
        {
            return await _questRepository.GetAvailableQuests(playerId);
        }

        public async Task UpdateQuestStatus(Guid playerId, Guid questId, QuestStatus status)
        {
            await _questRepository.UpdateQuestStatus(playerId, questId, status);
        }
    }
}
