namespace QuestSystem.Domain.Entities.Quests
{
    public class WinMonstersCondition(string monsterName, int monsterCount) : QuestConditions(monsterName, monsterCount)
    {
        public override void UpdateCondition()
        {
            base.UpdateCondition();
        }
    }
}
