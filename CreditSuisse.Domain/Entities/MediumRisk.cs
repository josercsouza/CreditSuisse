namespace CreditSuisse.Domain.Entities
{
    public class MediumRisk : CategoryBase
    {
        public MediumRisk(DateTime referenceDate, Trade trade) : base(Enums.Precedence.MEDIUMRISK, referenceDate, trade)
        {
        }

        public override string Rank()
        {
            return Trade.Value > 1_000_000D && Trade.ClientSector.Equals("Public", StringComparison.OrdinalIgnoreCase) ? "MEDIUMRISK" : "";
        }
    }
}
