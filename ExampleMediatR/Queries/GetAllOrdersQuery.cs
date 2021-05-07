using ExampleMediatR.Responses;

using MediatR;

using System.Collections.Generic;

namespace ExampleMediatR.Queries
{
    public class GetAllOrdersQuery : IRequest<IList<OrderResponse>> { }
}
