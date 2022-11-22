using CreditSuisse.Domain.Services;
using CreditSuisse.Domain.Services.Implementation;
using CreditSuisse.Domain.Services.Validators;
using CreditSuisse.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var _processTradeService = serviceProvider.GetService<IProcessTradeService>();

            Console.WriteLine("Starting the application");

            DataProcessVO dataProcessVO = new();

            if (args.Length == 0)
            {
                dataProcessVO = InputData.FromKeyboard();
            }
            else if (args.Length == 1)
            {
                dataProcessVO = ValidateInput.FromFile(args[0]);
            }

            _processTradeService?.Ranking(dataProcessVO);

            Console.WriteLine("Click any key to finalize !!!");
            Console.ReadKey();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProcessTradeService, ProcessTradeService>();
        }
    }
}
