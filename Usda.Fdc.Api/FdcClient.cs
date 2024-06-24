using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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
        /// Used GET /v1/foods end point to get foods.
        /// </summary>
        /// <param name="fdcIds">Ids of food items to be retrieved.</param>
        /// <param name="format"></param>
        /// <param name="nutrients">Nutrient numbers of nutrients to be returned in response. If all nutrients are wanted, leave null. </param>
        /// <returns>List of abridged food items that match against the search criteria.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<AbridgedFoodItem>> GetAbridgedFoods(IEnumerable<int> fdcIds, FdcFormat? format = null, IEnumerable<int>? nutrients = null)
        {
            var query = BuildStarterQueryString();

            query["fdcIds"] = string.Join(",", fdcIds);

            var translator = new FdcFormatTranslator();
            query["format"] = translator.FromEnum(FdcFormat.Abridged);

            if (nutrients != null)
            {
                query["nutrients"] = string.Join(",", nutrients);
            }

            var endPoint = $"{MainUrl}/v1/foods?{query}";

            var response = await _httpClient.GetAsync(endPoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<AbridgedFoodItem>));
            return (IEnumerable<AbridgedFoodItem>)content;
        }

        /// <summary>
        /// Used GET /v1/foods end point to get foods.
        /// </summary>
        /// <param name="fdcIds">Ids of food items to be retrieved.</param>
        /// <param name="format"></param>
        /// <param name="nutrients">Nutrient numbers of nutrients to be returned in response. If all nutrients are wanted, leave null. </param>
        /// <returns>List of objects castable to one of these folowing types: <see cref="BrandedFoodItem"/>, <see cref="FoundationFoodItem"/>, <see cref="SrLegacyFoodItem"/>,<see cref="SurveyFoodItem="/>.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<object>> GetFoods(IEnumerable<int> fdcIds, FdcFormat? format = null, IEnumerable<int>? nutrients = null)
        {
            var query = BuildStarterQueryString();

            query["fdcIds"] = string.Join(",", fdcIds);

            if (format != null)
            {
                var translator = new FdcFormatTranslator();
                query["format"] = translator.FromEnum(format.Value);
            }
            if (nutrients != null)
            {
                query["nutrients"] = string.Join(",", nutrients);
            }

            var endPoint = $"{MainUrl}/v1/foods?{query}";

            var response = await _httpClient.GetAsync(endPoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<object>));
            return (IEnumerable<object>)content;
        }

        /// <summary>
        /// Uses POST /v1/foods to get foods.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>List of objects castable to one of these folowing types: <see cref="AbridgedFoodItem"/> <see cref="BrandedFoodItem"/>, <see cref="FoundationFoodItem"/>, <see cref="SrLegacyFoodItem"/>,<see cref="SurveyFoodItem="/>.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<object>> GetFoods(FoodsCriteria criteria)
        {
            var query = BuildStarterQueryString();

            var endPoint = $"{MainUrl}/v1/foods?{query}";

            var response = await _httpClient.PostAsJsonAsync(endPoint, criteria);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<object>));
            return (IEnumerable<object>)content;
        }

        /// <summary>
        /// Uses POST /v1/foods/list to get list of abridged food items.
        /// </summary>
        /// <param name="criteria">Criteria used to filter search.</param>
        /// <returns>List of food items that match search.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<AbridgedFoodItem>> GetFoodList(FoodListCriteria criteria)
        {
            var query = BuildStarterQueryString();

            var endPoint = $"{MainUrl}/v1/foods/list?{query}";

            var response = await _httpClient.PostAsJsonAsync(endPoint, criteria);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<AbridgedFoodItem>));
            return (IEnumerable<AbridgedFoodItem>)content;
        }

        /// <summary>
        /// Uses GET /v1/foods/list to get list of abridged food items.
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns>List of food items that match search.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<AbridgedFoodItem>> GetFoodList(IEnumerable<FdcDataType>? dataType = null, int? pageSize = null,
             int? pageNumber = null, FdcSortBy? sortBy = null, FdcSortOrder? sortOrder = null)
        {
            var query = BuildStarterQueryString();

            if (dataType != null)
            {
                var translator = new FdcDataTypeTranslator();
                query["dataType"] = string.Join(",", dataType.Select(translator.FromEnum));
            }
            if (pageSize != null)
            {
                query["pageSize"] = pageSize.ToString();
            }
            if (pageNumber != null)
            {
                query["pageNumber"] = pageNumber.ToString();
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

            var endPoint = $"{MainUrl}/v1/foods/list?{query}";

            var response = await _httpClient.GetAsync(endPoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            var content = await response.Content.ReadFromJsonAsync(typeof(IEnumerable<AbridgedFoodItem>));
            return (IEnumerable<AbridgedFoodItem>)content;
        }

        /// <summary>
        /// Uses GET /v1/food/{fdcId} end point to retrieve a food item. Specifies abridged format.
        /// </summary>
        /// <param name="fdcId">Id of the food item to retrieve.</param>
        /// <param name="nutrients"></param>
        /// <returns>List of nutrient IDs used to filter which nutrients are returned.</returns>
        public async Task<AbridgedFoodItem> GetAbridgedFood(int fdcId, IEnumerable<int>? nutrients = null)
        {
            var results = await GetFood(fdcId, nutrients: nutrients, format: FdcFormat.Abridged);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var castedResults = JsonSerializer.Deserialize<AbridgedFoodItem>(results, options);

            return castedResults;
        }

        /// <summary>
        /// Uses GET /v1/food/{fdcId} end point to retrieve a food item
        /// </summary>
        /// <param name="fdcId">Id of the food item to retrieve.</param>
        /// <param name="nutrients">List of nutrient IDs used to filter which nutrients are returned.</param>
        /// <param name="format">Desired format for returned data.</param>
        /// <returns>String of JSON object representing one of the following types: <see cref="BrandedFoodItem"/>, <see cref="FoundationFoodItem"/>, <see cref="SrLegacyFoodItem"/>,<see cref="SurveyFoodItem="/>.</returns>
        public async Task<string> GetFood(int fdcId, IEnumerable<int>? nutrients = null, FdcFormat? format = null)
        {
            var query = BuildStarterQueryString();

            if (nutrients != null && nutrients.Count() > 0)
            {
                query["nutrients"] = string.Join(",", nutrients);
            }
            if (format != null)
            {
                var translator = new FdcFormatTranslator();

                query["format"] = translator.FromEnum(format.Value);
            }

            var endpoint = $"{MainUrl}/v1/food/{fdcId}?{query}";

            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
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
