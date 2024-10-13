namespace QuestSystem.Domain.Entities.Quests.Conditions
{
    public class CollectSubjectCondition : Conditions
    {
        public CollectSubjectCondition() : base()
        { }
        public CollectSubjectCondition(Guid id, string subjectName, int subjectCount) : base(id, subjectName, subjectCount)
        { }

        public override void UpdateCondition()
        {
            base.UpdateCondition();
        }
    }
}
