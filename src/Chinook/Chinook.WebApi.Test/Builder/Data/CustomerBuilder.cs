using Chinook.Repository.Postgresql;
using GenFu;

namespace Chinook.WebApi.Test.Builder.Data
{
    public partial class ChinookDbContextBuilder
    {
        public ChinookDbContextBuilder AddTenCustomers()
        {
            AddCustomers(_context, 10);
            return this;
        }
        private void AddCustomers(ChinookDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Customer>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].CustomerId = i;
            }

            context.Customers.AddRange(customerList);
            context.SaveChanges();
        }
    }
}
