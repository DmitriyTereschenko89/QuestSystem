namespace QuestSystem.Domain.Entities.Quests.Conditions
{
    public class VisitSpecificLocationCondition : Conditions
    {
        public VisitSpecificLocationCondition()
        { }
        public VisitSpecificLocationCondition(Guid id, string specificLocationName) : base(id, specificLocationName)
        {
            IsAttended = false;
        }

        public bool IsAttended { get; private set; }
        public override void UpdateCondition()
        {
            IsAttended = true;
        }
    }
}
