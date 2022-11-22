using CreditSuisse.Domain.Enums;

namespace CreditSuisse.Domain.Entities
{
    public abstract class CategoryBase
    {
        public Precedence Precedence { get; set; }

        public DateTime ReferenceDate { get; set; }

        public Trade Trade { get; set; }

        public abstract string Rank();

        protected CategoryBase(Precedence precedence, DateTime referenceDate, Trade trade)
        {
            Precedence = precedence;
            ReferenceDate = referenceDate;
            Trade = trade;
        }
    }
}
