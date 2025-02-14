﻿using ExampleMediatR.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMediatR.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IList<OrderDto> _orders = new List<OrderDto>
        {
            new OrderDto()
            {
                Id = Guid.Parse("0bb7daa5-7f27-4b5f-95df-3d8b3b86d7ed"),
                DeliveryDate = DateTime.UtcNow,
                ProductId = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"),
                CustomerId = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"),
                Delivered = false,
            },
        };
        public Task<OrderDto> CreateOrderAsync(Guid customerId, Guid productId)
        {
            OrderDto order = new()
            {
                Id = Guid.NewGuid(),
                Delivered = false,
                DeliveryDate = DateTime.UtcNow,
                CustomerId = customerId,
                ProductId = productId,
            };
            _orders.Add(order);
            return Task.FromResult(order);
        }

        public Task<OrderDto> GetOrderAsync(Guid orderId)
        {
            return Task.FromResult(_orders.SingleOrDefault(cust => cust.Id == orderId));
        }

        public Task<IList<OrderDto>> GetOrdersAsync()
        {
            return Task.FromResult(_orders);
        }
    }
}
