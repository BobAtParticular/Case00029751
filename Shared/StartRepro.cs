using System;
using System.Collections.Generic;
using NServiceBus;

public class StartRepro :
    IMessage
{
    public Guid ReproId { get; set; }
    public List<ReproTransaction> Repros { get; set; } = new List<ReproTransaction>();
}