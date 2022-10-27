using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace spw_first_webapp.Services
{
    public interface IRequestService
    {
        Task<T> PostAsync<T>(string envname, string uri, object param);
        Task<T> GetAsync<T>(string envname, string uri);
    }

    public class RequestService : IRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> PostAsync<T>(string envname, string uri, object param)
        {
            T result = default(T);        

            try
            {
                var client = _httpClientFactory.CreateClient(envname);

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

                using (var httpResponse = await client.PostAsync(uri, stringContent))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string jsonString = await httpResponse.Content.ReadAsStringAsync();

                        result = JsonConvert.DeserializeObject<T>(jsonString);
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

        public async Task<T> GetAsync<T>(string envname, string uri)
        {
            T result = default(T);

            try
            {
                var client = _httpClientFactory.CreateClient(envname);

                using (var httpResponse = await client.GetAsync(uri))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string jsonString = await httpResponse.Content.ReadAsStringAsync();

                        result = JsonConvert.DeserializeObject<T>(jsonString);
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
