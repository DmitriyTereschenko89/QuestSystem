using Microsoft.AspNetCore.Mvc;
using QuestSystem.API.Data_Transfer_Objects;
using QuestSystem.Domain.Abstractions;
using QuestSystem.Domain.Entities.Quests.Common;

namespace QuestSystem.API.Controllers
{
    [ApiController]
    public class QuestController(IQuestService questService) : Controller
    {
        private readonly IQuestService _questService = questService;
        [HttpGet]
        [Route("/")]
        public async Task<IEnumerable<Quest>> GetAvailableQuests(Guid playerId)
        {
            return await _questService.GetAvailableQuests(playerId);
        }

        [HttpPut]
        [Route("/accept")]
        public async Task AcceptQuest([FromBody] AcceptedDto questDto)
        {
            await _questService.AcceptedQuest(questDto.PlayerId, questDto.QuestId);
        }

        [HttpPut]
        [Route("/update")]
        public Task UpdateQuest(Guid playerId, Guid questId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/finished")]
        public async Task FinishedQuest([FromBody] FinishedDto finishedDto)
        {
            await _questService.FinishedQuest(finishedDto.QuestItemId);
        }
    }
}
