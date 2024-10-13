using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestSystem.Domain.Entities.Quests.Conditions;

namespace QuestSystem.Data.Converters
{
    public class ConditionsConverter : ValueConverter<Conditions, string>
    {
        public ConditionsConverter() : base(
        v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Conditions>(v, null as JsonSerializerOptions))
        {
        }
    }
}

