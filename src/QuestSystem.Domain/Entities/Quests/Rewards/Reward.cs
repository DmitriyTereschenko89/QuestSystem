using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.Domain.Entities.Quests.Rewards
{
    public class Reward
    {
        public Reward()
        { }

        public Reward(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
        public virtual ICollection<Quest> Quests { get; set; }
    }
}
