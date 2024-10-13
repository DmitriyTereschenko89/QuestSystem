using QuestSystem.Domain.Common;

namespace QuestSystem.Domain.Entities.Quests.Common
{
    public class QuestItem
    {
        public QuestItem() { }
        public QuestItem(Guid questPlayerId, Guid questId, Guid playerId, Conditions.Conditions questConditions)
        {
            QuestPlayerId = questPlayerId;
            QuestId = questId;
            PlayerId = playerId;
            ProgressQuestCondition = questConditions;
            QuestStatus = QuestStatus.Accepted;
        }

        public Guid QuestPlayerId { get; init; }
        public Guid QuestId { get; init; }
        public Guid PlayerId { get; init; }
        public Quest Quest { get; init; }
        public virtual Player.Player Player { get; set; }

        public QuestStatus QuestStatus { get; private set; }

        public virtual QuestSystem.Domain.Entities.Quests.Conditions.Conditions ProgressQuestCondition { get; init; }
        public void FinishedQuestStatus()
        {
            QuestStatus = QuestStatus.Finished;
        }

        public void UpdateProgressQuestCondition()
        {
            QuestStatus = QuestStatus.InProgress;
            ProgressQuestCondition.UpdateCondition();
            if (ProgressQuestCondition.ConditionCount == 0)
            {
                QuestStatus = QuestStatus.Completed;
            }
        }
    }
}
