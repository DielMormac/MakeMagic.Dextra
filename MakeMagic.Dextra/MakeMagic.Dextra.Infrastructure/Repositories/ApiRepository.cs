using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakeMagic.Dextra.Infrastructure.Repositories
{
    /// <inheritdoc />
    public class ApiRepository : IApiRepository
    {
        private HttpClient httpClient;
        private bool disposedValue = false;

        public ApiRepository()
        {
            this.httpClient = new HttpClient();
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string url)
        {
            var request = httpClient.GetAsync(url);
            return await ProcessResponse<T>(request);
        }

        /// <inheritdoc />
        private Task<T> ProcessResponse<T>(Task<HttpResponseMessage> httpResponseMessage)
        {
            return httpResponseMessage.ContinueWith(response =>
            {
                response.Result.EnsureSuccessStatusCode();
                return response.Result.Content.ReadAsByteArrayAsync();
            }).ContinueWith(readAsByteResponse =>
            {
                try
                {
                    string responseContent = Encoding.UTF8.GetString(readAsByteResponse.Result.Result);

                    T result = default(T);

                    if (!string.IsNullOrWhiteSpace(responseContent) && !"[]".Equals(responseContent) && !@"""[]""".Equals(responseContent))
                        result = JsonConvert.DeserializeObject<T>(responseContent);

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        #region IDisposable Support

        /// < inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    httpClient?.Dispose();
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
