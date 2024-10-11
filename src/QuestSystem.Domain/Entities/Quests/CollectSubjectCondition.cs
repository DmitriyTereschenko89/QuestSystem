namespace QuestSystem.Domain.Entities.Quests
{
    public class CollectSubjectCondition(string subjectName, int subjectCount) : QuestConditions(subjectName, subjectCount)
    {
        public override void UpdateCondition()
        {
            base.UpdateCondition();
        }
    }
}
