using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess
{
    /// <summary>
    /// Provides a database context.
    /// </summary>
    public interface IContext : IDisposable
    {
        /// <summary>
        /// represents <see cref="Charater"/> collection in the database context.
        /// </summary>
        DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Save database changes asynchronously.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns><see cref="Task{int}"/>.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
