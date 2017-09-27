using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Persistence;

class Program
{
    static async Task Main()
    {
        Console.Title = "Case00029751.Server";

        var endpointConfiguration = new EndpointConfiguration("Case00029751.Server");
        var persistence = endpointConfiguration.UsePersistence<NHibernatePersistence>();
        persistence.ConnectionString("Data Source=.\\SqlExpress;Database=Case00029751;Integrated Security=True");

        LogManager.Use<DefaultFactory>().Level(LogLevel.Debug);

        endpointConfiguration.UseTransport<LearningTransport>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}