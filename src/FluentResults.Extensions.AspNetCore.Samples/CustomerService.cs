namespace FluentResults.Extensions.AspNetCore.Samples
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public Result<Customer> GetCustomer(int id)
        {
            if (id < 1)
            {
                var validationProblem = new ValidationProblemError("Id must be greater than 0")
                    .WithKey(nameof(id));

                return Result.Fail(validationProblem);
            }

            if (id == 2)
            {
                var forbid = new ForbidError();
                return Result.Fail(forbid);
            }

            var customer = _repository.GetCustomer(id);

            if (customer == null)
            {
                return Result.Fail(new NotFoundError());
            }

            return Result.Ok(customer);
        }

        public Result<Customer> CreateCustomer(string name)
        {
            var createResult = Customer.Create(name);

            if (createResult.IsFailed)
            {
                return createResult;
            }

            var customer = _repository.AddCustomer(createResult.Value);
            return Result
                .Ok(customer)
                .WithSuccess<CreatedSuccess>();
        }

        public Result PromoteToPremiumCustomer(int id)
        {
            var customerResult = GetCustomer(id);

            if (customerResult.IsFailed)
            {
                return customerResult;
            }

            var customer = customerResult.Value;
            return customer.PromoteToPremium();
        }
    }
}
