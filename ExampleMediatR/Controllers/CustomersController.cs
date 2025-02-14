﻿using ExampleMediatR.Queries;
using ExampleMediatR.Responses;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace ExampleMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            GetAllCustomersQuery query = new();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            GetCustomerByIdQuery query = new(customerId);
            CustomerResponse result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            GetCustomerOrdersQuery query = new(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
