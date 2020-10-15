using System;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Provides api basics.
    /// </summary>
    public interface IApiRepository : IDisposable
    {
        /// <summary>
        /// Execute a Http GET.
        /// </summary>
        /// <typeparam name="T"><see cref="T"/>.</typeparam>
        /// <param name="url">string.</param>
        /// <returns><see cref="Task{Task}"/></returns>
        Task<T> GetAsync<T>(string url);
    }
}
