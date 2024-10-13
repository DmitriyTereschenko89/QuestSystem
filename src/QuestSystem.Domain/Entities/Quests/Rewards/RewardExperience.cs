namespace QuestSystem.Domain.Entities.Quests.Rewards
{
    public class RewardExperience : Reward
    {
        public RewardExperience()
        { }

        public RewardExperience(Guid id, int experiencePoints) : base(id)
        {
            ExperiencePoints = experiencePoints;
        }

        public int ExperiencePoints { get; init; }
    }
}
