using ExampleMediatR.Commands;
using ExampleMediatR.Mapping;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

using System.Threading;
using System.Threading.Tasks;

namespace ExampleMediatR.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerOrderHandler> _logger;

        public CreateCustomerOrderHandler(IOrdersRepository ordersRepository, IMapper mapper, ILogger<CreateCustomerOrderHandler> logger)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateCustomerOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.CreateOrderAsync(command.CustomerId, command.ProductId).ConfigureAwait(false);
            _logger.LogInformation($"Created order for customer: {order.CustomerId} for product: {order.ProductId}");
            return _mapper.MapOrderDtoToOrderResponse(order);
        }
    }
}
