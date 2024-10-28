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
            IEnumerable<CustomerListItemDTO> allCustomers = await this._mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return Ok(allCustomers);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            CustomerListItemDTO customer = await this._mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return new CreatedResult($"api/customers/{customer.ID}", customer);
        }
    }
}
