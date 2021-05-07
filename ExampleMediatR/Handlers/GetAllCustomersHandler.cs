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
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IList<CustomerResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }
        public async Task<IList<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customerDtos = await _customersRepository.GetCustomersAsync().ConfigureAwait(false);
            return _mapper.MapCustomerDtosToCustomerResponses(customerDtos);
        }
    }
}
