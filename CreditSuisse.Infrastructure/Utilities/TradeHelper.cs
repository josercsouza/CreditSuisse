using System.Globalization;

namespace CreditSuisse.Infrastructure.Utilities
{
    public static class TradeHelper
    {
        public static bool IsTrade(string? inputTrade)
        {
            try
            {
                var dataOfTrade = inputTrade?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (dataOfTrade == null
                    //|| dataOfTrade.Length != 4
                    || !double.TryParse(dataOfTrade[0], out _)
                    || "|PUBLIC|PRIVATE|".IndexOf($"|{dataOfTrade[1].ToUpper()}|") < 0
                    || !DateTime.TryParseExact(dataOfTrade[2], "MM/dd/yyyy", null, DateTimeStyles.None, out _)
                    //|| !bool.TryParse(dataOfTrade[3], out _)
                    )
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
