namespace QuestSystem.Domain.Entities.Quests
{
    public abstract class QuestConditions(string conditionName = null, int conditionCount = 0)
    {
        public Guid Id { get; set; }
        public string ConditionName { get; init; } = conditionName;
        public int ConditionCount { get; private set; } = conditionCount;
        public virtual void UpdateCondition()
        {
            ConditionCount = Math.Max(ConditionCount - 1, 0);
        }
    }
}
