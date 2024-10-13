using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.Domain.Entities.Player
{
    public class Player
    {
        private readonly List<QuestItem> _quests;
        public Player() { }
        public Player(Guid id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
            _quests = [];
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Level { get; private set; }
        public IEnumerable<QuestItem> Quests
        {
            get
            {
                return _quests;
            }
        }

        public void LevelUp()
        {
            ++Level;
        }
    }
}
