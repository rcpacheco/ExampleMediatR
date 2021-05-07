using ExampleMediatR.Responses;

using MediatR;

using System.Collections.Generic;

namespace ExampleMediatR.Queries
{
    public class GetAllCustomersQuery : IRequest<IList<CustomerResponse>> { }
}
