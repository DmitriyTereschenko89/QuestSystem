namespace QuestSystem.Domain.Entities.Quests.Requirements
{
    using QuestSystem.Domain.Entities.Quests.Common;

    public class Requirements
    {
        public Requirements()
        { }

        public Requirements(Guid id, int minimumLevel, HashSet<Guid> previousQuestsCompleted)
        {
            Id = id;
            MinimumLevel = minimumLevel;
            PreviousQuestsCompleted = previousQuestsCompleted;
        }

        public Guid Id { get; init; }
        public virtual ICollection<Quest> Quests { get; set; }
        public int MinimumLevel { get; init; }
        public HashSet<Guid> PreviousQuestsCompleted { get; init; }
    }
}
