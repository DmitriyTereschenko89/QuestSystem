namespace QuestSystem.Domain.Entities.Quests.Conditions
{
    public class WinMonstersCondition : Conditions
    {
        public WinMonstersCondition()
        { }

        public WinMonstersCondition(Guid id, string monsterName, int monsterCount) : base(id, monsterName, monsterCount)
        { }

        public override void UpdateCondition()
        {
            base.UpdateCondition();
        }
    }
}
