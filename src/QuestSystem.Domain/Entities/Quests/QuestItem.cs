using QuestSystem.Domain.Common;

namespace QuestSystem.Domain.Entities.Quests
{
    public class QuestItem(Guid questPlayerId, Guid questId, Guid playerId, QuestConditions questConditions)
    {
        public Guid QuestPlayerId { get; init; } = questPlayerId;
        public Guid QuestId { get; init; } = questId;
        public Guid PlayerId { get; init; } = playerId;
        public Quest Quest { get; init; }
        public QuestSystem.Domain.Entities.Player.Player Player { get; set; }

        public QuestStatus QuestStatus { get; private set; }

        public QuestConditions ProgressQuestCondition { get; init; } = questConditions;

        public void UpdateProgressQuestCondition()
        {
            ProgressQuestCondition.UpdateCondition();
            if (ProgressQuestCondition.ConditionCount == 0)
            {
                QuestStatus = QuestStatus.Completed;
            }
        }
    }
}
