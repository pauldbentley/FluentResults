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

        public Result PromoteToPremium()
        {
            if (Id == 1)
            {
                var problem = new ProblemError($"Customer ID {Id} is not available to be promoted.")
                    .WithTitle("Cannot to promote to premium")
                    .WithStatusCode(403)
                    .WithType("https://example.com/probs/cannot-promote-to-premium")
                    .WithInstance($"/customers/{Id}/msgs/abc");

                return Result.Fail(problem);
            }

            return Result.Ok();
        }

        private static Result ValidateName(string name)
        {
            return Result.FailIf(name == null, "Name must be suppiled");
        }
    }
}