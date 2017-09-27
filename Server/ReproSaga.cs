
using System.Collections.Generic;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class ReproSaga :
    Saga<ReproSagaData>,
    IAmStartedByMessages<StartRepro>
{
    static ILog log = LogManager.GetLogger<ReproSaga>();

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ReproSagaData> mapper)
    {
        mapper.ConfigureMapping<StartRepro>(message => message.ReproId)
            .ToSaga(sagaData => sagaData.ReproId);
    }

    public Task Handle(StartRepro message, IMessageHandlerContext context)
    {
        Data.ReproId = message.ReproId;

        if (Data.Repros == null)
        {
            Data.Repros = new List<ReproTransaction>();
        }

        Data.Repros.Clear();
        //foreach (var rt in message.Repros)
        //{
        //    Data.Repros.Add(rt);
        //}

        Data.Repros.Add(new ReproTransaction());
        Data.Repros.Add(new ReproTransaction());

        log.Info($"Received StartRepro message {Data.ReproId}. Starting Saga");

        return Task.CompletedTask;
    }
}