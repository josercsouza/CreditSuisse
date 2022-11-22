using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.ValueObjects;
using CreditSuisse.Infrastructure.Utilities;
using System.Globalization;

namespace CreditSuisse.Domain.Services.Validators
{
    public static class ValidateInput
    {
        /// <summary>
        /// Validate data from file
        /// </summary>
        /// <param name="inputFile">Name of text file</param>
        /// <returns></returns>
        public static DataProcessVO FromFile(string inputFile)
        {
            var dataProcessVO = new DataProcessVO();

            try
            {
                dataProcessVO.OutputFile = $"{inputFile}.output.txt";

                string[] lines = File.ReadAllLines(inputFile);
                File.Delete(dataProcessVO.OutputFile);

                for (var index = 0; index < lines.Length; index++)
                {
                    if (index == 0)
                        dataProcessVO.ReferenceDate = DateTime.ParseExact(lines[index], "MM/dd/yyyy", null, DateTimeStyles.None);

                    if (index > 0)
                    {
                        if (TradeHelper.IsTrade(lines[index]))
                        {
                            dataProcessVO.Trades.Add(new Trade(lines[index]));
                        }
                        else
                        {
                            Console.WriteLine($"Wrong data in line {index + 1} !!!");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File not found or wrong format !!!");
            }

            return dataProcessVO;
        }
    }
}
