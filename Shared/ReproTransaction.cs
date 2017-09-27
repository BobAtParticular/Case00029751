using System;
using NServiceBus.Sagas;

public partial class ReproTransaction
{
    public virtual Guid Id { get; set; }
    public virtual ReproType ReproType { get; set; }
}