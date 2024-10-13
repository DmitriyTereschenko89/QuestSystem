using Microsoft.EntityFrameworkCore;
using QuestSystem.Data.Identities;
using QuestSystem.Domain.Abstractions;
using QuestSystem.Domain.Common;
using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.Infrastructure.Repositories
{
    public class QuestRepository(QuestSystemDbContext context) : IQuestRepository
    {
        private readonly QuestSystemDbContext _context = context;
        public async Task AcceptedQuest(Guid playerId, Guid questId)
        {
            var quest = await _context.Quests.FirstAsync(q => q.Id == questId);
            ArgumentException.ThrowIfNullOrEmpty(nameof(quest));
            var condition = await _context.QuestConditions.FirstAsync(qc => qc.Id == quest.ConditionId);
            var questItemId = Guid.NewGuid();
            var questItem = new QuestItem(questItemId, questId, playerId, condition);
            _ = _context.QuestPlayers.Add(questItem);
            _ = await _context.SaveChangesAsync();
        }

        public async Task FinishedQuest(Guid questItemId)
        {
            var questItem = await _context.QuestPlayers.FirstAsync(qp => qp.QuestPlayerId == questItemId);
            ArgumentException.ThrowIfNullOrEmpty(nameof(questItem));
            questItem.FinishedQuestStatus();
            _ = await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quest>> GetAvailableQuests(Guid playerId)
        {
            var player = await _context.Players.FirstAsync(pl => pl.Id == playerId);
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(playerId));

            var questRequirementsIds = await _context.QuestRequirements
                                        .Where(qr => qr.MinimumLevel <= player.Level)
                                        .Select(qr => qr.Id).ToListAsync();
            var requirementsSetId = questRequirementsIds.ToHashSet();
            return await _context.Quests.Where(q => requirementsSetId.Contains(q.RequirementId)).ToListAsync();
        }

        public Task UpdateQuestStatus(Guid playerId, Guid questId, QuestStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
