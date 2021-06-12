using Microsoft.Extensions.Options;
using MMT.Orders.Common.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MMT.Orders.Services.Tests
{
    public class CustomerServiceTests
    {
        private CustomerService customerService;

        [SetUp]
        public void Setup()
        {
            ApiKeys keys = new ApiKeys();
            keys.Customer = "1CrsOooSHlV15C7OYnLY0DHjBHyjzoI8LNHITV04cNCyNCahecPDhw==";
            keys.CustomerUrl = "https://customer-account-details.azurewebsites.net/api/";
            IOptions<ApiKeys> options = Options.Create( keys );
            customerService = new CustomerService( options );
        }

        [Test]
        public async Task CanConnectToServiceAndGetCustomer()
        {
            var email = "cat.owner@mmtdigital.co.uk";
            var user = await customerService.GetUser( email );
            Assert.IsNotNull( user, $"User {email} is null" );
            Assert.AreEqual( user.Email, email );
        }

        [Test]
        public async Task CanConnectToServiceAndHandleNotFound()
        {
            var email = "cat.owner@notfound.co.uk";
            var user = await customerService.GetUser( email );
            Assert.IsNull( user, $"User {email} is null" );
        }

        [Test]
        public async Task WhenCustomerIdMatchesEmail_ReturnRequest()
        {
            var email = "cat.owner@notfound.co.uk";
            var clientId = "C34454";

            var user = await customerService.GetUser( email );
            Assert.IsNull( user, $"User {email} is null" );
        }

        //[Test]
        //public async Task WhenCustomerIdDoesntMatchEmail_ReturnBadRequest()
        //{
        //    var email = "cat.owner@notfound.co.uk";
        //    var clientId = "C34454";

        //    var user = await customerService.GetUser( email );
        //    Assert.IsNull( user, $"User {email} is null" );
        //}

    }
}