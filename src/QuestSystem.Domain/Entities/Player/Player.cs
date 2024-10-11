using QuestSystem.Domain.Entities.Quests;

namespace QuestSystem.Domain.Entities.Player
{
    public class Player
    {
        private readonly List<QuestItem> _quests = [];
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<QuestItem> Quests
        {
            get
            {
                return _quests;
            }
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }

            Name = name;
        }

        public void LevelUp()
        {
            ++Level;
        }
    }
}
