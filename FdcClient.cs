using System.Runtime.InteropServices;

namespace Usda.Fdc.Api
{
    public class FdcClient
    {
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
        public List<object> SearchFoods(string search, IEnumerable<string>? dataType = null,
            int? pageNumber = null, int? pageSize = null, string? sortBy = null, string? sortOrder = null,
            string? brandOwner = null)
        {
            return null;
        }

    }
}
