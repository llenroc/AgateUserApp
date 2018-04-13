using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public class UserCardsService : IUserCardsService
    {
        public async Task<List<Card>> Get(int userId) =>
            await Client.Get<List<Card>>($"user/{userId}/cards/");
    }
}