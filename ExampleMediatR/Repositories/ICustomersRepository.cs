using ExampleMediatR.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleMediatR.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        Task<IList<CustomerDto>> GetCustomersAsync();
    }
}
