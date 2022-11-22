namespace CreditSuisse.Domain.Entities
{
    public class HighRisk : CategoryBase
    {
        public HighRisk(DateTime referenceDate, Trade trade) : base(Enums.Precedence.HIGHRISK, referenceDate, trade)
        {
        }

        public override string Rank()
        {
            return Trade.Value > 1_000_000D && Trade.ClientSector.Equals("Private", StringComparison.OrdinalIgnoreCase) ? "HIGHRISK" : "";
        }
    }
}
