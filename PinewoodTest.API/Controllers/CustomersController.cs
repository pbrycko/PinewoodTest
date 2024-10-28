using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinewoodTest.Requests;
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

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            Guid customerID = await this._mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return new CreatedResult($"api/customers/{customerID}", customerID);
        }
    }
}
