using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Web;
using Usda.Fdc.Api.Models;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api
{
    public class FdcClient
    {
        private static string MainUrl = "https://api.nal.usda.gov/fdc";

        public static string? GlobalApiKey { private get; set; }

        private string _apiKey;

        private HttpClient _httpClient;

        /// <summary>
        /// Constructs client given that GlobalApiKey has been set
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="Exception">Thrown when static member GlobalApiKey has not been set</exception>
        public FdcClient(HttpClient client)
        { 
            if (GlobalApiKey == null)
            {
                throw new Exception("Cannot use this constructor unless field FdcClient.GlobalApiKey has been set");
            }
            else
            {
                _apiKey = GlobalApiKey;
            }

            _httpClient = client;
        }

        public FdcClient(string apiKey, HttpClient client)
        {
            _apiKey = apiKey;
            _httpClient = client;
        }
        /// <summary>
        /// Uses GET /foods/search end point to return a list of food options 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="dataType"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <param name="brandOwner"></param>
        /// <returns></returns>
        public List<object> SearchFoods(string search, IEnumerable<FdcDataType>? dataType = null,
            int? pageNumber = null, int? pageSize = null, string? sortBy = null, string? sortOrder = null,
            string? brandOwner = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Uses POST /v1/foods/search end point to retrieve search result.
        /// </summary>
        /// <param name="searchCriteria">Object containing critiera used to perform search.</param>
        /// <returns>Entries that match search criteria.</returns>
        public async Task<SearchResult> SearchFoods(FoodSearchCriteria searchCriteria)
        {
            var query = BuildStarterQueryString();

            var endpoint = $"{MainUrl}/v1/foods/search?{query}";

            var response = await _httpClient.PostAsJsonAsync(endpoint, searchCriteria);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(SearchResult));

            return (SearchResult)content;
        }

        private NameValueCollection BuildStarterQueryString()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["api_key"] = _apiKey;

            return query;
        }
    }
}
