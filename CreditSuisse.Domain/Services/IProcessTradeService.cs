using CreditSuisse.Domain.ValueObjects;

namespace CreditSuisse.Domain.Services
{
    public interface IProcessTradeService
    {
        void Ranking(DataProcessVO dataProcessVO);
    }
}
