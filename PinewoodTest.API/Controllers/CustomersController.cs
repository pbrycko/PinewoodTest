using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinewoodTest.API.RequestHandlers;
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
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            GetAllCustomersCommand command = new GetAllCustomersCommand();
            IEnumerable<CustomerListItemDTO> allCustomers = await _mediator.Send(command, cancellationToken);
            return Ok(allCustomers);
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetAsync))]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            GetCustomerCommand command = new GetCustomerCommand(id);
            CustomerDTO? customer = await _mediator.Send(command, cancellationToken);
            return customer == null 
                ? NotFound() 
                : Ok(customer);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            CreateCustomerCommand command = new CreateCustomerCommand()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = request.Address,
                City = request.City
            };

            try
            {
                CustomerDTO customer = await _mediator.Send(command, cancellationToken);
                return CreatedAtAction(nameof(GetAsync), new { customer.ID }, customer);
            }
            catch (EmailConflictException ex)
            {
                ModelState.AddModelError(nameof(CreateCustomerRequest.Email), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        [HttpPut("{id:guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateAsnc(Guid id, UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(id)
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = request.Address,
                City = request.City
            };

            try
            {
                CustomerDTO customer = await _mediator.Send(command, cancellationToken);
                return Ok(customer);
            }
            catch (EmailConflictException ex)
            {
                ModelState.AddModelError(nameof(CreateCustomerRequest.Email), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> CreateAsync(Guid id, CancellationToken cancellationToken)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(id);
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
