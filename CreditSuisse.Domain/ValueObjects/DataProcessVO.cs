using CreditSuisse.Domain.Entities;

namespace CreditSuisse.Domain.ValueObjects
{
    public class DataProcessVO
    {
        public string OutputFile { get; set; } = string.Empty;
        public DateTime ReferenceDate { get; set; } = DateTime.MinValue;
        public List<Trade> Trades { get; set; } = new List<Trade>();
    }
}
