using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinewoodTest.Requests;
using PinewoodTest.Responses;
using System.Net.Mime;

namespace PinewoodTest.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [AllowAnonymous]    // in Production, it probably should require auth
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            GetAllCustomersRequest request = new GetAllCustomersRequest();
            IEnumerable<CustomerListItemDTO> allCustomers = await this._mediator.Send(request, cancellationToken);
            return Ok(allCustomers);
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetAsync))]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            GetCustomerRequest request = new GetCustomerRequest(id);
            CustomerDTO? customer = await this._mediator.Send(request, cancellationToken);
            return customer == null 
                ? NotFound() 
                : Ok(customer);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            CustomerListItemDTO customer = await this._mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetAsync), new { customer.ID }, customer);
        }
    }
}
