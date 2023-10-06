
namespace Core.Repositories;

public interface IOrderAggregateRepository 
{
    Task<OrderAggregate?> GetAsync(OrderId id);
    Task AddAsync(OrderAggregate order);
    Task DeleteAsync(OrderAggregate order);
    Task<OrderAggregate[]> GetAllAsync();
}