using System.Collections.Generic;
using System.Linq;

namespace FluentResults.Extensions.AspNetCore.Samples
{
    public class CustomerRepository
    {
        private readonly List<Customer> _data = InitData();

        public Customer? GetCustomer(int id)
        {
            return _data.FirstOrDefault(e => e.Id == id);
        }

        private static List<Customer> InitData()
        {
            return new()
            {
                new() { Id = 1, Name = "John Smith" },
                new() { Id = 2, Name = "Jane Doe" },
                new() { Id = 3, Name = "Guybrush Threepwood" },
            };
        }

        public Customer AddCustomer(Customer customer)
        {
            customer.Id = _data.Max(e => e.Id) + 1;
            _data.Add(customer);
            return customer;
        }
    }
}
