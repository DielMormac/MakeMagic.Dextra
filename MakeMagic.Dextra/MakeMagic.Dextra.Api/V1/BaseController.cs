using MakeMagic.Dextra.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MakeMagic.Dextra.Api.V1
{
    /// <inheritdoc />
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Handle system exceptions.
        /// </summary>
        /// <param name="ex"><see cref="Exception"/>.</param>
        /// <returns><see cref="IActionResult"/>.</returns>
        protected IActionResult HandleExceptions(Exception ex)
        {
            if (ex.GetType() == typeof(InfrastructureException))
            {
                return BadRequest(ex.Message);
            }

            throw ex;
        }
    }
}
