using CreditSuisse.Domain.Interfaces;
using System.Globalization;

namespace CreditSuisse.Domain.Entities
{
    public class Trade : ITrade
    {
        public double _value;
        public string _clientSector;
        public DateTime _nextPaymentDate;

        public double Value => _value;

        public string ClientSector => _clientSector;

        public DateTime NextPaymentDate => _nextPaymentDate;

        //public bool IsPoliticallyExposed { get; set; }

        public Trade(string inputTrade)
        {
            var dataOfTrade = inputTrade?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            _value = double.Parse(dataOfTrade[0]);
            _clientSector = dataOfTrade[1];
            _nextPaymentDate = DateTime.ParseExact(dataOfTrade[2], "MM/dd/yyyy", null, DateTimeStyles.None);
            //IsPoliticallyExposed = bool.Parse(dataOfTrade[3]);
        }
    }
}
