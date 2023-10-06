using Core;
using Core.Repositories;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderAggregateRepository : IOrderAggregateRepository
{
    private readonly WaiterDbContext _context;
    public OrderAggregateRepository(WaiterDbContext context)
    {
        _context = context;
    }
    public async Task<OrderAggregate?> GetAsync(OrderId id) => await _context.Orders.Include(o=>o.Table).SingleOrDefaultAsync(o=>o.OrderId == id);

    public async Task AddAsync(OrderAggregate order)
    {
        await _context.Orders.AddAsync(order);
    }

    public Task DeleteAsync(OrderAggregate order)
    {
        _context.Orders.Remove(order);
        return Task.CompletedTask;
    }

    public Task<OrderAggregate[]> GetAllAsync() => _context.Orders.Include(o=>o.Table).ToArrayAsync();
}