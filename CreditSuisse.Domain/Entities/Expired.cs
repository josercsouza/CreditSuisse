namespace CreditSuisse.Domain.Entities
{
    public class Expired : CategoryBase
    {
        public Expired(DateTime referenceDate, Trade trade) : base(Enums.Precedence.EXPIRED, referenceDate, trade)
        {
        }

        public override string Rank()
        {
            return ReferenceDate.AddDays(-30) > Trade.NextPaymentDate ? "EXPIRED" : "";
        }
    }
}
