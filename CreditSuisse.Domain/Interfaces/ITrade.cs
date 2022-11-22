namespace CreditSuisse.Domain.Interfaces
{
    interface ITrade
    {
        double Value { get; }

        string ClientSector { get; }

        DateTime NextPaymentDate { get; }

        //bool IsPoliticallyExposed { get; set; }
    }
}
