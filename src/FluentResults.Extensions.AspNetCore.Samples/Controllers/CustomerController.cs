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
        public ActionResult<Customer> GetCustomer(int id)
        {
            var result = _service.GetCustomer(id);
            return this.Result(result);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(string name)
        {
            var result = _service.CreateCustomer(name);
            return this.Result(result);
        }

        [HttpPost("{id}/promote")]
        public ActionResult CreateCustomerToPremium(int id)
        {
            var result = _service.PromoteToPremiumCustomer(id);
            return this.Result(result);
        }
    }
}
