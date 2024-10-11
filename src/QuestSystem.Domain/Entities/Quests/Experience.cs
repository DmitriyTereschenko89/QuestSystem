namespace QuestSystem.Domain.Entities.Quests
{
    public class Experience(Guid id, int experiencePoints) : QuestReward(id)
    {
        public int ExperiencePoints { get; init; } = experiencePoints;
    }
}
