namespace QuestSystem.Domain.Entities.Quests
{
    public class VisitSpecificLocationCondition(string specificLocationName) : QuestConditions(specificLocationName)
    {
        public bool IsAttended { get; private set; }
        public override void UpdateCondition()
        {
            IsAttended = true;
        }
    }
}
