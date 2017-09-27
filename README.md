# Case00029751
Reproduction for Case 00029751



## Prerequisites

A database must be created (or chosen) to run the repro. The existing connection string assumes a local SqlExpress server with a database named `Case00029751`.

The connection string is hard coded in `Server\Program.cs`.

### Error

```
2017-09-26 15:35:14.109 ERROR NServiceBus.RecoverabilityExecutor Moving message '3ddc2085-716b-4c81-9472-a7fa0173e5b7' to the error queue 'error' because processing failed due to an exception:
NHibernate.StaleObjectStateException: Row was updated or deleted by another transaction (or unsaved-value mapping was incorrect): [ReproTransaction#0cdd9515-ee11-47c0-acf5-0e2bb267e6f6]
   at NHibernate.Persister.Entity.AbstractEntityPersister.Update(Object id, Object[] fields, Object[] oldFields, Object rowId, Boolean[] includeProperty, Int32 j, Object oldVersion, Object obj, SqlCommandInfo sql, ISessionImplementor session)
   at NHibernate.Persister.Entity.AbstractEntityPersister.UpdateOrInsert(Object id, Object[] fields, Object[] oldFields, Object rowId, Boolean[] includeProperty, Int32 j, Object oldVersion, Object obj, SqlCommandInfo sql, ISessionImplementor session)
   at NHibernate.Persister.Entity.AbstractEntityPersister.Update(Object id, Object[] fields, Int32[] dirtyFields, Boolean hasDirtyCollection, Object[] oldFields, Object oldVersion, Object obj, Object rowId, ISessionImplementor session)
   at NHibernate.Action.EntityUpdateAction.Execute()
   at NHibernate.Engine.ActionQueue.Execute(IExecutable executable)
   at NHibernate.Engine.ActionQueue.ExecuteActions(IList list)
   at NHibernate.Engine.ActionQueue.ExecuteActions()
   at NHibernate.Event.Default.AbstractFlushingEventListener.PerformExecutions(IEventSource session)
   at NHibernate.Event.Default.DefaultFlushEventListener.OnFlush(FlushEvent event)
   at NHibernate.Impl.SessionImpl.Flush()
   at NHibernate.Transaction.AdoTransaction.Commit()
   at NServiceBus.Persistence.NHibernate.NHibernateLazyNativeTransactionSynchronizedStorageSession.<CompleteAsync>d__7.MoveNext()
```