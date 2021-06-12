using System;
using System.Text;

namespace MMT.Orders.Contracts.Dtos.Apis
{
    public class CustomerApiResponseDto
    {
        public string Email { get; set; }
        public string CustomerId { get; set; }
        public string Website { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string PreferredLanguage { get; set; }

        public string FullAddress
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat( "{0} {1}", HouseNumber, Street );
                if ( !string.IsNullOrEmpty( Town ) )
                {
                    builder.AppendFormat( ", {0}", Town );
                }
                if ( !string.IsNullOrEmpty( PostCode ) )
                {
                    builder.AppendFormat( ", {0}", PostCode );
                }

                return builder.ToString();
            }
        }
    }
}
