using ExampleMediatR.Mapping;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;

using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleMediatR.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IList<OrderResponse>>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderDtos = await _ordersRepository.GetOrdersAsync().ConfigureAwait(false);
            return _mapper.MapOrderDtosToOrderResponses(orderDtos);
        }
    }
}
