namespace QuestSystem.Domain.Entities.Quests.Conditions
{
    using System.Text.Json.Serialization;
    using QuestSystem.Domain.Entities.Quests.Common;

    public abstract class Conditions
    {
        public Conditions()
        { }
        [JsonConstructor]
        public Conditions(Guid id, string conditionDescription = null, int conditionCount = 0)
        {
            Id = id;
            ConditionDescription = conditionDescription;
            ConditionCount = conditionCount;
        }
        public Guid Id { get; init; }
        public string ConditionDescription { get; init; }
        public int ConditionCount { get; private set; }
        public virtual ICollection<Quest> Quests { get; }
        public virtual void UpdateCondition()
        {
            ConditionCount = Math.Max(ConditionCount - 1, 0);
        }
    }
}
