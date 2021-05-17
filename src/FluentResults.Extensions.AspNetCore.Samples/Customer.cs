namespace FluentResults.Extensions.AspNetCore.Samples
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Result<Customer> Create(string name)
        {
            var validationResults = ValidateName(name);

            if (validationResults.IsFailed)
            {
                return validationResults;
            }

            var customer = new Customer
            {
                Name = name,
            };

            return Result.Ok(customer);
        }

        private static Result ValidateName(string name)
        {
            return Result.FailIf(name == null, "Name must be suppiled");
        }
    }
}