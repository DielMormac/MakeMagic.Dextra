using MakeMagic.Dextra.Infrastructure.Entities.PotterApi;
using MakeMagic.Dextra.Infrastructure.Entities.PotterApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Provides communication to the Potter Api.
    /// </summary>
    public interface IPotterApiRepository : IDisposable
    {
        /// <summary>
        /// Gets the houseId for the specific house in Potter Api.
        /// </summary>
        /// <param name="houseId">string.</param>
        /// <returns><see cref="Task{House}"/>.</returns>
        Task<IEnumerable<House>> GetByHouseId(string houseId);
    }
}
