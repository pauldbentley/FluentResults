using Microsoft.AspNetCore.Mvc;

namespace FluentResults.Extensions.AspNetCore.Samples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            return this.Result(_service.GetCustomer(id));
        }
    }

    public class CustomerDto
    {
        public int Id { get; init; }

        public string Name { get; init; }
    }

    public static class CustomerExtensions
    {
        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            return new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }
    }
}
