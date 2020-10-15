using MakeMagic.Dextra.Infrastructure.Entities.PotterApi.Models;
using MakeMagic.Dextra.Infrastructure.Exceptions;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class PotterApiRepository : ApiRepository, IPotterApiRepository
    {
        private bool disposedValue = false;
        private readonly string apiUrl = "https://www.potterapi.com/v1";
        private readonly string apiKey = "?key=$2a$10$zEDvowYvN.sLdQPJvtyff.rxw3RhuHa00WDJYooia5.5I9.axxqrW";

        /// <inheritdoc />
        public async Task<IEnumerable<House>> GetByHouseId(string houseId)
        {
            try
            {
                var url = String.Concat(apiUrl, "/houses/", houseId, apiKey);
                var result = await GetAsync<IEnumerable<House>>(url);

                return result;
            }
            catch(Exception ex)
            {
                throw new InfrastructureException($"The current houseId is not found. [houseId = {houseId}].");
            }
        }

        #region IDisposable Support

        /// < inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        /// < inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
