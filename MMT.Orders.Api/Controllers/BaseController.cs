using Microsoft.AspNetCore.Mvc;
using MMT.Orders.Common.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MMT.Orders.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected async Task<ActionResult<T>> ExecuteWithErrorHandling<T>( Func<Task<T>> action ) where T : class
        {
            try
            {
                return await action();
            }
            catch ( NotFoundException ex )
            {
                return NotFound( ex.Message );
            }
            catch ( BadRequestException ex )
            {
                return BadRequest( ex.Message );
            }
            catch ( ValidationException ex )
            {
                string message = ex.Message;

                if ( ex.ValidationResult != null )
                {
                    message =
                        string.Concat( message, " - ", ex.ValidationResult.ErrorMessage );
                }
                return BadRequest( message );
            }
        }
    }
}
