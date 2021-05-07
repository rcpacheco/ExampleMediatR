using ExampleMediatR.Responses;

using MediatR;

using System;

namespace ExampleMediatR.Requests
{
    public class CreateCustomerOrderRequest : IRequest<OrderResponse>
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }
    }
}
