using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Rates;

namespace Agate.Business.API
{
    public interface IRatesService
    {
        Task<List<Rate>> Get();
    }
}