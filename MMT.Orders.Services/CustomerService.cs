using Microsoft.Extensions.Options;
using MMT.Orders.Common.Configuration;
using MMT.Orders.Contracts.Dtos.Apis;
using MMT.Orders.Contracts.Dtos.Services;
using MMT.Orders.Contracts.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApiKeys _keys;

        public CustomerService( IOptions<ApiKeys> keys )
        {
            _keys = keys.Value;
        }

        public async Task<CustomerApiResponseDto> GetUser( string email )
        {
            using ( var httpClient = new HttpClient() )
            {
                var req = new CustomerApiRequestDto() { Email = email };
                StringContent content = new StringContent( JsonConvert.SerializeObject( req ), Encoding.UTF8, "application/json" );
                CustomerApiResponseDto result = null;

                using ( var response = await httpClient
                    .GetAsync( $"{_keys.CustomerUrl}/GetUserDetails?code={_keys.Customer}&email={email}" ) )
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<CustomerApiResponseDto>( apiResponse );
                    return result;
                }
            }
        }
    }
}
