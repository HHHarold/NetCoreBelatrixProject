using Chinook.Repository.Postgresql;
using Chinook.WebApi.Controllers;
using Chinook.WebApi.Test.Builder.Data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.WebApi.Test
{
    public class CustomerControllerTests
    {
        private readonly ChinookDbContextBuilder _builder;
        public CustomerControllerTests()
        {
            _builder = new ChinookDbContextBuilder();
        }

        [Fact]
        public async Task CustomerController_GetCustomers_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenCustomers()
                .Build();

            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomerController(repository);

            var response = (await controller.GetCustomers())
                .Result as OkObjectResult;

            var values = response.Value as List<Models.Customer>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task CustomerController_CreateCustomer_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .Build();

            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomerController(repository);

            var newCustomer = A.New<Models.Customer>();

            var response = (await controller.PostCustomer(newCustomer))
                .Result as OkObjectResult;

            var value = Convert.ToInt32(response.Value);

            value.Should().Be(newCustomer.CustomerId);
        }
    }
}
