using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.ValueObjects;
using CreditSuisse.Infrastructure.Utilities;

namespace CreditSuisse.Domain.Services.Implementation
{
    public class ProcessTradeService : IProcessTradeService
    {
        public void Ranking(DataProcessVO dataProcessVO)
        {
            foreach (var trade in dataProcessVO.Trades)
            {
                string category = Categorize(dataProcessVO.ReferenceDate, trade);

                if (dataProcessVO.OutputFile != null)
                {
                    File.AppendAllText(dataProcessVO.OutputFile, category + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine(category);
                }
            }
        }

        private string Categorize(DateTime referenceDate, Trade trade)
        {
            string category;

            var tradesBase = TypeHelper.GetEnumerableOfType<CategoryBase>(new object[] { referenceDate, trade });

            foreach (var tradeBase in tradesBase.OrderBy(x => x.Precedence))
            {
                category = tradeBase.Rank();
                if (!string.IsNullOrEmpty(category))
                {
                    return category;
                }
            }

            return "***NORANKED***";
        }
    }
}
