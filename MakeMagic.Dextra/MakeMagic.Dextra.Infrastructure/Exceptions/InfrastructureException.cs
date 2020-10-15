using System;

namespace MakeMagic.Dextra.Infrastructure.Exceptions
{
    /// <inheritdoc />
    public class InfrastructureException : Exception
    {
        /// <summary>
        /// Instantiate an exception in the Infrastructure context.
        /// </summary>
        /// <param name="message">string.</param>
        public InfrastructureException(string message) : base(message)
        {
        }
    }
}
