namespace Common.Dispatcher.QueryProcessor;

public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}