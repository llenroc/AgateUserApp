﻿using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public interface ICardsService
    {
        Task<ChargeCardResponse> ChargeCard(int userId, int cardId, ChargeCardRequest request);
    }
}