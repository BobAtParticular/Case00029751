using System;
using System.Collections.Generic;
using NServiceBus;

public class ReproSagaData :
    ContainSagaData
{
    public virtual Guid ReproId { get; set; }
    public virtual IList<ReproTransaction> Repros { get; set; }
}