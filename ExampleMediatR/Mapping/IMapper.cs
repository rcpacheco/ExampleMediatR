using ExampleMediatR.Dtos;
using ExampleMediatR.Responses;

using System.Collections.Generic;

namespace ExampleMediatR.Mapping
{
    public interface IMapper
    {
        IList<CustomerResponse> MapCustomerDtosToCustomerResponses(IList<CustomerDto> dtos);

        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        IList<OrderResponse> MapOrderDtosToOrderResponses(IList<OrderDto> customerOrders);

        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}
