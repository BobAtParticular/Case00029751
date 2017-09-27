using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        Console.Title = "Case00029751.Client";
        var endpointConfiguration = new EndpointConfiguration("Case00029751.Client");
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UseTransport<LearningTransport>();
        endpointConfiguration.SendOnly();
        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        int repros = 1;

        Console.WriteLine("Press 'enter' to send a StartRepro messages");
        Console.WriteLine("Press any other key to exit");

        while (true)
        {
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
            {
                break;
            }

            var reproId = Guid.NewGuid();
            var startRepro = new StartRepro
            {
                ReproId = reproId,
            };

            for (var i = 0; i < repros; i++)
            {
                startRepro.Repros.Add(new ReproTransaction
                {
                    Id = Guid.NewGuid(),
                    ReproType = repros % 2 == 0 ? ReproType.Type2 : ReproType.Type1
                });
            }

            await endpointInstance.Send("Case00029751.Server", startRepro)
                .ConfigureAwait(false);
            Console.WriteLine($"StartRepro Message sent with ReproId {reproId} and {repros} ReproTransactions");

            repros++;
        }

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}