using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.ValueObjects;
using CreditSuisse.Infrastructure.Utilities;
using System.Globalization;

namespace CreditSuisse.Application
{
    public static class InputData
    {
        /// <summary>
        /// Check if data from keyboard are Ok
        /// </summary>
        /// <returns></returns>
        public static DataProcessVO FromKeyboard()
        {
            Console.WriteLine("Enter reference date (MM/dd/yyyy): ");
            string inputReferenceDate = Console.ReadLine();

            var referenceDate = (DateTime.ParseExact(inputReferenceDate, "MM/dd/yyyy", null, DateTimeStyles.None));

            var dataProcessVO = new DataProcessVO()
            {
                ReferenceDate = referenceDate
            };

            Console.WriteLine("Enter number of trades: ");
            string inputNumberOfTrades = Console.ReadLine();
            if (int.TryParse(inputNumberOfTrades, out int numberOfTrades))
            {
                Console.WriteLine("Enter trades (value MM/dd/yyyy public|private): ");
                for (int i = 0; i < numberOfTrades;)
                {
                    string inputTrade = Console.ReadLine();

                    if (TradeHelper.IsTrade(inputTrade))
                    {
                        dataProcessVO.Trades.Add(new Trade(inputTrade));
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong data. Enter again !!!");
                    }
                }
            }

            return dataProcessVO;
        }
    }
}
