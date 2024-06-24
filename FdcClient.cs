using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Web;
using Usda.Fdc.Api.Lib.Converters.EnumTranslators;
using Usda.Fdc.Api.Lib.Converters.Single;
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
        /// Uses GET /v1/foods/search end point to return a list of food options 
        /// </summary>
        /// <param name="search">Search query</param>
        /// <param name="dataType"></param>
        /// <param name="pageNumber">Page number of results you want</param>
        /// <param name="pageSize">Size of results page</param>
        /// <param name="sortBy">Criteria to sort by</param>
        /// <param name="sortOrder"></param>
        /// <param name="brandOwner"></param>
        /// <returns></returns>
        public async Task<SearchResult> SearchFoods(string search, IEnumerable<FdcDataType>? dataType = null,
            int? pageNumber = null, int? pageSize = null, FdcSortBy? sortBy = null, FdcSortOrder? sortOrder = null,
            string? brandOwner = null)
        {
            var query = BuildStarterQueryString();

            if (dataType != null)
            {
                var translator = new FdcDataTypeTranslator();

                query["dataType"] = string.Join(",", dataType
                    .Select(t => translator.FromEnum(t)));
            }
            if (pageNumber != null)
            {
                query["pageNumber"] = pageNumber.Value.ToString();
            }
            if (pageSize != null)
            {
                query["pageSize"] = pageSize.Value.ToString();
            }
            if (sortBy != null)
            {
                var translator = new FdcSortByTranslator();

                query["sortBy"] = translator.FromEnum(sortBy.Value);
            }
            if (sortOrder != null)
            {
                var translator = new FdcSortOrderTranslator();

                query["sortOrder"] = translator.FromEnum(sortOrder.Value);
            }
            if (brandOwner != null)
            {
                query["brandOwner"] = brandOwner;
            }

            var endpoint = $"{MainUrl}/v1/foods/search?{query}";

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(SearchResult));

            return (SearchResult)content;
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
