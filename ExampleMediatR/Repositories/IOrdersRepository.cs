using ExampleMediatR.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleMediatR.Repositories
{
    public interface IOrdersRepository
    {
        Task<IList<OrderDto>> GetOrdersAsync();

        Task<OrderDto> CreateOrderAsync(Guid customerId, Guid productId);

        Task<OrderDto> GetOrderAsync(Guid orderId);
    }
}
