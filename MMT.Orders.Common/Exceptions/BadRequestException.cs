using System;

namespace MMT.Orders.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException( string message ) : base( message )
        {

        }
    }
}
