using System;

namespace MMT.Orders.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException( string message ) : base( message )
        {

        }
    }
}
