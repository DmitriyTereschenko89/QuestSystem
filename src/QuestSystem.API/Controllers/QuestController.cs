using Microsoft.AspNetCore.Mvc;
using QuestSystem.Domain.Entities.Quests;

// позволять игрокам:
//Просматривать доступные квесты.
//Принимать квесты.
//Обновлять прогресс выполнения квестов.
//Завершать квесты и получать награду.

namespace QuestSystem.API.Controllers
{
    [ApiController]
    public class QuestController : Controller
    {
        [HttpGet]
        [Route("/")]
        public Task<Quest> GetAvailableQuests(Guid playerId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/accept")]
        public Task AcceptQuest(Guid playerId, Guid questId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/update")]
        public Task UpdateQuest(Guid playerId, Guid questId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/finished")]
        public Task FinishedQuest(Guid playerId, Guid quesId)
        {
            throw new NotImplementedException();
        }
    }
}
