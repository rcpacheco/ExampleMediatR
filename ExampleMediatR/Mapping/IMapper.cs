using ExampleMediatR.Commands;
using ExampleMediatR.Dtos;
using ExampleMediatR.Requests;
using ExampleMediatR.Responses;

using System.Collections.Generic;

namespace ExampleMediatR.Mapping
{
    public interface IMapper
    {
        IList<CustomerResponse> MapCustomerDtosToCustomerResponses(IList<CustomerDto> dtos);

        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        CreateCustomerOrderCommand MapCreateCustomerOrderRequestToCreateCustomerOrderCommand(CreateCustomerOrderRequest request);

        IList<OrderResponse> MapOrderDtosToOrderResponses(IList<OrderDto> customerOrders);

        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}
