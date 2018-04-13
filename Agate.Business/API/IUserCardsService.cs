using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public interface IUserCardsService
    {
        Task<List<Card>> Get(int userId);
    }
}